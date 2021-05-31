using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Snappet.Entity;
using Snappet.Repository;
using Snappet.Repository.AutoComplete;
using Snappet.Service;

namespace Snappet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Snappet", Version = "v1"}); });
            
            services.AddCors(c =>  
            {  
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());  
            });  

            //using singleton to keep data
            services.AddTransient<AutoCompleteRepositoryResolver>(provider => type =>
            {
                return type switch
                {
                    AutoCompleteType.Domain => provider.GetService<DomainAutoCompleteRepository>(),
                    AutoCompleteType.Exercise => provider.GetService<ExerciseAutoCompleteRepository>(),
                    AutoCompleteType.LearningObjective =>
                        provider.GetService<LearningObjectiveAutoCompleteRepository>(),
                    AutoCompleteType.Subject => provider.GetService<SubjectAutoCompleteRepository>(),
                    AutoCompleteType.User => provider.GetService<UserAutoCompleteRepository>(),
                    _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
                };
            });
            services.AddSingleton<UserAutoCompleteRepository>();
            services.AddSingleton<ExerciseAutoCompleteRepository>();
            services.AddSingleton<DomainAutoCompleteRepository>();
            services.AddSingleton<LearningObjectiveAutoCompleteRepository>();
            services.AddSingleton<SubjectAutoCompleteRepository>();
            services.AddSingleton<ISubmittedAnswerRepository, SubmittedAnswerRepository>();

            services.AddTransient<ISubmittedAnswerService, SubmittedAnswerService>();
            services.AddTransient<IReportService, ReportService>();

            services.AddHostedService<PrepareDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Snappet v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCors(options => options.AllowAnyOrigin());  
            
            //sample exception handling middleware
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}