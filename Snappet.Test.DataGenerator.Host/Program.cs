using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NServiceBus;
using NServiceBus.Logging;
using Snappet.Test.DataGenerator.Host.Model;
using Snappet.Test.DataRecorder.Interface;
using Snappet.Test.DataRecorder.Interface.Commands;
using Snappet.Test.DataRecorder.Interface.Dtos;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Snappet.Test.DataGenerator.Host
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        public static void Main(string[] args)
        {
            try
            {
                bool installOnly = args.Any() && args[0] == "install";
                AsyncMain(installOnly).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception! " + ex);
                Console.WriteLine("Press a key to exit");
                Console.ReadLine();
            }
        }

        private static async Task AsyncMain(bool installOnly)
        { 
            var endpoint = new DataGeneratorEndpoint(installOnly);
            await endpoint.Run();
            
            Console.WriteLine($"--------------------------------------------\n\nEndpoint {endpoint.EndpointName} working...\n");
            if (!installOnly)
            {
                DateTime startupTime = DateTime.Parse("2015-03-24 11:30:00", null, DateTimeStyles.AssumeUniversal);
                await SendData(startupTime, endpoint);

                await Task.Delay(TimeSpan.FromMilliseconds(-1));
            }

            await endpoint.Stop();
        }

        private static async Task SendData(DateTime startupTime, DataGeneratorEndpoint endpoint)
        {
            var appFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (JsonReader reader = new JsonTextReader(File.OpenText(Path.Combine(appFolder, "Data/work.json"))))
            {
                var serializer = new JsonSerializer();

                var data = serializer.Deserialize<List<ResultDataJson>>(reader);

                // Publish past data fast
                var sw = new Stopwatch();
                sw.Start();
                Log.Info($"Sending initial result records {DateTime.Now}");

                int sendPastDays;
                if (!int.TryParse(ConfigurationManager.AppSettings["SendPastDays"], out sendPastDays))
                {
                    sendPastDays = 1;
                }

                ResultData dto = null;
                foreach (ResultDataJson result in data.Where(r => r.SubmitDateTime > startupTime.AddDays(-sendPastDays) &&  r.SubmitDateTime < startupTime))
                {
                    Log.Info($"Sending result record {result.SubmittedAnswerId}");
                    // Send
                    var options = new SendOptions();
                    options.SetDestination(DataRecorderConstants.DataRecorderEndpointName);
                    dto = MapResultToDto(dto, result);

                    await endpoint.BusInstance.Send(new RecordResultCommand
                    {
                        Result = dto
                    }, options);
                }
                
                sw.Stop();
                Log.Info($"Sending initial result records {DateTime.Now}. Duration: {sw.Elapsed}. Last record {dto?.SubmittedAnswerId}");

                DateTime previousTime = dto.SubmitDateTime;
                foreach (ResultDataJson result in data.Where(r => r.SubmitDateTime >= startupTime))
                {
                    await Task.Delay(result.SubmitDateTime - previousTime);
                    dto = MapResultToDto(dto, result);

                    Log.Info($"Sending result record {result.SubmittedAnswerId} - {DateTime.Now}");
                    // Send
                    var options = new SendOptions();
                    options.SetDestination(DataRecorderConstants.DataRecorderEndpointName);
                    dto = MapResultToDto(dto, result);
                    await endpoint.BusInstance.Send(new RecordResultCommand
                    {
                        Result = dto
                    }, options);
                }
            }
        }

        private static ResultData MapResultToDto(ResultData dto, ResultDataJson result)
        {
            dto = new ResultData
            {
                Correct = result.Correct,
                Difficulty = result.DifficultyValue,
                Domain = result.Domain,
                ExerciseId = result.ExerciseId,
                LearningObjective = result.LearningObjective,
                Progress = result.Progress,
                Subject = result.Subject,
                SubmitDateTime = result.SubmitDateTime,
                SubmittedAnswerId = result.SubmittedAnswerId,
                UserId = result.UserId
            };
            return dto;
        }
    }
}
