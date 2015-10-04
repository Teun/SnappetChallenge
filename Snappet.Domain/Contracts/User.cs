using System;
using System.Collections.Generic;

namespace Snappet.Domain.Contracts
{
   
    public class User
    {
        public int UserId { get; set; }
        public List<UserResult> UserResults { get; set; }
    }

    public class UserResult
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int TotalAnswers { get; set; }
        public int CorrectAnswers { get; set; }
    }
}
