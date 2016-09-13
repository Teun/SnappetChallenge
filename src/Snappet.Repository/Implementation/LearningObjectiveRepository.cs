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
    }
}
