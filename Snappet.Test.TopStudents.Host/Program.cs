using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Test.TopStudents.Host
{
    class Program
    {
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
            var endpoint = new TopStudentsEndpoint(installOnly);
            await endpoint.Run();
            
            Console.WriteLine($"--------------------------------------------\n\nEndpoint {endpoint.EndpointName} working...\n");
            if (!installOnly)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(-1));
            }

            await endpoint.Stop();
        }
    }
}
