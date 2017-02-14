using System.Collections.Generic;
using SnappetChallenge.BusinessLogicLayer.BusinessObjects;
using SnappetChallenge.DataAccessLayer.DTO;

namespace SnappetChallenge.BusinessLogicLayer.Interfaces
{
    public interface ISubmittedAnswerMapper
    {
        SubmittedAnswerDto Map(SubmittedAnswer submittedAnswer);
        SubmittedAnswer Map(SubmittedAnswerDto submittedAnswerDto);
        List<SubmittedAnswer> Map(IEnumerable<SubmittedAnswerDto> submittedAnswerDto);
        List<SubmittedAnswerDto> Map(IEnumerable<SubmittedAnswer> submittedAnswer);
    }
}