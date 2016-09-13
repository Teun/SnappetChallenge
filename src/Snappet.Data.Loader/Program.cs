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
            Random randomClassID = new Random();
            var classes = rows
                .Select(r => randomClassID.Next(1, 50))
                .Distinct()
                .Select(classID => new Class() { ID = classID, Name = "Class #" + classID });

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
            var objectives = rows
                .Select(r => r.LearningObjective)
                .Distinct()
                .Select(objectiveName => new LearningObjective() { Objective = objectiveName });

            learningObjectiveRepository.AddRange(objectives);
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
        }

        private static void JsonErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
        {
            args.ErrorContext.Handled = true;
        }
    }
}
