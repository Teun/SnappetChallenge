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
    internal class MonthSubjectRankingChangedEventHandler : IHandleMessages<IMonthSubjectRankingChangedEvent>
    {
        private static readonly ILog Log = LogManager.GetLogger<MonthSubjectRankingChangedEventHandler>();

        public Task Handle(IMonthSubjectRankingChangedEvent message, IMessageHandlerContext context)
        {
            // TODO Notify by SignalR
            Log.Info($"Notify by SignalR {nameof(IMonthSubjectRankingChangedEvent)}");

            return Task.CompletedTask;
        }
    }
}
