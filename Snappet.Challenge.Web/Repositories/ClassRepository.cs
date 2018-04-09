using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.Challenge.Web.Core.Models;
using Snappet.Challenge.Web.Data;
using Snappet.Challenge.Web.Helpers;

namespace Snappet.Challenge.Web.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly IContext _context;

        public ClassRepository(IContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Work> GetWorkByDate(DateTime? date)
        {
            date = date ?? new DateTime().NowAtSnappet();
            
            return _context.Data
                .Where(w => w.SubmitDateTime.Date == date.Value.Date)
                .OrderBy(w => w.UserId)
                .ThenByDescending(w => w.SubmitDateTime);
        }

        public IEnumerable<Work> GetWorkByUser(int? userId)
        {
            return _context.Data
                .Where(w => w.UserId == (userId ?? w.UserId))
                .OrderByDescending(w => w.SubmitDateTime);
        }
        
        public IEnumerable<Work> GetWorkByUser(int userId, int pageIndex, int pageSize)
        {
            return _context.Data
                .Where(w => w.UserId == userId)
                .OrderByDescending(w => w.SubmitDateTime)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<Summary> GetUserWorkSummarizedByDate(DateTime date)
        {
            var workList = GetWorkByDate(date);
            
            return workList
                .GroupBy(w => w.UserId)
                .Select(g => new Summary
                {
                    UserId = g.Key,
                    Date = date,
                    Correct = g.Count(s => s.Correct),
                    Wrong = g.Count(s => !s.Correct)
                })
                .OrderByDescending(s => s.Ratio)
                .ToList();
        }

        public Summary GetAllWorkSummirazedByDate(DateTime date)
        {
            var workList = GetWorkByDate(date).ToList();

            return new Summary
            {
                Date = date,
                Correct = workList.Count(w => w.Correct),
                Wrong = workList.Count(w => !w.Correct)
            };
        }

        public IEnumerable<Summary> GetUserWorkHistoryByObjective(int userId)
        {
            var workList = GetWorkByUser(userId).ToList();

            return workList
                .GroupBy(w => new  { w.SubmitDateTime.Date, w.LearningObjective })
                .Select(g => new Summary
                {
                    UserId = userId,
                    Date = g.Key.Date,
                    LearningObjective = g.Key.LearningObjective,
                    Correct = g.Count(s => s.Correct),
                    Wrong = g.Count(s => !s.Correct)
                })
                .OrderByDescending(s => s.Date)
                .ThenBy(s => s.LearningObjective)
                .ToList();
        }
    }
}