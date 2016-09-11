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

namespace Snappet.Data.Loader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DI doesn't seem to be working OTB for command line applications.
            IServiceCollection services = new ServiceCollection();
            services.AddRepositories();

            //You would say that this seems mighty stupid to pass this fixed path here. This is done because DI isn't working properly
            //here. We're doing everything by hand that framework really should be doing. Because of this AnswerContextFactory is never 
            //called and thus our context is not loaded normally.
            //The full path is needed because if not specified it will just use /Snappat.Data.Loader/bin/*. Which of course is A: never 
            //initialized there in the first place and B: is never used by our web-app.
            services.AddDbContext<AnswerContext>(options => options.UseSqlite("Filename=C:\\DEV\\_STORAGE\\SnappetChallenge\\src\\Snappet.Data\\answer.db"));

            IServiceProvider provider = services.BuildServiceProvider();
            IAnswerRepository answerRepository = provider.GetService<IAnswerRepository>();

            //Read work.json and parse to object, errors are ignored.
            StreamReader sr = File.OpenText("work.json");
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            jsonSettings.Error = JsonErrorHandler;

            List<Answer> answers = JsonConvert.DeserializeObject<List<Answer>>(sr.ReadToEnd(), jsonSettings);

            answerRepository.AddRange(answers);
            answerRepository.Save();
        }

        private static void JsonErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
        {
            args.ErrorContext.Handled = true;
        }
    }
}
