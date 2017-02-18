using SnappetWorkApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace SnappetWorkApp.Services{
    public interface IViewModelFactory{
        IEnumerable<Student> CreateStudents(IEnumerable<WorkItem> workItems);
        Student CreateStudentWork(IEnumerable<WorkItem> studentWorkItems);
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

        public Student CreateStudentWork(IEnumerable<WorkItem> workItems)
        {
            return new Student{
                Id = workItems.First().UserId,
                TotalProgress = workItems.Sum(i => i.Progress),
                AverageDifficulty = workItems.Where(i => i.Difficulty != "NULL").Average(i =>  double.Parse(i.Difficulty)),
                Subjects = workItems.GroupBy(wi => wi.Subject).Select(wig => new Subject{
                    Name = wig.Key,
                    TotalProgress = wig.Sum(i => i.Progress),
                    AverageDifficulty = wig.Where(i => i.Difficulty != "NULL").Average(i =>  double.Parse(i.Difficulty))
                })
            };
        }

        public Subject CreateSubjectViewModel(IEnumerable<WorkItem> workItems)
        {
            return new Subject{
                Name = workItems.First().Subject,
                TotalProgress = workItems.Sum(i => i.Progress),
                AverageDifficulty = workItems.Where(i => i.Difficulty != "NULL").Average(i =>  double.Parse(i.Difficulty)),
                Domains = workItems.GroupBy(wi => wi.Domain).Select(wig => new Domain{
                    Name = wig.Key,
                    TotalProgress = wig.Sum(i => i.Progress),
                    AverageDifficulty = wig.Where(i => i.Difficulty != "NULL").Average(i =>  double.Parse(i.Difficulty))
                })
            };
        }
    }
}