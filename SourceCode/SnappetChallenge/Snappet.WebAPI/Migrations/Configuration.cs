using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Snappet.WebAPI.Persistence;
using Newtonsoft.Json.Linq;
using System.Web.Hosting;
using Newtonsoft.Json;
using System.Configuration;

namespace Snappet.WebAPI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SnappetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SnappetContext context)
        {
            LoadWork(context);
            context.SaveChanges();
        }

        private void LoadWork(SnappetContext context)
        {
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "work.json");

            var json = System.IO.File.ReadAllText(filePath);
            var works = JsonConvert.DeserializeObject<List<Models.Work>>(json);

            int seedlimit = -1;//If -1 meaning all data to seed. 
            if (!string.IsNullOrEmpty(ConfigurationSettings.AppSettings["DataSetLimit"]))
            {
                seedlimit = Convert.ToInt32(ConfigurationSettings.AppSettings["DataSetLimit"]);
            }

            foreach (var item in works)
            {
                context.Works.AddOrUpdate(item);

                if (seedlimit != -1)
                {
                    if (seedlimit == 0)
                        break;
                    seedlimit--;
                }
            }

        }
    }
}