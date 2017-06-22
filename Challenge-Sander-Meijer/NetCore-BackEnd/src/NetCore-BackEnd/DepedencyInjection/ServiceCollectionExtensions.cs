using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NetCore.BackEnd.Facades;
using NetCore.BackEnd.Facades.Factories;
using NetCore.BackEnd.Facades.Mappers;
using NetCore.BackEnd.Models.Dto;
using NetCore.BackEnd.Models.Poco;
using NetCore.BackEnd.Repositories;

namespace NetCore.BackEnd.DepedencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureDepedencyInjection(this IServiceCollection serviceCollection)
		{
			if (serviceCollection == null)
			{
				throw new ArgumentNullException(nameof(serviceCollection));
			}

			serviceCollection.AddScoped<IWorkResultFacade, WorkResultFacade>();

			serviceCollection.AddSingleton<IMapper<WorkResult, WorkResultDto>, WorkResultDtoMapper>();
			serviceCollection.AddSingleton<IFactory<IGrouping<int, WorkResult>, UserDto>, UserDtoFactory>();
			serviceCollection.AddSingleton<IFactory<IGrouping<string, WorkResult>, SubjectDto>, SubjectDtoFactory>();

			serviceCollection.AddScoped<IWorkResultRepository, WorkResultRepository>();
			serviceCollection.AddSingleton<IDataContext, JsonDataContext>();

			return serviceCollection;
		}
	}
}