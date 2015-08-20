using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.BulkInsert.Extensions;
using SnappetChallenge.DAL.Entities;

namespace SnappetChallenge.DAL.DataImport
{
    internal sealed class DataTransformer
    {
        private readonly SnappetChallengeContext _context;

        public DataTransformer(SnappetChallengeContext context)
        {
           _context = context;
        }

        public void PerformTransformation()
        {
            GetStudents();
        }

        private void GetStudents()
        {
            var uniqueListOfStudents = _context.StudentAnswers.Select(s => s.UserId).Distinct();
            var generatedStudents = new List<Student>();

            foreach (var studentId in uniqueListOfStudents)
            {
                var generatedStudent = new Student
                {
                    Id = studentId,
                    Name = new RandomNameGenerator().GetName()
                };

                generatedStudents.Add(generatedStudent);
            }

            _context.BulkInsert(generatedStudents);
            _context.SaveChanges();
        }
    }
}
