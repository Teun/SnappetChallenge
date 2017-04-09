using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBoard.Dal.Data;
using TutorBoard.Dal.Models;

namespace TutorBoard.Dal.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IDataContext _dataContext;

        public SubjectRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <inheritdoc />
        public Task<IEnumerable<Subject>> GetAsync()
        {
            return Task.FromResult<IEnumerable<Subject>>(_dataContext.GetWorkData()
                .AsParallel()
                .Select(w => w.Subject)
                .Distinct()
                .OrderBy(s => s)
                .Select(s => new Subject { Label = s})
                .ToList());
        }
    }
}
