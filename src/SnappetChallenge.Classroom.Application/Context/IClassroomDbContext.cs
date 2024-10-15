using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SnappetChallenge.Classroom.Domain.Models;

namespace SnappetChallenge.Classroom.Application.Context;

public interface IClassroomDbContext
{
    DbSet<StudentProgress> StudentProgress { get; set; }
    
    DatabaseFacade Database { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}