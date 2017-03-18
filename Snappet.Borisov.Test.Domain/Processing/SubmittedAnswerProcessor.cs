using System.Linq;

namespace Snappet.Borisov.Test.Domain.Processing
{
    public class SubmittedAnswerProcessor : IProcessSubmittedAnswers
    {
        private readonly IProvideSubmittedAnswers _answers;
        private readonly IProvideDateTime _dateTime;
        private readonly ISubmitAnswers _submitAnswers;

        public SubmittedAnswerProcessor(
            IProvideSubmittedAnswers answers,
            ISubmitAnswers submitAnswers,
            IProvideDateTime dateTime
        )
        {
            _answers = answers;
            _submitAnswers = submitAnswers;
            _dateTime = dateTime;
        }

        public void Process()
        {
            var now = _dateTime.Now();
            var answers = _answers.GetAll().Where(x => x.SubmitDateTime <= now);
            foreach (var answer in answers) _submitAnswers.Submit(answer);
        }
    }
}