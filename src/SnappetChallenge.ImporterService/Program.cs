using SnappetChallenge.ImporterService;
using SnappetChallenge.ImporterService.Bootstrap;
using SnappetChallenge.Application.IoC;
using SnappetChallenge.Infrastructure.IoC;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddInfrastructure();
        services.AddApplication(true);
        services.AddHostedService<Worker>();
    })
    .Build();

await Bootstrapper.RunAsync(host);

await host.RunAsync();


