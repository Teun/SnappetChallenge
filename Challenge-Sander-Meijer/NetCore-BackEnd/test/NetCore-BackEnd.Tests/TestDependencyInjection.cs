using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NetCore.BackEnd.Controllers;
using NetCore.BackEnd.DepedencyInjection;
using Xunit;

namespace NetCore.BackEnd.Tests
{
	public class TestDependencyInjection
	{
		public List<Type> Controllers = new List<Type>
		{
			typeof(WorkResultsController)
		};

		[Fact]
		public void TestConfigureDependencyInjection()
		{
			// Arrange
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddScoped(typeof(WorkResultsController));
			serviceCollection.ConfigureDepedencyInjection();
			
			var serviceProvider = serviceCollection.BuildServiceProvider();

			// Act
			var resolvedController = serviceProvider.GetService(typeof(WorkResultsController));

			// Assert
			Assert.NotNull(resolvedController);
		}
	}
}