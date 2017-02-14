using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.Models
{
    public class SubmittedAnswerListViewModel
    {
        public IQueryable<SubmittedAnswerViewModel> Answers { get; set; }

        public SubmittedAnswerListViewModel()
        {
            Answers = new List<SubmittedAnswerViewModel>().AsQueryable();
        }
    }
}