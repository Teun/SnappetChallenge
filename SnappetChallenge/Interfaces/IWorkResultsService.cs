using SnappetChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Interfaces
{
    public interface IWorkResultsService
    {
        /// <summary>
        /// Retrieve all students results
        /// </summary>
        /// <returns>List of WorkResultModel</returns>
        List<WorkResultModel> GetAllResults();

        /// <summary>
        /// Retrieve students results for particular day
        /// </summary>
        /// <returns>List of WorkResultModel</returns>
        List<WorkResultModel> GetResultsByDay(DateTime date);
    }
}
