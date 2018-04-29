using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Assesments.ViewModels
{
    public class SubjectModel
    {
        public string Subject { get; set; }

        public double Result { get; set; }

        public SubjectModel(string subject, double result)
        {
            Subject = subject;
            Result = result;
        }
    }
}
