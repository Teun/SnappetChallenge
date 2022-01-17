#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SnappetChallenge.Data;
using SnappetChallenge.Models;

namespace SnappetChallenge.Controllers
{
    public class WorkDataController : Controller
    {
        private readonly DataContext _context;

        public WorkDataController(DataContext context)
        {
            _context = context;
        }

        // GET: WorkDataModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkDataModel.ToListAsync());
        }


        [HttpPost]
        public ActionResult Upload(IFormFile jsonFile)
        {
            using (var ms = new MemoryStream())
            {
                jsonFile.CopyTo(ms);

                var s = Encoding.ASCII.GetString(ms.ToArray());

                var workData = JsonConvert.DeserializeObject<List<WorkDataModel>>(s);

                foreach (var o in workData)
                {
                    _context.WorkDataModel.Add(o);
                }

                try
                {
                    ViewBag.ErrorMessage = String.Empty;
                    ViewBag.Success = String.Empty;

                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
                finally
                {
                    if (ViewBag.ErrorMessage == String.Empty)
                    {
                        ViewBag.Success = "Data uploaded successfully";
                    }
                }
            }

            return View("Index");
        }


        [HttpPost]
        public ActionResult Delete()
        {

            try
            {
                ViewBag.ErrorMessage = String.Empty;
                ViewBag.Success = String.Empty;

                _context.Database.ExecuteSqlRaw("DELETE FROM WorkData");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                if (ViewBag.ErrorMessage == String.Empty)
                {
                    ViewBag.Success = "Data deleted successfully";
                }
            }

            return View("Index");
        }

    }
}

