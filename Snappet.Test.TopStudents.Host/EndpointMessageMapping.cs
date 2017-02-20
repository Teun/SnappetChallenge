using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using Snappet.Test.DataRecorder.Interface;
using Snappet.Test.DataRecorder.Interface.Events;
using Snappet.Test.TopStudents.Interface;
using Snappet.Test.TopStudents.Interface.Events;

namespace Snappet.Test.TopStudents.Host
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

            return config;
        }
    }
}
