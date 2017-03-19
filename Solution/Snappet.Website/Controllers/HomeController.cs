using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Snappet.Data.DataObjects;
using Snappet.Data.DataServices;
using Snappet.Data.Mappers;
using Snappet.Data.QueryRepositories;
using Snappet.Website.Mappers;
using Snappet.Website.Models;

namespace Snappet.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassResultDataService _dataService;
        private readonly ITableViewModelMapper _tableViewModelMapper;
        public HomeController():this(CreateDataService(), new TableViewModelMapper())
        {
        }

        public HomeController(IClassResultDataService dataService, ITableViewModelMapper tableViewModelMapper)
        {
            _dataService = dataService;
            _tableViewModelMapper = tableViewModelMapper;
        }

        public ActionResult Index()
        {
            try
            {
                DateTime now = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);
                var twoWeeksAgo = now.AddDays(-14);

                IList<ClassResultRow> todayRows = _dataService.GetClassResult(now);
                IList<ClassResultRow> twoWeeksAgoRows = _dataService.GetClassResult(twoWeeksAgo);

                var todayTable = _tableViewModelMapper.CreateTableViewModel($"Resulten van vandaag {now.ToLocalTime()}", todayRows);
                var toWeeksAgoTable = _tableViewModelMapper.CreateTableViewModel($"Resulten van {twoWeeksAgo.ToLocalTime()}", twoWeeksAgoRows);
                var model = new TablesViewModel(todayTable, toWeeksAgoTable);

                return View("Tables", model);
            }
            catch (Exception)
            {
                // Todo: Log Error
                return View("Error");
            }

        }
        
        private static IClassResultDataService CreateDataService()
        {
            var jsonFile = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/work.json");
            IQueryRepository dataRepo = new FilterQueryRepository(new JsonDataRepository(), jsonFile);
            return new ClassResultDataService(dataRepo, new ReportRowMapper());
        }
    }
}