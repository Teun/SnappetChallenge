using Autofac;
using NServiceBus;
using Snappet.Test.Infrastructure.NServiceBus;
using Snappet.Test.TopStudents.Core.Interfaces;
using Snappet.Test.TopStudents.Data.Implementations;
using Snappet.Test.TopStudents.Interface;
using Snappet.Test.TopStudents.Interface.Interfaces;

namespace Snappet.Test.TopStudents.Web
{
    internal class TopStudentsEndpointWeb : EndpointBase
    {
        public TopStudentsEndpointWeb(bool installOnly) : base(TopStudentsConstants.TopStudentsWebEndpointName, installOnly)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<TopStudentsQuery>().As<ITopStudentsQuery>().InstancePerRequest();
            builder.RegisterType<DaySummaryQuery>().As<IDaySummaryQuery>().InstancePerRequest();
        }

        protected override void Configure(EndpointConfiguration config)
        {
        }
    }
}