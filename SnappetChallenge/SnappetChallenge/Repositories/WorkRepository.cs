using SnappetChallenge.Models;
using SnappetChallenge.Services;

namespace SnappetChallenge.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        public async Task<List<WorkModel>> GetAllStudentWork(string filePath)
        {
            CSVReader<WorkModel> workCSVReader = new CSVReader<WorkModel>();
            var csvTaskResults = await workCSVReader.ReadCSV(filePath);
            var filteredRows = csvTaskResults.Where(r => r.SubmitDateTime <= GlobalDateTime.CurrentDateTime).ToList();
            
            return filteredRows;
        }
    }
}