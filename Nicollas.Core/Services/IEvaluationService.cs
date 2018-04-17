using Nicollas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nicollas.Core.Services
{
    public interface IEvaluationService : IService<Evaluation, int>
    {
        Task InsertEvaluationDataAsync(IList<Evaluation> evalData);
    }
}
