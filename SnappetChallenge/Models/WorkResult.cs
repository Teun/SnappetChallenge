using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Json
{
    public class WorkResult
    {
        public WorkResult(string id, List<Answer> answers)
        {
            UserId = id;
            Answers = answers;
        }
        public string UserId { get; set; }

        public List<Answer> Answers { get; set; }
    }
}