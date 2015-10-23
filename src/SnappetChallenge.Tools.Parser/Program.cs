using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SnappetChallenge.Infrastructure.DataAccess;
using SnappetChallenge.Domain.Entities;

namespace SnappetChallenge.Tools.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = Console.LargestWindowWidth / 2;
            Console.WindowHeight = Console.LargestWindowHeight / 2;

            string dataPath = "work.json";
            var data = ParseData(dataPath);


            CreateDatabase(data);

            Console.Write(Environment.NewLine);
            Console.WriteLine("Press a key to quit");
            Console.ReadKey();
        }

        private static void CreateDatabase(IList<SnappetChallengeRecord> data)
        {
            var subjects =
                (
                    from record in data
                    group record by record.Subject
                    into grp
                    select new Subject { Description = grp.Key }
                ).ToList();

            var domains =
                (
                   from record in data
                   group record by new { record.Subject, record.Domain }
                   into grp
                   select new Domain.Entities.Domain { Description = grp.Key.Domain, Subject = subjects.FirstOrDefault(s => s.Description == grp.Key.Subject) }
                ).ToList();

            // Include subject in the group by, because domain name is not guaranteed to be unique  
            var objectives =
                (
                    from record in data
                    group record by new { record.Subject, record.Domain, record.LearningObjective }
                    into grp
                    select new LearningObjective
                    {
                        Description = grp.Key.LearningObjective,
                        Domain = domains.FirstOrDefault(d => d.Description == grp.Key.Domain && d.Subject.Description == grp.Key.Subject)
                    }
                ).ToList();

            var exercises =
                (
                    from record in data
                    group record by new { record.LearningObjective, record.ExerciseId }
                    into grp
                    select new Exercise
                    {
                        Difficulty = grp.First().Difficulty,
                        LearningObjective = objectives.FirstOrDefault(o => o.Description == grp.Key.LearningObjective),
                        ExternalId = grp.First().ExerciseId
                    }
                ).ToList();

            int i = 0;

            var users =
                (
                    from record in data
                    group record by new { record.UserId }
                    into grp
                    select new User
                    {
                        ExternalId = grp.Key.UserId,
                        Name = names[i++]
                    }
                )
                .ToList();



            var submittedAnswers =
                (
                    from record in data
                    group record by new { record.ExerciseId, record.SubmittedAnswerId, record.UserId }
                    into grp
                    select new SubmittedAnswer
                    {
                        IsCorrect = grp.First().Correct,
                        SubmittedOn = grp.First().SubmitDateTime,
                        Progress = grp.First().Progress,
                        Exercise = exercises.First(e => e.ExternalId == grp.Key.ExerciseId),
                        SubmittedBy = users.First(u => u.ExternalId == grp.Key.UserId)
                    }
                )
                .ToList();

            // for the sake of brevity I'm skipping the dependency inversion here
            using (var context = new SnappetChallengeContext())
            {
                context.GetRepository<Subject>().AddRange(subjects);
                context.GetRepository<Domain.Entities.Domain>().AddRange(domains);
                context.GetRepository<LearningObjective>().AddRange(objectives);
                context.GetRepository<Exercise>().AddRange(exercises);
                context.GetRepository<User>().AddRange(users);
                context.GetRepository<SubmittedAnswer>().AddRange(submittedAnswers);

                context.Commit();
            }

            Console.WriteLine("Database created succesfully");
        }

        private static string[] names = new string[] {
                "Tyrion Lannister",
                "Cersei Lannister",
                "Daenerys Targaryen",
                "Jon Snow",
                "Sansa Stark",
                "Arya Stark",
                "Jorah Mormont",
                "Jaime Lannister",
                "Samwell Tarly",
                "Theon Greyjoy",
                "Petyr Baelish",
                "Brienne of Tarth",
                "Tywin Lannister",
                "Sandor Clegane",
                "Joffrey Baratheon",
                "Catelyn Stark",
                "Stannis Baratheon",
                "Robb Stark",
                "Margaery Tyrell",
                "Davos Seaworth"
            };

        private static void PrintDataAnalysis(IList<SnappetChallengeRecord> data)
        {
            var recordsBySubject = data.GroupBy(record => record.Subject);
            var recordsByDomain = data.GroupBy(record => record.Domain);
            var recordsByObjective = data.GroupBy(record => record.LearningObjective);
            var recordsByExercise = data.GroupBy(record => record.ExerciseId);
            var recordsByUser = data.GroupBy(record => record.UserId);

            Console.WriteLine("Number of subjects: \t\t\t{0}", recordsBySubject.Count());
            Console.WriteLine("Number of domains: \t\t\t{0}", recordsByDomain.Count());
            Console.WriteLine("Number of objectives: \t\t\t{0}", recordsByObjective.Count());
            Console.WriteLine("Number of exercises: \t\t\t{0}", recordsByExercise.Count());
            Console.WriteLine("Number of users: \t\t\t{0}", recordsByUser.Count());
            Console.WriteLine("Number of submitted answers: \t\t{0}", data.Count);
            Console.Write(Environment.NewLine);

            Console.WriteLine("Subjects");

            foreach (var subject in recordsBySubject)
            {
                Console.WriteLine("\t{0}", subject.Key);
                Console.WriteLine("\t\tDomains");

                var domains = recordsByDomain.Where(r => r.Any(p => p.Subject == subject.Key));

                foreach (var domain in domains)
                {
                    Console.WriteLine("\t\t\t {0}", domain.Key);

                    var objectives = recordsByObjective.Where(r => r.Any(p => p.Domain == domain.Key));
                    
                    foreach (var objective in objectives)
                    {
                        var exercises = recordsByExercise.Where(r => r.Any(p => p.LearningObjective == objective.Key));
                        Console.WriteLine("\t\t\t\t {0} ({1} exercises)", objective.Key, exercises.Count());

                    }
                }
            }

            Console.Write(Environment.NewLine); 
        }
     
        private static IList<SnappetChallengeRecord> ParseData(string dataPath)
        {
            string contents = File.ReadAllText(dataPath);

            var settings = new JsonSerializerSettings() { Error = Error };
            var list = JsonConvert.DeserializeObject<List<SnappetChallengeRecord>>(contents, settings);

            return list;
        }

        private static int errorCount = 0;
        private static void Error(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorEventArgs)
        {
            // Let's pretend nothing happened
            errorEventArgs.ErrorContext.Handled = true;
            errorCount++;
        }
    }
}