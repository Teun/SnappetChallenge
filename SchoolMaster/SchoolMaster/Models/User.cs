using System.Collections.Generic;

namespace SchoolMaster.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public ICollection<Work> Works { get; set; }
    }
}