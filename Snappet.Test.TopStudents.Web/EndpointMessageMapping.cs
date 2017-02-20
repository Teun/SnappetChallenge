using System.Configuration;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using Snappet.Test.DataRecorder.Interface;
using Snappet.Test.DataRecorder.Interface.Events;
using Snappet.Test.TopStudents.Interface;
using Snappet.Test.TopStudents.Interface.Events;

namespace Snappet.Test.TopStudents.Web
{
    internal class EndpointMessageMapping : IProvideConfiguration<UnicastBusConfig>
    {
        public UnicastBusConfig GetConfiguration()
        {
            //read from existing config 
            UnicastBusConfig config = (UnicastBusConfig)ConfigurationManager.GetSection(typeof(UnicastBusConfig).Name) ??
                         new UnicastBusConfig
                         {
                             MessageEndpointMappings = new MessageEndpointMappingCollection()
                         };

            //append mappings to config
            config.MessageEndpointMappings.Add(new MessageEndpointMapping
            {
                AssemblyName = typeof(IDataRecordReceivedEvent).Assembly.FullName,
                Endpoint = DataRecorderConstants.DataRecorderEndpointName
            });

            config.MessageEndpointMappings.Add(new MessageEndpointMapping
            {
                AssemblyName = typeof(IDaySubjectRankingChangedEvent).Assembly.FullName,
                Endpoint = TopStudentsConstants.TopStudentsEndpointName
            });


            return config;
        }
    }
}
