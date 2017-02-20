using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Snappet.Test.TopStudents.Interface.Events;

namespace Snappet.Test.TopStudents.Web.EventHandlers
{
    internal class DaySubjectRankingChangedEventHandler : IHandleMessages<IDaySubjectRankingChangedEvent>
    {
        private static readonly ILog Log = LogManager.GetLogger<DaySubjectRankingChangedEventHandler>();

        public Task Handle(IDaySubjectRankingChangedEvent message, IMessageHandlerContext context)
        {
            // TODO Notify by SignalR
            Log.Info($"Notify by SignalR {nameof(IDaySubjectRankingChangedEvent)}");
            return Task.CompletedTask;
        }
    }
}
