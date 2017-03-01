using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace SnappetChallenge.Models
{
    public class StudyContext:DbContext
    {
        public StudyContext(DbContextOptions<StudyContext> options)
            :base(options)
        {
        }
        public DbSet<User> Users{ get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Exercise> Excerises { get; set; }
        public DbSet<LearningObjective> LearningObjectives { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public async Task SyncWithData()
        {
            JArray data = JArray.Parse(File.ReadAllText(@"Data\work.json"));

            await Users.AddRangeAsync(data.Children<JObject>()["UserId"]
                .Values<string>().Distinct()
                .Select(user => new User() { Id = user }));

            await Subjects.AddRangeAsync(data.Children<JObject>()["Subject"]
                .Values<string>().Distinct()
                .Select(subject => new Subject() { Name = subject }));
            await SaveChangesAsync();

            await Subjects.ForEachAsync(subject =>
            {
                subject.Domains = data.Children<JObject>()
                    .Where(answer => answer["Subject"].ToString() == subject.Name)
                    .AsJEnumerable()["Domain"].Values<string>().Distinct()
                    .Select(domain => new Domain() { Name = domain }).ToList();
            });
            await SaveChangesAsync();

            await Domains.ForEachAsync(domain =>
           {
               domain.LearningObjectives = data.Children<JObject>()
                   .Where(answer => answer["Domain"].ToString() == domain.Name 
                        && answer["Subject"].ToString() == domain.Subject.Name)
                   .AsJEnumerable()["LearningObjective"].Values<string>().Distinct()
                   .Select(learningObjective => new LearningObjective() { Name = learningObjective }).ToList();
           });
            await SaveChangesAsync();

            await LearningObjectives.ForEachAsync(learningObjective =>
            {
                learningObjective.Exercises = data.Children<JObject>()
                    .Where(answer => answer["LearningObjective"].ToString() == learningObjective.Name)
                    .AsJEnumerable()
                    .GroupBy(exercise=>exercise["ExerciseId"])
                    .Select(group=>group.First())
                    .Select(exercise => new Exercise()
                    {
                        Id = exercise["ExerciseId"].ToString(),
                        Difficulty = exercise["Difficulty"].ToString() != "NULL" ? exercise["Difficulty"].Value<double>() : default(double?)
                    }).ToList();
            });
            await SaveChangesAsync();

            Answer[] answers = new Answer[data.Children().Count()];

            Parallel.For(0, answers.Length, index => answers[index] = new Answer()
            {
                UserId = data[index]["UserId"].ToString(),
                ExerciseId = data[index]["ExerciseId"].ToString(),
                Correct = data[index]["Correct"].Value<bool>(),
                Id = data[index]["SubmittedAnswerId"].ToString(),
                SubmitedDate = DateTime.Parse(data[index]["SubmitDateTime"].Value<string>() + 'Z').ToUniversalTime(),
                Progress = data[index]["Progress"].Value<int>(),
            });
            await Answers.AddRangeAsync(answers);
            await SaveChangesAsync();
        }
    }
}
