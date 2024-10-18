using SnappetChallenge.Models;

namespace SnappetChallenge.Repositories
{
    public interface IWorkRepository
    {
        public Task<List<WorkModel>> GetAllStudentWork(string filePath);
    }
}