using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using TeacherApp.Models;

namespace TeacherApp.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(string jsonData, IApplicationBuilder app)
        {
            TeacherAppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<TeacherAppDbContext>();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };

            List<Work> workData = JsonConvert.DeserializeObject<List<Work>>(jsonData, settings);


            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

			if (!context.Works.Any())
            {
                // Populate Works table.
				context.Works.AddRange(workData);
				context.SaveChanges();
            }


            if (!context.Students.Any())
            {
                // Group students' work.
                var distinctStudentWork = workData.GroupBy(w => w.UserId).Select(id => id.First()).ToList();

                // Populate Students table.
                List<Student> studentData = new List<Student>();
                distinctStudentWork
                    .Select((work, index) => new { work.UserId, index })
                    .ToList()
                    .ForEach((value) => studentData.Add(new Student { 
                        StudentId = value.UserId, Name = $"Student{value.index}" 
                    }));

				context.Students.AddRange(studentData);
				context.SaveChanges();
			}
        }
    }
}
