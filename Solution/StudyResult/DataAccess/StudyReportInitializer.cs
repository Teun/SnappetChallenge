using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using StudyReport.Entities;

namespace StudyReport.DataAccess
{
    public class StudyReportInitializer : CreateDatabaseIfNotExists<StudyReportContext>
    {
        protected override void Seed(StudyReportContext ctx)
        {
             //Load source file
            string file = HttpContext.Current.Server.MapPath("~/App_Data/work.json");
            using (StreamReader sr = File.OpenText(file))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                var serializer = new JsonSerializer();
                var entries = serializer.Deserialize<List<WorkModel>>(reader);

                ctx.WorkModel.AddRange(entries);
                ctx.SaveChanges();
            }

            StudyReportParser parser = new StudyReportParser(ctx);
            parser.ParseSubjects();
            parser.ParseDomains();
            parser.ParseLearningObjects();
            parser.ParseExercies();
            parser.ParseUsers();
            parser.ParseAnswers();            

            base.Seed(ctx);
        }
    }
}