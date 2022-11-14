using SnappetChallengAPI.Model;
using SnappetChallengAPI.Helper;
using System.Text.Json;

namespace SnappetChallengAPI.Repository
{
    public class StudentRepository
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public StudentRepository(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public List<Student> LoadStudents()
        {
            try
            {

                var rootPath = _hostingEnvironment.ContentRootPath;

                var fullPath = Path.Combine(rootPath, "Data/work.json");

                var jsonData = System.IO.File.ReadAllText(fullPath);

                if (string.IsNullOrWhiteSpace(jsonData)) return null;

                var options = new JsonSerializerOptions();
                options.Converters.Add(new CustomDateTimeConverter());

                return JsonSerializer.Deserialize<List<Student>>(jsonData, options);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
