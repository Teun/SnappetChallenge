using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeacherReport.Models;

using DataRepositories.Interfaces;

namespace TeacherReport.Controllers
{
    /// <summary>
    /// This is the only controller in this simple application
    /// </summary>
    public class HomeController : Controller
    {
        private IAnswerRepository answerRepository = null;

        /// <summary>
        /// Constructs an instance of HomeController
        /// </summary>
        /// <param name="answerRepository">An instance of an answer repository</param>
        public HomeController(IAnswerRepository answerRepository)
        {
            this.answerRepository = answerRepository;
        }

        /// <summary>
        /// Retrieves the main page
        /// </summary>
        /// <returns>The result containing the view to be displayed</returns>
        public IActionResult Index()
        {
            var summaryViewModel = new SummaryPageViewModel();

            //The current moment is always frozen at 2015-03-24 11:30:00
            DateTime currentDateTime = DateTime.Parse("2015-03-24T11:30:00");

            //Retrieve the student daily summary from the repository
            summaryViewModel.StudentSummary = answerRepository.GetDailyStudentSummary(currentDateTime);

            //Sort the subjects alphabetically
            summaryViewModel.StudentSummary.Subjects = summaryViewModel.StudentSummary.Subjects
                .OrderBy(subject => subject)
                .ToList();

            //Sort the student summary rows by the overall average progress score
            summaryViewModel.StudentSummary.SummaryRows = summaryViewModel.StudentSummary.SummaryRows
                .OrderBy(summaryRow => summaryRow.OverallAverageProgress)
                .ToList();

            //Return the view with the view model
            return View(summaryViewModel);
        }
    }
}
