using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Snappet.Web.Persistence.Models;

namespace Snappet.Web.Persistence
{
    public static class DataSeeder
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var db = app.ApplicationServices.GetRequiredService<SnappetDbContext>())
            {
                if (!db.SubmittedAnswers.Any())
                {
                    var submitedAnswers = JsonConvert.DeserializeObject<List<SubmittedAnswer>>(File.ReadAllText("work.json"));
                
                    db.SubmittedAnswers.AddRange(submitedAnswers);

                    db.Reports.AddRange(new List<Report>()
                    {
                        new Report()
                        {
                            DisplayName = "On what my class have worked on today",
                            StorageProcedure = "Reporting_OnWhatMyClassHaveWorkedOnToday",
                            ReportConfiguration = new ReportConfiguration()
                            {
                                Parameters = new List<ReportParameter>()
                                {
                                    new ReportParameter()
                                    {
                                        Name = "dateFrom",
                                        Type = "datetime"
                                    }
                                }
                            }
                        },
                        new Report()
                        {
                            DisplayName = "My Class Daily Results",
                            StorageProcedure = "Reporting_MyClassDailyResults",
                            ReportConfiguration = new ReportConfiguration()
                            {
                                Parameters = new List<ReportParameter>()
                                {
                                    new ReportParameter()
                                    {
                                        Name = "dateFrom",
                                        Type = "datetime"
                                    }
                                }
                            }
                        },
                        new Report()
                        {
                            DisplayName = "Top Exercises",
                            StorageProcedure = "Reporting_TopExercises",
                            ReportConfiguration = new ReportConfiguration()
                            {
                                Parameters = new List<ReportParameter>()
                                {
                                    new ReportParameter()
                                    {
                                        Name = "dateFrom",
                                        Type = "datetime"
                                    }
                                }
                            }
                        }
                    });

                    db.SaveChanges();
                }

            }
        }
    }
}
