using Snappet.Contracts.Assesments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Assesments.ViewModels
{
    public class ClassModel
    {
        public int Id { get; set; }        
        public string Period { get; set; }            
        public List<StudentModel> StudentsModel { get; set; }
        public IEnumerable<string> Subjects { get; set; }
        public DateTime CurrentDate { get; set; }
        public string PreviousResultType { get; set; }

        public ClassModel()
        {            
            StudentsModel = new List<StudentModel>();
        }
    }
}
