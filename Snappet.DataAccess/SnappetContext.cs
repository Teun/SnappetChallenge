using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Snappet.DataAccess.Entities;


namespace Snappet.DataAccess
{
   
       
        public class SnappetContext : DbContext
        {
            public SnappetContext()
                : base("name=SnappetEntities")
            {
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            Database.SetInitializer<SnappetContext>(null);
        }

            public virtual DbSet<ExerciseResultEntity> ExerciseResults { get; set; }
        public virtual DbSet<DomainEntity> Domains { get; set; }
        public virtual DbSet<SubjectEntity> Subjects { get; set; }
        public virtual DbSet<LearningObjectiveEntity> LearningObjectives { get; set; }

        public virtual IEnumerable<UserEntity> GetUsers(DateTime startTime, DateTime endTime, int domainId)
        {
            var startDateParam= new SqlParameter("startDate", startTime);
            var endDateParam = new SqlParameter("endDate", endTime);

            var domainIdParam = new SqlParameter("domainId", domainId);

            return this.Database.SqlQuery<UserEntity>("sp_getUsers @startDate, @endDate, @domainId",
                startDateParam,endDateParam, domainIdParam);
        }
    }
    }

