namespace SnappetChallenge.DAL.DataImport
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Collections.Generic;
    using EntityFramework.BulkInsert.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Entities;

    /// <summary>
    /// Import strategy:
    /// - The source JSON has been added "as is" as an embedded resource.
    /// - Read this embedded resource from assembly into stream
    /// - Read and process the JSON objects 1 by 1 and build the object tree
    /// - Use the EF extension BulkInsert to insert this tree at once in the database
    ///   See https://www.nuget.org/packages/EntityFramework.BulkInsert-ef6/
    /// 
    /// Cons:
    /// - Only works for relatively small JSON source file's, we're not going to embed GB's of data
    /// - Manual mapping of JSON object feels a bit ugly, but cannot auto-deserialize because of exceptions in data
    /// </summary>
    public sealed class NewtonSoftJsonImporter : BaseImporter
    {
        public override void Import(SnappetChallengeContext context)
        {
            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "SnappetChallenge.DAL.DataImport.work.json";  // serialized JSON is embedded resource
            var itemsToInsert = new List<StudentAnswer>();

            using (var streamFromEmbeddedResource = assembly.GetManifestResourceStream(resourceName))
            using (var sr = new StreamReader(streamFromEmbeddedResource))
            using (var reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    if (reader.TokenType != JsonToken.StartObject) continue;
                    var obj = JObject.Load(reader);

                    var studentAnswer = new StudentAnswer
                    {
                        Correct = obj["Correct"].Value<int>() == 1, // explicit cast to bool
                        DateAdded = DateTime.Now,
                        Difficulty =
                            obj["Difficulty"].Value<string>().Equals("NULL") // handle weird NULL values, they serialize as string "NULL"
                                ? null
                                : obj["Difficulty"].Value<double?>(),
                        Domain = obj["Domain"].Value<string>(),
                        ExerciseId = obj["ExerciseId"].Value<long>(),
                        LearningObjective = obj["LearningObjective"].Value<string>(),
                        Progress = obj["Progress"].Value<int>(),
                        Subject = obj["Subject"].Value<string>(),
                        SubmitDateTime = obj["SubmitDateTime"].Value<DateTime>(),
                        SubmittedAnswerId = obj["SubmittedAnswerId"].Value<long>(),
                        UserId = obj["UserId"].Value<long>(),
                        Id = obj["SubmittedAnswerId"].Value<long>() // this is doubled in SubmittedAnswerId..
                    };

                    itemsToInsert.Add(studentAnswer);
                }
            }
            context.BulkInsert(itemsToInsert);
            context.SaveChanges();
        }
    }
}
