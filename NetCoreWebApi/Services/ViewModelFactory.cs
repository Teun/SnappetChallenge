using SnappetWorkApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace SnappetWorkApp.Services{
    public interface IViewModelFactory{
        IEnumerable<Student> CreateStudents(IEnumerable<WorkItem> workItems);
        StudentWork CreateStudentWork(IEnumerable<WorkItem> studentWorkItems);
        Subject CreateSubjectViewModel(IEnumerable<WorkItem> subjectWorkItems);
    }

    public class ViewModelFactory: IViewModelFactory{

        public IEnumerable<Student> CreateStudents(IEnumerable<WorkItem> workItems)
        {
            foreach(var studentItems in workItems.GroupBy(i => i.UserId))
            {
                yield return new Student{
                    Id = studentItems.Key,
                    TotalProgress = studentItems.Sum(i => i.Progress),
                    AverageDifficulty = studentItems.Where(i => i.Difficulty != "NULL").Average(i =>  double.Parse(i.Difficulty))
                };
            }
        }

        public StudentWork CreateStudentWork(IEnumerable<WorkItem> studentWorkItems)
        {
            return new StudentWork{
                StudentId = studentWorkItems.First().UserId,
                Subjects = studentWorkItems.GroupBy(wi => wi.Subject).Select(wig => new Subject{
                    Name = wig.Key,
                })
            };
        }

        public Subject CreateSubjectViewModel(IEnumerable<WorkItem> subjectWorkItems)
        {
            return new Subject{
                Name = subjectWorkItems.First().Subject,
                Domains = subjectWorkItems.GroupBy(wi => wi.Domain).Select(wig => new Domain{
                    Name = wig.Key
                })
            };
        }
    }
}