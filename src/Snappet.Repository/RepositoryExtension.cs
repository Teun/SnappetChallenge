using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Data.Contexts;
using Snappet.Data;
using Snappet.Repository.Implementation;
using Snappet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Repository
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddContexts();

            //TODO: Figure out what type of service is the best. Maybe this causes the issues that I need to use async / await in some WebAPI Controllers.
            services.AddSingleton<IAnswerRepository, AnswerRepository>();
            services.AddSingleton<IClassRepository, ClassRepository>();
            services.AddSingleton<IDomainRepository, DomainRepository>();
            services.AddSingleton<ILearningObjectiveRepository, LearningObjectiveRepository>();
            services.AddSingleton<ISubjectRepository, SubjectRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
