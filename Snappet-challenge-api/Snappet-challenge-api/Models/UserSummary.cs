using System;
using System.Collections.Generic;

namespace Snappet_challenge_api.Models
{
    public class UserSummary
    {
        public int UserId { get; set; }
        public List<SubjectSummary> Subjects { get; set; }

        public UserSummary(int userId)
        {
            UserId = userId;
            Subjects = new List<SubjectSummary>();
        }
    }
}
