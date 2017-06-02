using System;
using System.Collections.Generic;
using SnappetChallenge.DAL.Data;

namespace SnappetChallenge.DAL.Services.Contracts
{
    public interface IProgressService
    {
        IEnumerable<AssignmentProgress> GetAssignments(DateTime fromDate, DateTime toDate);

        IEnumerable<SubjectProgress> GetGetSubjects(DateTime fromDate, DateTime toDate);
    }
}