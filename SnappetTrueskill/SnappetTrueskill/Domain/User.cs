using Moserware.Skills;
using System.Collections.Generic;

namespace SnappetTrueskill.Domain
{
    public class User
    {
        public int Id { get; set; }
        public Dictionary<string, Rating> Ratings { get; set; }

        public User()
        {
            Ratings = new Dictionary<string, Rating>();
        }
    }
}
