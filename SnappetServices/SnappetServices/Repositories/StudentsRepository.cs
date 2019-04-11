using SnappetServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetServices.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        public IEnumerable<Student> GetAll()
        {
            try
            {
                var students = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText("data/students.json"));
                return students;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
