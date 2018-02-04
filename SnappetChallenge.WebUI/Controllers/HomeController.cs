namespace SnappetChallenge.WebUI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using SnappetChallenge.WebUI.Models;
    using SnappetChallenge.WebUI.Services;
    using SnappetChallenge.WebUI.ViewModels;

    public class HomeController : Controller
    {
        private readonly IDataService dataService;

        public HomeController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public async Task<IActionResult> Index()
        {
            DateTime dateTimeFrom = DateTime.SpecifyKind(new DateTime(2015, 03, 24), DateTimeKind.Utc);
            DateTime dateTimeTo = DateTime.SpecifyKind(new DateTime(2015, 03, 24, 11, 30, 00), DateTimeKind.Utc);

            this.ViewData["DateTime"] = dateTimeFrom.ToString("d");
            this.ViewData["TimeTo"] = dateTimeTo.ToString("T");

            IEnumerable<StudentResultModel> data = 
                await this.dataService.GetByDate(dateTimeFrom, dateTimeTo);

            IEnumerable<StudentResultViewModel> result = null;
            if (data != null)
            {
                result = data.Select(item => new StudentResultViewModel(item));
            }

            return this.View(result);
        }
    }
}
