using Snappet.Model;
using System;
using System.Collections.Generic;

namespace Snappet.Repository
{
    public interface IStudentSkillRepository
    {
        IEnumerable<StudentSkill> FindByDate(DateTime startDate);
        IEnumerable<StudentSkill> FindByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<StudentSkill> FindAll();
        StudentSkill Find(int studentId);
    }
}
