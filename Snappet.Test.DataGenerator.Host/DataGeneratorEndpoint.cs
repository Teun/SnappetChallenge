using Autofac;
using NServiceBus;
using Snappet.Test.DataRecorder.Interface;
using Snappet.Test.Infrastructure.NServiceBus;

namespace Snappet.Test.DataGenerator.Host
{
    public class DataGeneratorEndpoint : EndpointBase
    {
        public const string DataGeneratorEndpointName = "DataGenerator";

        public DataGeneratorEndpoint(bool installOnly) : base(DataGeneratorEndpointName, installOnly)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
        }

        protected override void Configure(EndpointConfiguration config)
        {
            config.SendOnly();
        }
    }
}