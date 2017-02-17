using WorkDataService.Models;

namespace WorkDataService.Services{
    public interface IStudentFactory{
        Student Create(WorkItem workItem);
    }

    public class StudentFactory: IStudentFactory{

        public Student Create(WorkItem workItem){
            return new Student{

            };
        }
    }
}