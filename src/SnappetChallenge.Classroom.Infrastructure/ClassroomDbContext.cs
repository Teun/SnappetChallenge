using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SnappetChallenge.Classroom.Application.Context;
using SnappetChallenge.Classroom.Domain.Models;

namespace SnappetChallenge.Classroom.Infrastructure;

public partial class ClassroomDbContext(DbContextOptions<ClassroomDbContext> options) : DbContext(options), IClassroomDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<StudentProgress>().HasKey(p => p.Id);
        modelBuilder.Entity<StudentProgress>().Property(p => p.Id).ValueGeneratedOnAdd();
        
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        var json =  File.ReadAllText("Data/work.json");
        var students = JsonConvert.DeserializeObject<List<StudentProgress>>(json);
        // Add manual PK value, as identity insert seems to fail on inmemory db
        var index = 1;
        
        students.ForEach(c =>
        {
            c.Id = index++;
        });

        modelBuilder.Entity<StudentProgress>().HasData(students.ToArray());
    }

    public DbSet<StudentProgress> StudentProgress { get; set; }
}

