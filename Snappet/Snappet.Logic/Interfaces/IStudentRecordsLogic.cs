using Snappet.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Logic
{
    public interface IStudentRecordsLogic
    {
        IEnumerable<StudentProgressRecord> GetRecords(DateTime date);
        void GetProgressDetails(int studentID, DateTime from, DateTime to, 
            out List<double> daysProgress, out List<double> daySuccessRate);
    }
}
