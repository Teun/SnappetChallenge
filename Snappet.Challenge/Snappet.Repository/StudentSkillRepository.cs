using Snappet.Data;
using Snappet.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.Repository
{
    public class StudentSkillRepository : IStudentSkillRepository
    {
        private readonly IDataFactory _dataFactory;
        public StudentSkillRepository(IDataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }
        public IEnumerable<StudentSkill> FindByDate(DateTime startDate)
        {
            return FindAll().Where(skill => skill.SubmitDateTime.Date == startDate.Date);
        }
        public StudentSkill Find(int studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentSkill> FindAll()
        {
            return _dataFactory.FetchData();
        }

        public IEnumerable<StudentSkill> FindByDateRange(DateTime startDate, DateTime endDate)
        {
            return FindAll().Where(skill =>   skill.SubmitDateTime.Date >= startDate.Date && 
                                                    skill.SubmitDateTime.Date <= endDate.Date);
        }
    }
}
