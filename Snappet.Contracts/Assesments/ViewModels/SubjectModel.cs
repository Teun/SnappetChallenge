using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Assesments.ViewModels
{
    public class SubjectModel
    {
        public string Subject { get; set; }
        public List<StudentModel> Users { get; set; }
    }
}
