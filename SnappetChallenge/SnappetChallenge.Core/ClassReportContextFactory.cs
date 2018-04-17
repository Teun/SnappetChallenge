namespace EFGetStarted.AspNetCore.NewDb.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    /// <summary>
    /// Db factory
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory{EFGetStarted.AspNetCore.NewDb.Models.ClassReportContext}" />
    public class ClassReportContextFactory : IDesignTimeDbContextFactory<ClassReportContext>
    {
        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>
        /// An instance of <typeparamref name="TContext" />.
        /// </returns>
        public ClassReportContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connection = configuration.GetConnectionString("ReportDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<ClassReportContext>();
            optionsBuilder.UseSqlServer(connection);

            return new ClassReportContext(optionsBuilder.Options);
        }
    }
}