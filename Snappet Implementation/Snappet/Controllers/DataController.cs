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
        // instantiate the database class
        private SnappetDB db = new SnappetDB();

        // set the date to the specified date
        private static DateTime date = new DateTime(2015, 3, 24, 11, 30, 00);

        /// <summary>
        /// get all the subjects 
        /// for the given userId
        /// if the id is null it is seen as for all users
        /// </summary>
        /// <param name="id">the userId</param>
        /// <returns>a Json to the view with the subjects as its information</returns>
        [WebMethod]
        public JsonResult Subjects(int? id)
        {
            List<string> subjects = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id)).Select(s => s.Subject).Distinct().OrderBy(s => s).ToList();
            List<SelectListItem> subjectsSelectListItems = new List<SelectListItem>();

            if (subjects.Count != 1)
                subjectsSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

            foreach (string subject in subjects)
                subjectsSelectListItems.Add(new SelectListItem { Text = subject, Value = subject });

            return Json(new SelectList(subjectsSelectListItems, "Value", "Text"));
        }

        /// <summary>
        /// get all the domains
        /// for the given userId
        /// if the id is null it is seen as for all users
        /// </summary>
        /// <param name="id">the userId</param>
        /// <param name="subject">the subject which domains we want</param>
        /// <returns>a Json to the view with the domains as its information</returns>
        [WebMethod]
        public JsonResult Domains(int? id, string subject)
        {
            List<String> domains = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && s.Subject == subject).Select(s => s.Domain).Distinct().OrderBy(d => d).ToList();
            List<SelectListItem> domainsSelectListItems = new List<SelectListItem>();
            if (domains.Count != 1)
                domainsSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

            foreach (string domain in domains)
                domainsSelectListItems.Add(new SelectListItem { Text = domain, Value = domain });

            return Json(new SelectList(domainsSelectListItems, "Value", "Text"));
        }

        /// <summary>
        /// get all the learningobjectives
        /// for the given userId
        /// if the id is null it is seen as for all users
        /// </summary>
        /// <param name="id">the userId</param>
        /// <param name="subject">the subject which domains we want</param>
        /// <param name="domain">the domain which learning objectives we want</param>
        /// <returns>a Json to the view with the learningObjectives as its information</returns>
        [WebMethod]
        public JsonResult LearningObjectives(int? id, string subject, string domain)
        {
            List<string> learningObjectives = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && s.Subject == subject && s.Domain == domain).Select(d => d.LearningObjective).Distinct().OrderBy(s => s).ToList();
            List<SelectListItem> learningObjectivesSelectListItems = new List<SelectListItem>();
            if (learningObjectives.Count != 1)
                learningObjectivesSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

            foreach (string learningObjective in learningObjectives)
                learningObjectivesSelectListItems.Add(new SelectListItem { Text = learningObjective, Value = learningObjective });

            return Json(new SelectList(learningObjectivesSelectListItems, "Value", "Text"));
        }

        /// <summary>
        /// get the data for all the graphs on the page
        /// for the given userId
        /// if the id is null it is seen as for all users
        /// </summary>
        /// <param name="id">the userId</param>
        /// <param name="subject">the subject which domains we want</param>
        /// <param name="domain">the domain which learning objectives we want</param>
        /// <param name="learningObjective">the learningobjective which we want the results for</param>
        /// <returns>a Json to the view with the data for the graphs as its information</returns>
        [WebMethod]
        public JsonResult GraphData(int? id, string subject, string domain, string learningObjective)
        {
            List<String> labelsGraph_1_1 = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id)
            && (subject == "All" ? 1 == 1 : s.Subject == subject)).Select(s => s.Subject).Distinct().OrderBy(s => s).ToList();
            List<int> seriesGraph_1_1 = new List<int>();

            foreach (String subjectInSubjects in labelsGraph_1_1)
            {
                seriesGraph_1_1.Add(this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && s.Subject == subjectInSubjects).Count());
            }


            List<String> labelsGraph_1_2 = new List<String>();
            List<String> labelsGraph_1_2_temp = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)).Select(s => s.Domain).Distinct().OrderBy(s => s).ToList();
            foreach (String label in labelsGraph_1_2_temp)
            {
                if (label != "-")
                {
                    labelsGraph_1_2.Add(label);
                }
            }

            List<int> seriesGraph_1_2 = new List<int>();
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
            List<String> labelsGraph_1_3 = new List<String>();
            labelsGraph_1_3.Add(id == null ? "Alle leerlingen" : id.ToString());

            List<Double> seriesGraph_1_3 = new List<Double>();
            seriesGraph_1_3.Add((Double)amountOfAnswers / (Double)amountOfUsers);

            List<int> seriesGraph_2_1 = new List<int>();
            seriesGraph_2_1.Add(this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)
                                                                && (learningObjective == "All" ? true : s.LearningObjective == learningObjective)
                                                                && s.Correct == 1).Count());
            seriesGraph_2_1.Add(this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)
                                                                && (learningObjective == "All" ? true : s.LearningObjective == learningObjective)
                                                                && s.Correct == 0).Count());

            List<String> labelsGraph_2_2 = new List<String>();
            List<int> userIds = this.db.SubmittedAnswers.Where(s => (s.SubmitDateTime <= date) && (id == null ? true : s.UserId == id) && (subject == "All" ? true : s.Subject == subject)
                                                                && (domain == "All" ? true : s.Domain == domain)
                                                                && (learningObjective == "All" ? true : s.LearningObjective == learningObjective)).Select(s => s.UserId).Distinct().OrderBy(s => s).ToList();
            List<int> seriesGraph_2_2 = new List<int>();
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