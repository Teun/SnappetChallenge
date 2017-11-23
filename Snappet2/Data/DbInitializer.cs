using Newtonsoft.Json;
using Snappet2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet2.Data
{
    public class DbInitializer
    {
        public static void Initialize(SnappetContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.SubmittedAnswers.Any())
            {
                return;   // DB has been seeded
            }


            using (StreamReader sr = File.OpenText("work.json"))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                reader.SupportMultipleContent = true;
                var serializer = new JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        SubmittedAnswer submittedAnswer = serializer.Deserialize<SubmittedAnswer>(reader);
                        context.SubmittedAnswers.Add(submittedAnswer);
                    }
                }
            }
            //context.SubmittedAnswers.RemoveRange(context.SubmittedAnswers);
            //var submittedAnswers = new List<SubmittedAnswer>
            //{
            //    new SubmittedAnswer{SubmittedAnswerId=1,
            //        SubmitDateTime=DateTime.Parse("2005-09-01"),
            //        Correct = 3,
            //        Progress = 0,
            //        UserId = 40281,
            //        ExerciseId = 1038396,
            //        Difficulty = -200,
            //        Subject = "Science",
            //        Domain = "-",
            //        LearningObjective = "Diverse leerdoelen Begrijpend Lezen"
            //    },
            //    new SubmittedAnswer{SubmittedAnswerId=2,
            //        SubmitDateTime=DateTime.Parse("2005-09-01"),
            //        Correct = 0,
            //        Progress = 0,
            //        UserId = 40282,
            //        ExerciseId = 103839,
            //        Difficulty = -200,
            //        Subject = "Science",
            //        Domain = "-",
            //        LearningObjective = "Diverse leerdoelen Begrijpend Lezen"
            //    },
            //    new SubmittedAnswer{SubmittedAnswerId=3,
            //        SubmitDateTime=DateTime.Parse("2005-09-02"),
            //        Correct = 1,
            //        Progress = 0,
            //        UserId = 40281,
            //        ExerciseId = 1038397,
            //        Difficulty = -200,
            //        Subject = "Science",
            //        Domain = "-",
            //        LearningObjective = "Diverse leerdoelen Begrijpend Lezen"
            //    },
            //    new SubmittedAnswer{SubmittedAnswerId=4,
            //        SubmitDateTime=DateTime.Parse("2005-09-02"),
            //        Correct = 1,
            //        Progress = 0,
            //        UserId = 40282,
            //        ExerciseId = 1038397,
            //        Difficulty = -200,
            //        Subject = "Science",
            //        Domain = "-",
            //        LearningObjective = "Diverse leerdoelen Begrijpend Lezen"
            //    }
            //};
            //submittedAnswers.ForEach(s => context.SubmittedAnswers.Add(s));
            context.SaveChanges();
        }
    }
}
