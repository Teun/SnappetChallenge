using Microsoft.EntityFrameworkCore;
using WorkDataService.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkDataService{
    public class WorkDataContext : DbContext
    {
        private List<WorkItem> _workItems = new List<WorkItem>();

        public WorkDataContext()
        {   
             using(var sr = System.IO.File.OpenText(@"Data\work.json"))
             {
                _workItems = JsonConvert.DeserializeObject<List<WorkItem>>(sr.ReadToEnd());
             }

             WorkItems.AddRange(_workItems);

             this.SaveChanges();
        }
        public WorkDataContext(DbContextOptions<WorkDataContext> options) : base(options)
        {
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