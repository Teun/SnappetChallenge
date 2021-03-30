using Service.Students.Models;
using System.Collections.Generic;

namespace Service.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdServiceResponse
    {
        public List<StudentOverviewModel> Items { get; set; }
    }
}
