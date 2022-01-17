﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnappetChallenge.Data;
using SnappetChallenge.Models;
using SnappetChallenge.SqlQuerys;

namespace SnappetChallenge.Controllers
{
    public class DayCompareToAllController : Controller
    {
        private readonly DataContext _context;

        private DateTime momentInTime = DateTime.Parse("2015-03-24 11:30:00");

        public DayCompareToAllController(DataContext context)
        {
            _context = context;
        }


        // GET: DayCompareToAll
        public async Task<IActionResult> Index()
        {
            ViewData["MomentInTime"] = momentInTime;

            return View(await _context.DayCompareToAllModel.FromSqlRaw(Querys.CompareDayToAll(momentInTime)).ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Index(DateTime momentInTime)
        {
            this.momentInTime = momentInTime;

            return await Index();

        }
    }
}
