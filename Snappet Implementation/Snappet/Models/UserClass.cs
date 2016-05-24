using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Models
{
    public class UserClass
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<AnswerClass> Answers { get; set; }

        public UserClass(long id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Answers = new List<AnswerClass>();
        }
    }
}
