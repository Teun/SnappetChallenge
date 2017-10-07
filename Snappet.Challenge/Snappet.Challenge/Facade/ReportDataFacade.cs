using Snappet.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.Challenge.Facade
{
    public class ReportDataFacade : IReportDataFacade
    {
        public IEnumerable<UserDto> ProcessSkillsData(IEnumerable<StudentSkill> skills)
        {
            var query = skills.GroupBy(skill => skill.UserId)
                      .Select(group => CreateUserDto(group));
            return query.ToList();
        }

        private UserDto CreateUserDto(IGrouping<int ,StudentSkill> student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var subjects= student.GroupBy(subject => subject.Subject)
                        .Select(grouping => CreateSubjectDto(grouping));

            return new UserDto
            {
                UserId=student.Key,
                Subjects=subjects
            };
        }
        private SubjectDto CreateSubjectDto(IGrouping<string, StudentSkill> subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            return new SubjectDto
            {
                Subject = subject.Key,
                Appraisal = Map(subject).ToList()
            };
        }

        private IEnumerable<AppraisalDto> Map(IEnumerable<StudentSkill> skill)
        {
            return skill.Select(Map);
        }
        private AppraisalDto Map(StudentSkill studentSkill)
        {
            if (studentSkill == null)
            {
                throw new ArgumentNullException(nameof(studentSkill));
            }

            return new AppraisalDto
            {
                Correct = studentSkill.Correct,
                ExcerciseId = studentSkill.ExerciseId,
                Domain = studentSkill.Domain,
                LearningObjective = studentSkill.LearningObjective
            };
        }
    }
}