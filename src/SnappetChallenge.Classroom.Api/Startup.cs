using Microsoft.EntityFrameworkCore;
using SnappetChallenge.Classroom.Api.Extensions;
using SnappetChallenge.Classroom.Application.Context;
using SnappetChallenge.Classroom.Infrastructure;

namespace SnappetChallenge.Classroom.Api;

public class Startup
{
    public Startup(IConfiguration configuration, IHostEnvironment env)
    {
        Configuration = configuration;
        Environment = env;
    }

    public IHostEnvironment Environment { get; }
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddRepositories(Configuration)
            .AddControllers();

        services.AddDbContext<IClassroomDbContext, ClassroomDbContext>(options =>
        {
            options.UseInMemoryDatabase(Configuration.GetConnectionString("MainConnection"));
        });
        
        if (!Environment.IsProduction())
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();            
        }
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!Environment.IsProduction())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        using (var scope = 
               app.ApplicationServices.CreateScope())
        using (var context = scope.ServiceProvider.GetService<ClassroomDbContext>())
            context.Database.EnsureCreated();        
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}