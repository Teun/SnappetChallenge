﻿using Snappet.Domain.Interface;
using Snappet.Domain.Models;

namespace Snappet.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private List<ExerciseReportModel> previousReports = new List<ExerciseReportModel>();

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Begin()
        {
            previousReports = new List<ExerciseReportModel>(_dbContext.ExerciseReports);
        }

        public void Commit()
        {
            // nothing to do
        }

        public void Rollback()
        {
            ((List<ExerciseReportModel>)_dbContext.ExerciseReports).RemoveRange(0, _dbContext.ExerciseReports.Count());
            ((List<ExerciseReportModel>)_dbContext.ExerciseReports).AddRange(previousReports);
        }
        public void Dispose()
        {
            Rollback();
        }

    }
}