using System.Collections.Generic;
using System.Threading.Tasks;
using RReporter.Application.Domain;

namespace RReporter.Application.ReportWorkSummary.Depends
{
    public interface IGetPupilsInClass
    {
        Task<IEnumerable<Pupil>> GetPupilsInClassAsync (int classId);
    }
}