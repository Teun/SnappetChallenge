using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snappet.WebAPI.Core.Repositories;

namespace Snappet.WebAPI.Persistence.Repositories
{
    public class WorkRepository : Repository<Models.Work>, IWorkRepository
    {        
        public WorkRepository(SnappetContext context)
            : base(context)
        {

        }

        public SnappetContext SnappetContext
        {
            get { return Context as SnappetContext; }
        }
    }
}