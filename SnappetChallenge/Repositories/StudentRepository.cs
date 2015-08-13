using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using SnappetChallenge.Models;

namespace SnappetChallenge.Repositories
{
    public class StudentRepository
    {
        public List<Student> GetStudents()
        {
            List<Student> students;
            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/students.json")))
            {
                students = JsonConvert.DeserializeObject<List<Student>>(sr.ReadToEnd());
            }
            return students;
        }
    }
}