using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Snappet.Test.TopStudents.Core.Interfaces;
using Snappet.Test.TopStudents.Core.Model;
using Snappet.Test.TopStudents.Interface.Dtos;
using Snappet.Test.TopStudents.Interface.Interfaces;

namespace Snappet.Test.TopStudents.Data.Implementations
{
    public class TopStudentsQuery : ITopStudentsQuery
    {
        public async Task<TopStudentsDto> GetAsync(string subject, TopStudentsRecordTypes type, DateTime date)
        {
            TopStudentsDto record;

            using (new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Enabled))
            using (var context = new TopStudentsDbContext())
            {
                record = (await context.TopStudentsRecords
                    .AsNoTracking()
                    .Where(r => r.Subject == subject && r.Type == type && r.RecordDate == date)
                    .ToListAsync()
                    .ConfigureAwait(false)).Select(MapToDto).FirstOrDefault();
            }

            return record;
        }

        private static TopStudentsDto MapToDto(TopStudentsRecord record)
        {
            var dto = new TopStudentsDto
            {
                Subject = record.Subject,
                Top1Difficulty = record.Top1Difficulty,
                Top1StudentId = record.Top1StudentId,
                Top2StudentId = record.Top2StudentId,
                Top2Difficulty = record.Top2Difficulty,
                Top3Difficulty = record.Top3Difficulty,
                Top3StudentId = record.Top3StudentId,
                RecordDate = record.RecordDate,
                Type = record.Type.ToString()
            };
            return dto;
        }

    }
}