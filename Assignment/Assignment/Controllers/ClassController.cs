#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Assignment.Models;
using Newtonsoft.Json;
using System.IO;
using Assignment.ViewModel;
using Assignment.DAL;
#endregion


#region namespace
namespace Assignment.Controllers
{
    #region class
    public class ClassController : Controller
    {
        public List<JsonDataModel> jsonData { get; private set; }

        #region Methods

        /// <summary>
        ///Action Method to get ClassDataViewModel
        /// </summary>
        /// <returns></returns>
        public ActionResult ClassOverView()
        {
            using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/work.json")))
            {
                jsonData = JsonConvert.DeserializeObject<List<JsonDataModel>>(sr.ReadToEnd());
            }
            var objClassDAL = new ClassDAL();
            var objClassData = objClassDAL.ClassData(jsonData);
            return View(objClassData);
        }
        #endregion
    }
    #endregion
}
#endregion