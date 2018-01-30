using System;

namespace SnappetChallenge.Core.Models
{
    public class SubmittedAnswersFilter
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? UserId { get; set; }
    }
}