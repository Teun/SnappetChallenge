using Snappet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services;

namespace Snappet.Controllers
{
    public class DataController : Controller
    {
        private SnappetDB db = new SnappetDB();
        private static DateTime date = new DateTime(2015, 3, 24, 11, 30, 00);

        [WebMethod]
        public JsonResult Subjects(int? id)
        {
            List<string> subjects = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id)).Select(s => s.Subject).Distinct().ToList();
            List<SelectListItem> subjectsSelectListItems = new List<SelectListItem>();
            if (subjects.Count != 1)
                subjectsSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

            foreach (string subject in subjects)
                subjectsSelectListItems.Add(new SelectListItem { Text = subject, Value = subject });

            return Json(new SelectList(subjectsSelectListItems, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }

        [WebMethod]
        public JsonResult Domains(int? id, string subject)
        {
            List<String> domains = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && s.Subject == subject).Select(s => s.Domain).Distinct().ToList();
            List<SelectListItem> domainsSelectListItems = new List<SelectListItem>();
            if (domains.Count != 1)
                domainsSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

            foreach (string domain in domains)
                domainsSelectListItems.Add(new SelectListItem { Text = domain, Value = domain });

            return Json(new SelectList(domainsSelectListItems, "Value", "Text"));
        }

        [WebMethod]
        public JsonResult LearningObjectives(int? id, string subject, string domain)
        {
            List<string> learningObjectives = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && s.Subject == subject && s.Domain == domain).Select(d => d.LearningObjective).Distinct().ToList();
            List<SelectListItem> learningObjectivesSelectListItems = new List<SelectListItem>();
            if (learningObjectives.Count != 1)
                learningObjectivesSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

            foreach (string learningObjective in learningObjectives)
                learningObjectivesSelectListItems.Add(new SelectListItem { Text = learningObjective, Value = learningObjective });

            return Json(new SelectList(learningObjectivesSelectListItems, "Value", "Text"));
        }

        [WebMethod]
        public JsonResult GraphData(int? id, string subject, string domain, string learningObjective)
        {
            List<String> labelsGraph_1_1;
            List<int> seriesGraph_1_1;

            List<String> labelsGraph_1_2;
            List<int> seriesGraph_1_2;

            List<String> labelsGraph_1_3;
            List<Double> seriesGraph_1_3;

            List<int> seriesGraph_2_1;

            List<String> labelsGraph_2_2;
            List<int> seriesGraph_2_2;

            labelsGraph_1_1 = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id)
            && (subject == "All" ? 1 == 1 : s.Subject == subject)).Select(s => s.Subject).Distinct().ToList();
            seriesGraph_1_1 = new List<int>();

            foreach (String subjectInSubjects in labelsGraph_1_1)
            {
                seriesGraph_1_1.Add(this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && s.Subject == subjectInSubjects).Count());
            }


            labelsGraph_1_2 = new List<String>();
            List<String> labelsGraph_1_2_temp = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)).Select(s => s.Domain).Distinct().ToList();
            foreach (String label in labelsGraph_1_2_temp)
            {
                if (label != "-")
                {
                    labelsGraph_1_2.Add(label);
                }
            }

            seriesGraph_1_2 = new List<int>();
            foreach (String DomainInDomains in labelsGraph_1_2)
            {
                seriesGraph_1_2.Add(this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && s.Domain == DomainInDomains).Count());
            }


            int amountOfUsers = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)
                                                                && (learningObjective == "All" ? true : s.LearningObjective == learningObjective))
                                                                .Select(s => s.UserId).Distinct().Count();
            int amountOfAnswers = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)
                                                                && (learningObjective == "All" ? true : s.LearningObjective == learningObjective))
                                                                .Count();
            labelsGraph_1_3 = new List<String>();
            labelsGraph_1_3.Add(id == null ? "Alle leerlingen" : id.ToString());

            seriesGraph_1_3 = new List<Double>();
            seriesGraph_1_3.Add((Double)amountOfAnswers / (Double)amountOfUsers);

            seriesGraph_2_1 = new List<int>();
            seriesGraph_2_1.Add(this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)
                                                                && (learningObjective == "All" ? true : s.LearningObjective == learningObjective)
                                                                && s.Correct == 1).Count());
            seriesGraph_2_1.Add(this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)
                                                                && (learningObjective == "All" ? true : s.LearningObjective == learningObjective)
                                                                && s.Correct == 0).Count());

            labelsGraph_2_2 = new List<String>();
            List<int> userIds = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)
                                                                && (learningObjective == "All" ? true : s.LearningObjective == learningObjective)).Select(s => s.UserId).Distinct().ToList();
            seriesGraph_2_2 = new List<int>();
            foreach (int userId in userIds)
            {
                labelsGraph_2_2.Add(userId.ToString());
                seriesGraph_2_2.Add(this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && s.UserId == userId && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)
                                                                && (learningObjective == "All" ? true : s.LearningObjective == learningObjective)).Select(s => s.Progress).Sum());
            }


            GraphData<int> graph_1_1 = new GraphData<int>(labelsGraph_1_1, seriesGraph_1_1);
            GraphData<int> graph_1_2 = new GraphData<int>(labelsGraph_1_2, seriesGraph_1_2);
            GraphData<Double> graph_1_3 = new GraphData<Double>(labelsGraph_1_3, seriesGraph_1_3);
            PieData<int> graph_2_1 = new PieData<int>(seriesGraph_2_1);
            GraphData<int> graph_2_2 = new GraphData<int>(labelsGraph_2_2, seriesGraph_2_2);


            return Json(new
            {
                graph_1_1 = graph_1_1,
                graph_1_2 = graph_1_2,
                graph_1_3 = graph_1_3,
                graph_2_1 = graph_2_1,
                graph_2_2 = graph_2_2
            });
        }
    }
}