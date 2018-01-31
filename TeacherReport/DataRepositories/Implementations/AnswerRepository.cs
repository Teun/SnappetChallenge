﻿using System;
using System.Collections.Generic;

using DataRepositories.Data.DailySummary;
using DataRepositories.Interfaces;

namespace DataRepositories.Implementations
{
    /// <summary>
    /// Implements the answer repository
    /// </summary>
    public class AnswerRepository : IAnswerRepository
    {
        public List<DailyStudentSummary> GetDailyStudentSummary(DateTime summaryDateTime)
        {
            throw new NotImplementedException();
        }
    }
}