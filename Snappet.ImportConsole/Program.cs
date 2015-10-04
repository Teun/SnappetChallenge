using Ninject;
using ShellProgressBar;
using Snappet.DataAccess;
using Snappet.Domain;
using Snappet.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Snappet.Domain.Contracts;
using Snappet.ImportConsole.JsonConverters;

namespace Snappet.ImportConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Starting file import...");
            var exerciseResults = new List<ExerciseResult>();
            var jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data/work.json");
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                exerciseResults = JsonConvert.DeserializeObject<List<ExerciseResult>>(json, new NullStringConverter());
            }
            Console.WriteLine("{0} have been found in file", exerciseResults.Count);

            Console.WriteLine("Starting data save...");

            SaveExerciseResults(exerciseResults);

            Console.WriteLine("Finished");


        }

        private static IKernel InitializeKernel()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IExerciseResultRepository>().To<ExerciseResultRepository>();
            kernel.Bind<ISubjectRepository>().To<SubjectRepository>();
            kernel.Bind<IDomainRepository>().To<DomainRepository>();
            kernel.Bind<ILearningObjectiveRepository>().To<LearningObjectiveRepository>();
            kernel.Bind<IRelatedDataMapper>().To<RelatedDataMapper>();
            kernel.Bind<IUserMapper>().To<UserMapper>();
            kernel.Bind<IExerciseResultMapper>().To<ExerciseResultMapper>();
            kernel.Bind<IExerciseResultService>().To<ExerciseResultService>();
            return kernel;
        }

        static void SaveExerciseResults(List<ExerciseResult> exerciseResults)
        {
            
            if (exerciseResults.Any())
            {
                var ticks = exerciseResults.Count/1000;
                var rest = exerciseResults.Count%1000;
                var kernel = InitializeKernel();
                var exerciseResultService = kernel.Get<IExerciseResultService>();
                Console.WriteLine("Starting full data removal...");
                exerciseResultService.DeleteAllData();
                Console.WriteLine("All data removed...");

                Console.WriteLine("Starting adding related data...");
                exerciseResultService.SaveRelatedData(exerciseResults);

                var subjects = exerciseResultService.GetSubjects();
                var domains = exerciseResultService.GetDomains();
                var learningObjectives = exerciseResultService.GetLearningObjectives();
                

                foreach (var exerciseResult in exerciseResults)
                {
                    exerciseResult.SubjectId = subjects.FirstOrDefault(x => x.Name == exerciseResult.Subject).Id;
                    exerciseResult.DomainId = domains.FirstOrDefault(x => x.Name == exerciseResult.Domain).Id;
                    exerciseResult.LearningObjectiveId = learningObjectives.FirstOrDefault(x => x.Name == exerciseResult.LearningObjective).Id;

                }

                using (var pbar = new ProgressBar(ticks, "Starting", ConsoleColor.Cyan, '\u2593'))
                {
                    for (var i = 0; i <= ticks; i++)
                    {
                        var index = i == 0 ? 0 : i*1000;
                        var exercises = i==ticks? exerciseResults.GetRange(index, rest) : exerciseResults.GetRange(index, 1000);
                        exerciseResultService.SaveExerciseResults(exercises);
                        var message = "Curently saving " + index + " to " + (i == ticks ? index + rest : index + 1000 )+ " records";
                        pbar.Tick(message);
                        
                    }
                }
            }
        }

    }
}
