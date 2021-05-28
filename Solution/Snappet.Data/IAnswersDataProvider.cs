using Snappet.Common;
using Snappet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Data
{
    public interface IAnswersDataProvider
    {
        Task<IEnumerable<AnswerEntity>> GetSubmittedAnswers();
    }
}
