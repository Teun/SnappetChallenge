using ClassMonitor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClassMonitor.Web.Configurations
{
    public class WebConfigurations
    {
        internal static async Task SeedDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
                await SeedData.InitializeAsync(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
            }
        }
    }
}
