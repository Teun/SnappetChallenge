using System.Collections.Generic;
using System.Threading.Tasks;
using TutorBoard.Dal.Models;

namespace TutorBoard.Dal.Repositories
{
    public interface ISubjectRepository
    {
        /// <summary>
        /// Returns all existing subjects
        /// </summary>
        /// <returns>List of subjects</returns>
        Task<IEnumerable<Subject>> GetAsync();
    }
}
