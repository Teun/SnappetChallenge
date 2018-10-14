using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.IO;
using WebApi.Models;

namespace WebApi
{
    public class Program
    {
        public static readonly ConcurrentBag<WorkItem> WorkItems = JsonConvert.DeserializeObject<ConcurrentBag<WorkItem>>(File.ReadAllText("Data/work.json"));

        public static void Main(string[] args)
        {           
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
