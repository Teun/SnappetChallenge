using SnappetChallenge.DAL.Data;
using SnappetChallenge.DAL.Repositories;
using SnappetChallenge.DAL.Repositories.Contracts;
using SnappetChallenge.DAL.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.DAL.Services
{
    public class ProgressService : IProgressService
    {
        private IWorkRepository _repository;

        public ProgressService(IWorkRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AssignmentProgress> GetAssignments(DateTime fromDate, DateTime toDate)
        {
            var assignments = _repository.GetByDate(fromDate,toDate).GroupBy(w => w.UserId).Select(g => new AssignmentProgress(g.Key, g.ToList()));

            return assignments;
        }

        public IEnumerable<SubjectProgress> GetGetSubjects(DateTime fromDate, DateTime toDate)
        {
            var subjects = _repository.GetByDate(fromDate, toDate).GroupBy(w => w.Subject).Select(g => new SubjectProgress(g.Key, g.ToList()));

            return subjects;
        }
    }
}
