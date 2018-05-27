using Microsoft.EntityFrameworkCore;
using SnappetChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Providers
{
    public class SnappetDbContext : DbContext
    {
        public DbSet<WorkData> WorkDataSet { get; set; }

        public SnappetDbContext(DbContextOptions<SnappetDbContext> options, IWorkDataProvider dataProvider = null) : base(options)
        {
            if (Database.IsInMemory() && dataProvider != null && !WorkDataSet.Any())
            {
                InitilizeInMemoryData(dataProvider.GetDefaultWorkData().Result);
            }
        }

        /// <summary>
        /// Inserts default data to the underlying <see cref="DbContext"/> 
        /// </summary>
        /// <param name="data"></param>
        private void InitilizeInMemoryData(IEnumerable<WorkData> data)
        {
            WorkDataSet.AddRange(data);
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkData>(x => x.HasKey(y => y.SubmittedAnswerId));
        }
    }
}
