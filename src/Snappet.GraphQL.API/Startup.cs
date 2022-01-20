using Amazon.DynamoDBv2;
using GraphQL.Server.Ui.Voyager;
using Snappet.GraphQL.API.DbContext;
using Snappet.GraphQL.API.Model;
using Snappet.GraphQL.API.Schemma;

namespace Snappet.GraphQL.API
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQLVoyager();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var client = Configuration.GetAWSOptions().CreateServiceClient<IAmazonDynamoDB>();
            services.AddScoped<IDynamoDbContext<SubmittedAnswers>>(provider => new DynamoDbContext<SubmittedAnswers>(client));          
            ConfigurationBinder.Bind(Configuration.GetSection("SubmittedAnswers"), Configuration.GetAWSOptions());

            services.AddGraphQL()
                    .AddQueryType<Query>();
        }
    }
}
