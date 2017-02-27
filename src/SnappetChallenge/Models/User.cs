using System.Collections.Generic;

namespace SnappetChallenge.Models
{
    public class User
    {
        public string Id { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}