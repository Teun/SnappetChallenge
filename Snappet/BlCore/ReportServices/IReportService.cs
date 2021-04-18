using System;
using BlCore.ReportServices.Models;

namespace BlCore.ReportServices
{
    public interface IReportService
    {
        ObjectivesReport GetObjectivesReport(DateTime begin, DateTime end);

        OneUserReport GetOneUserReport(int userId, DateTime begin, DateTime end);

        UsersReport GetUsersReport(DateTime begin, DateTime end);

        OneObjectiveReport GetOneObjectiveReport(string objective, DateTime begin, DateTime end);
    }
}
