using Snappet.Domain.Interface;
using Snappet.Domain.Models;
using System;
using System.Collections.Generic;

namespace Snappet.Test.Mocks
{
    public class DbContextMock : ISnappetDbContext
    {
        private const int UserId = 543;
        public DbContextMock()
        {

            ExerciseReports = new List<ExerciseReportModel>
            {
                new ExerciseReportModel{Progress = 1, UserId = UserId, SubmitDateTime = new DateTime(2015, 2,11)},
                new ExerciseReportModel{Progress = -2, UserId = UserId, SubmitDateTime = new DateTime(2015, 2,11)},
                new ExerciseReportModel{Progress = 3, UserId = UserId, SubmitDateTime = new DateTime(2015, 2,11)},
                new ExerciseReportModel{Progress = 44, UserId = UserId, SubmitDateTime = new DateTime(2015, 2,11)},
                new ExerciseReportModel{Progress = -5, UserId = UserId, SubmitDateTime = new DateTime(2015, 2,11)},
                new ExerciseReportModel{Progress = -50, UserId = UserId, SubmitDateTime = new DateTime(2016, 2,11)},
                new ExerciseReportModel{Progress = 22, UserId = UserId, SubmitDateTime = new DateTime(2012, 2,11)},
                new ExerciseReportModel{Progress = 4, UserId = UserId, SubmitDateTime = new DateTime(2018, 2,11)},

            };
        }
    }
}
