using System;
using System.Collections.Generic;
using System.Linq;
using SnappetWorkApp.Models;
using SnappetWorkApp.Services;

namespace SnappetWorkApp.Repositories
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetAllStudentsForDate(DateTime date);

        Student GetStudentByIdForDate(int id, DateTime date);
    }

    public class StudentsRepository : IStudentsRepository
    {
        WorkDataContext _workDataContext;
        IViewModelFactory _viewModelFactory;

        public StudentsRepository(WorkDataContext workdataContext, IViewModelFactory viewModelFactory)
        {
            _workDataContext = workdataContext;
            _viewModelFactory = viewModelFactory;
        }

        public IEnumerable<Student> GetAllStudentsForDate(DateTime date)
        {
            var workItems = _workDataContext.WorkItems.Where(wi => wi.SubmitDateTime.Date == date);

            return _viewModelFactory.CreateStudents(workItems);
        }

        public Student GetStudentByIdForDate(int id, DateTime date)
        {
            var workItems = _workDataContext.WorkItems.Where(wi => wi.UserId == id && wi.SubmitDateTime.Date == date);
            
            return _viewModelFactory.CreateStudentWork(workItems);
        }
    }
}