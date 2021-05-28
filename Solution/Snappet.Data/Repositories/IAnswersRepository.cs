using Snappet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Data
{
    public interface IAnswersRepository
    {
        Task Insert(AnswerEntity stats);
        Task Insert(IEnumerable<AnswerEntity> stats);

        Task<List<AnswerEntity>> GetByDate(DateTime date);
        bool DataExistsForDate(DateTime date);
    }
}
