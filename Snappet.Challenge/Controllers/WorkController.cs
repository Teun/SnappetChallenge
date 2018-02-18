using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Snappet.Challenge.Models;
using Snappet.Challenge.Infrastructure;

namespace Snappet_Challenge.Controllers
{
    [Route("api/[controller]")]
    public class WorkController : Controller
    {
        private IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        [HttpGet("dates")]
        public IEnumerable<DateTime> GetDates()
        {
            if (!_workService.IsDataAvailable())
                throw new Exception("Cannot get data from datasource.");

            return _workService.GetDateList();
        }

        [HttpGet("work-query-lists/{date:DateTime}/{offset:int}")]
        public WorkQueryLists GetWorkQueryLists(DateTime date, int offset)
        {
            if (!_workService.IsDataAvailable())
                throw new Exception("Cannot get data from datasource.");

            var result = _workService.GetWorkQueryLists(date, offset);
            return result;
        }

        [HttpPost("search")]
        public WorkSearchResults Search([FromBody] WorkQuery query)
        {
            if (!_workService.IsDataAvailable())
                throw new Exception("Cannot get data from datasource.");

            var result = _workService.Search(query);
            return result;
        }
    }
}
