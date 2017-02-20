using System;
using System.Data.Entity;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Snappet.Test.DataRecorder.Interface.Events;
using Snappet.Test.Infrastructure.NServiceBus;
using Snappet.Test.TopStudents.Core.Interfaces;
using Snappet.Test.TopStudents.Core.Model;
using Snappet.Test.TopStudents.Interface.Events;

namespace Snappet.Test.TopStudents.Host.EventHandlers
{
    public class DaySummaryRecordReceivedEventHandler : IHandleMessages<IDataRecordReceivedEvent>
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        public async Task Handle(IDataRecordReceivedEvent message, IMessageHandlerContext context)
        {
            if (message.Difficulty.HasValue)
            {
                string subject = message.Subject;
                int studentId = message.UserId;
                decimal difficulty = message.Difficulty.Value;
                DateTime date = message.SubmitDateTime.Date;
                var uow = context.GetUnitOfWork<ITopStudentsUnitOfWork>();

                DaySummary summary = await uow.DaySummaries
                    .FirstOrDefaultAsync(r => r.Subject == subject && r.RecordDate == date)
                    .ConfigureAwait(false);
                if (summary == null)
                {
                    summary = DaySummary.Create(subject, date);
                    uow.Insert(summary);
                }

                summary.UpdateSummary(studentId, difficulty, message.Progress);
                await uow.SaveAsync().ConfigureAwait(false);
            }
        }
    }
}