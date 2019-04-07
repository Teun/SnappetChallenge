using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RReporter.Application.StoreWorkEvent;
using RReporter.Framework;

namespace RReporter.Run.WebApi
{
    public class Program
    {
        public static void Main (string[] args)
        {
            // The ConfigureServices call here allows for
            // ConfigureContainer to be supported in Startup with
            // a strongly-typed ContainerBuilder.
            var host = new WebHostBuilder ()
                .UseKestrel ()
                .ConfigureServices (services => services.AddAutofac ())
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .UseIISIntegration ()
                .UseStartup<Startup> ()
                .Build ();

            // hacky for the demo: run event emitter on a separate thread
            // doesn't close cleanly.
            var workEventHandler = (IWorkEventHandler) host.Services.GetService(typeof(IWorkEventHandler));
            var timeProvider = (ITimeProvider) host.Services.GetService(typeof(ITimeProvider));
            RunEmitterOnSeparateThreadAsync(workEventHandler, timeProvider);

            // finally, run host
            host.Run ();
        }

        public static Task RunEmitterOnSeparateThreadAsync (IWorkEventHandler workEventHandler, ITimeProvider timeProvider)
        {
            return Task.Run (() =>
            {
                WorkEventEmitter emitter = new WorkEventEmitter (workEventHandler);
                return emitter.EmitAllEventsAsync (timeProvider.CurrentUtcTime);
            });
        }

    }
}