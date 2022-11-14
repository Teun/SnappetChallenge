using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetChallenge.Client
{
    static class Constants
    {
        public const string DevelopmetEnvironmentBaseUrl = "http://localhost:5226/api/";
        public const string ProductionEnvironmentBaseUrl = "https://snappetchallenge.azurewebsites.net/api/";

        public const string StudentTodayStatisticalReportApiUrl = "Student/GetTodayStatisticalReport";
        public const string StudentFilterApiUrl = "Student/GetFilteredStudents";
        public const string GetSubjects = "Student/GetSubjects";
        public const string GetDomains = "Student/GetDomains";


    }
}
