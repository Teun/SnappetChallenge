using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Application.Dtos
{
    public class IndividualStudentStats
    {
        public int StudentId { get; set; }
        public string Subject { get; set; }
        public int AnswersSubmitted { get; set; }
        public int Correct { get; set; }
        public int InCorrect { get; set; }
    }
}
