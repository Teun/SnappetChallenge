using Autofac;
using NServiceBus;
using Snappet.Test.DataRecorder.Interface;
using Snappet.Test.Infrastructure.NServiceBus;

namespace Snappet.Test.DataRecorder.Host
{
    public class DataRecorderEndpoint : EndpointBase
    {
        public DataRecorderEndpoint(bool installOnly) : base(DataRecorderConstants.DataRecorderEndpointName, installOnly)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
        }

        protected override void Configure(EndpointConfiguration config)
        {
        }
    }
}