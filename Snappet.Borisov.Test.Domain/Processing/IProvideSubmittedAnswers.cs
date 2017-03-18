using System.Collections.Generic;

namespace Snappet.Borisov.Test.Domain.Processing
{
    public interface IProvideSubmittedAnswers
    {
        IEnumerable<SubmittedAnswer> GetAll();
    }
}