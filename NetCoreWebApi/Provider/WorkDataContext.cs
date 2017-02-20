using Microsoft.EntityFrameworkCore;
using SnappetWorkApp.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace SnappetWorkApp{
    public class WorkDataContext : DbContext
    {
        private List<WorkItem> _workItems = new List<WorkItem>();

        public WorkDataContext(DbContextOptions<WorkDataContext> options) : base(options)
        {
            if(WorkItems.Any()) return;

            using(var sr = System.IO.File.OpenText(@"Data\work.json"))
            {
                _workItems = JsonConvert.DeserializeObject<List<WorkItem>>(sr.ReadToEnd());
            }

            WorkItems.AddRange(_workItems);

            this.SaveChanges();   
        }

        public DbSet<WorkItem> WorkItems {get;set;}
    }
}