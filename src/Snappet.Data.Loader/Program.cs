using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Snappet.Data.Contexts;
using Snappet.Model;
using Snappet.Repository.Implementation;
using Snappet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Repository;
using Microsoft.EntityFrameworkCore;
using Snappet.Data.Contexts.Factories;
using Snappet.Data.Loader.Model;
using Snappet.Configuration;

namespace Snappet.Data.Loader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DI doesn't seem to be working OTB for command line applications.
            IServiceCollection services = new ServiceCollection();

            //You would say that this seems mighty stupid to pass this fixed path here. This is done because DI isn't working properly
            //here. We're doing everything by hand that framework really should be doing. Because of this SnappetContextFactory is never 
            //called and thus our context is not loaded normally.
            //The full path is needed because if not specified it will just use /Snappat.Data.Loader/bin/*. Which of course is A: never 
            //initialized there in the first place and B: is never used by our web-app.
            Config.ApplicationBasePath = "C:\\DEV\\_STORAGE\\SnappetChallenge\\src\\";

            services.AddRepositories();

            IServiceProvider provider = services.BuildServiceProvider();

            IAnswerRepository answerRepository = provider.GetService<IAnswerRepository>();
            IClassRepository classRepository = provider.GetService<IClassRepository>();
            IDomainRepository domainRepository = provider.GetService<IDomainRepository>();
            ILearningObjectiveRepository learningObjectiveRepository = provider.GetService<ILearningObjectiveRepository>();
            ISubjectRepository subjectRepository = provider.GetService<ISubjectRepository>();
            IUserRepository userRepository = provider.GetService<IUserRepository>();

            //Read work.json and parse to object, errors are ignored.
            StreamReader sr = File.OpenText("work.json");
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            jsonSettings.Error = JsonErrorHandler;

            List<WorkRow> rows = JsonConvert.DeserializeObject<List<WorkRow>>(sr.ReadToEnd(), jsonSettings);

            //Class:
            //Create some classes
            Random randomClassID = new Random();
            var classes = Enumerable.Range(1, 50)
                .Select(classID => new Class() { Name = "Class #" + classID });

            classRepository.AddRange(classes);
            classRepository.Save();

            //Domain:
            var domains = rows
                .Select(r => r.Domain)
                .Distinct()
                .Select(domainName => new Domain() { Name = domainName });

            domainRepository.AddRange(domains);
            domainRepository.Save();

            //LearningObjective:
            var learningObjectives = rows
                .Select(r => r.LearningObjective)
                .Distinct()
                .Select(learningObjectiveName => new LearningObjective() { Name = learningObjectiveName });

            learningObjectiveRepository.AddRange(learningObjectives);
            learningObjectiveRepository.Save();

            //Subject:
            var subjects = rows
                .Select(r => r.Subject)
                .Distinct()
                .Select(subjectName => new Subject() { Name = subjectName });

            subjectRepository.AddRange(subjects);
            subjectRepository.Save();

            //Users:
            var users = rows
                .Select(r => r.UserId)
                .Distinct()
                .Select(userID => new User() { ID = userID, Name = "Student #" + userID });

            userRepository.AddRange(users);
            userRepository.Save();

            int index = 0;
            int count = rows.Count;

            //Answers
            foreach (WorkRow r in rows)
            {
                if (index++ % 10 == 0)
                    Console.WriteLine($"Inserting class: {index} of {count}.");

                //The .AddRange on our BasicRepository seems to lose us the ability for EF to set the ID of the insert item.
                //Therefore we have to use the repositories again, this is slower.
                Answer a = new Answer();
                a.Class = classRepository.Find(randomClassID.Next(1, 50));
                a.Correct = r.Correct;
                a.Difficulty = r.Difficulty;
                a.Domain = domainRepository.Search().First(x => x.Name == r.Domain);
                a.ExerciseId = r.ExerciseId;
                a.LearningObjective = learningObjectiveRepository.Search().First(x => x.Name == r.LearningObjective);
                a.Progress = r.Progress;
                a.Subject = subjectRepository.Search().First(x => x.Name == r.Subject);
                a.SubmitDateTime = r.SubmitDateTime; //TODO: UTC to proper timezone
                a.User = userRepository.Find(r.UserId);

                answerRepository.Add(a);

                try
                {
                    if (index % 1000 == 0)
                        answerRepository.Save();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to insert Answer. Message: {ex.Message}");
                }
            }

            answerRepository.Save();
        }

        private static void JsonErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
        {
            args.ErrorContext.Handled = true;
        }
    }
}
