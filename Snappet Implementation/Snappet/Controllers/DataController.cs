using Snappet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Snappet.Controllers
{
    public class DataController : Controller
    {
        private SnappetDB db = new SnappetDB();

        [WebMethod]
        public JsonResult Subjects(int? id)
        {
            List<string> subjects;
            if (id != null)
            {
                subjects = this.db.Users.Where(u => u.Id == id).First().SubmittedAnswers.Select(s => s.Subject).Distinct().ToList();
            } else
            {
                subjects = this.db.SubmittedAnswers.Select(s => s.Subject).Distinct().ToList();
            }

            List<SelectListItem> subjectsSelectListItems = new List<SelectListItem>();
            if (subjects.Count != 1)
                subjectsSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

            foreach (string subject in subjects)
                subjectsSelectListItems.Add(new SelectListItem { Text = subject, Value = subject });

            return Json(new SelectList(subjectsSelectListItems, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }

        [WebMethod]
        public JsonResult GetDomains(int? id, string subject)
        {
            //List<string> domains = SubmittedAnswers.Where(x => x.SubmittedDateTime >= startDateTime && x.SubmittedDateTime < currentDateTime && x.Subject == subject)
            //                                                .Select(x => x.Domain).Distinct().ToList<string>();
            List<String> domains;
            if (id != null)
            {
                domains = this.db.Users.Where(u => u.Id == id).First().SubmittedAnswers.Where(s => s.Subject == subject).Select(s => s.Domain).Distinct().ToList();
            }
            else
            {
                domains = this.db.SubmittedAnswers.Where(s => s.Subject == subject).Select(s => s.Domain).Distinct().ToList();
            }

            List<SelectListItem> domainsSelectListItems = new List<SelectListItem>();
            if (domains.Count != 1)
                domainsSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

            foreach (string domain in domains)
                domainsSelectListItems.Add(new SelectListItem { Text = domain, Value = domain });

            return Json(new SelectList(domainsSelectListItems, "Value", "Text"));
        }

        [WebMethod]
        public JsonResult GetLearningObjectives(int? id, string subject, string domain)
        {
            //List<string> learningObjectives = SubmittedAnswers.Where(x => x.SubmittedDateTime >= startDateTime && x.SubmittedDateTime < currentDateTime && x.Subject == subject && x.Domain == domain)
            //                                                .Select(x => x.LearningObjective).Distinct().ToList<string>();
            List<string> learningObjectives;
            if (id != null)
            {
                learningObjectives = this.db.Users.Where(u => u.Id == id).First().SubmittedAnswers.Where(s => s.Subject == subject).Where(s => s.Domain == domain).Select(d => d.LearningObjective).Distinct().ToList();
            }
            else
            {
                learningObjectives = this.db.SubmittedAnswers.Where(s => s.Subject == subject).Where(s => s.Domain == domain).Select(d => d.LearningObjective).Distinct().ToList();
            }

            List<SelectListItem> learningObjectivesSelectListItems = new List<SelectListItem>();
            if (learningObjectives.Count != 1)
                learningObjectivesSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

            foreach (string learningObjective in learningObjectives)
                learningObjectivesSelectListItems.Add(new SelectListItem { Text = learningObjective, Value = learningObjective });

            return Json(new SelectList(learningObjectivesSelectListItems, "Value", "Text"));
        }
    }
}