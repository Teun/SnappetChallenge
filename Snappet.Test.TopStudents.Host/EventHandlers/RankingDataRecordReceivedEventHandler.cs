using System;
using System.Data.Entity;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Snappet.Test.DataRecorder.Interface.Events;
using Snappet.Test.Infrastructure.NServiceBus;
using Snappet.Test.TopStudents.Core.Interfaces;
using Snappet.Test.TopStudents.Core.Model;
using Snappet.Test.TopStudents.Interface.Dtos;
using Snappet.Test.TopStudents.Interface.Events;

namespace Snappet.Test.TopStudents.Host.EventHandlers
{
    public class RankingDataRecordReceivedEventHandler : IHandleMessages<IDataRecordReceivedEvent>
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        public async Task Handle(IDataRecordReceivedEvent message, IMessageHandlerContext context)
        {
            if (message.Difficulty.HasValue && message.Progress > 0)
            {
                TopStudentsRecord dayRecord = await UpdateRecord(message, context, TopStudentsRecordTypes.Day);
                if (dayRecord!=null)
                {
                    await context.Publish<IDaySubjectRankingChangedEvent>(e =>
                    {
                        e.Date = dayRecord.RecordDate;
                        e.Subject = dayRecord.Subject;
                    }).ConfigureAwait(false);
                }

                TopStudentsRecord monthRecord = await UpdateRecord(message, context, TopStudentsRecordTypes.Month);
                if (monthRecord != null)
                {
                    await context.Publish<IMonthSubjectRankingChangedEvent>(e =>
                    {
                        e.Date = monthRecord.RecordDate;
                        e.Subject = monthRecord.Subject;
                    }).ConfigureAwait(false);
                }
            }
        }

        private static async Task<TopStudentsRecord> UpdateRecord(IDataRecordReceivedEvent message, IMessageHandlerContext context,
            TopStudentsRecordTypes type)
        {
            string subject = message.Subject;
            int studentId = message.UserId;
            decimal difficulty = message.Difficulty.Value;
            DateTime date = TopStudentsRecord.AdjustDate(type, message.SubmitDateTime);
            var uow = context.GetUnitOfWork<ITopStudentsUnitOfWork>();

            TopStudentsRecord record = await uow.TopStudentsRecords
                .FirstOrDefaultAsync(r => r.Subject == subject && r.Type == type && r.RecordDate == date)
                .ConfigureAwait(false);
            if (record == null)
            {
                record = TopStudentsRecord.Create(subject, type, date);
                uow.Insert(record);
            }

            bool rankingChanged = record.SetInRanking(studentId, difficulty);

            if (rankingChanged)
            {
                await uow.SaveAsync().ConfigureAwait(false);
                return record;
            }
            return null;
        }
    }
}