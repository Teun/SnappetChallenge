using Snappet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Model;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Snappet.Repository.Implementation.Base;

namespace Snappet.Repository.Implementation
{
    public class LearningObjectiveRepository : BasicRepository<LearningObjective>, ILearningObjectiveRepository
    {
        public LearningObjectiveRepository(SnappetContext SnappetContext)
            : base(SnappetContext, SnappetContext.LearningObjectives)
        {
            
        }

        public async Task<List<Model.DTO.ProgressPerLearningObjective>> GetProgress(int classID, int userId)
        {
            var progress =
                from answer in SnappetContext.Answers
                join lo in SnappetContext.LearningObjectives on answer.LearningObjectiveID equals lo.ID
                where answer.ClassId == classID && answer.UserId == userId
                group answer by new { Name = lo.Name, Progress = answer.Progress } into grp
                select new Model.DTO.ProgressPerLearningObjective
                {
                    objName = grp.Key.Name,
                    AverageProgress = grp.Average(a => a.Progress)
                };

            return await progress.ToListAsync();
        }
    }
}
