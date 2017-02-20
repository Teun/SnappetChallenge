using Autofac;
using NServiceBus;
using Snappet.Test.Infrastructure.NServiceBus;
using Snappet.Test.TopStudents.Core.Interfaces;
using Snappet.Test.TopStudents.Data.Implementations;
using Snappet.Test.TopStudents.Interface;
using Snappet.Test.TopStudents.Interface.Interfaces;

namespace Snappet.Test.TopStudents.Host
{
    internal class TopStudentsEndpoint : EndpointBase
    {
        public TopStudentsEndpoint(bool installOnly) : base(TopStudentsConstants.TopStudentsEndpointName, installOnly)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<TopStudentsQuery>().As<ITopStudentsQuery>();
        }

        protected override void Configure(EndpointConfiguration config)
        {
        }
    }
}