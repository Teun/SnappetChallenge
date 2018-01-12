using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using backend.Repository;
using System.Web;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Linq;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    public class StudentsController: Controller
    {
        private readonly IConfiguration _config;
        private Hashtable _subjects;
        public StudentsController(IConfiguration config) {
            this._config = config;
            this._subjects = new Hashtable();
            this._subjects.Add("-",  new String[] {"-"});
            this._subjects.Add("Begrijpend Lezen",  new String[] {"-"});
            this._subjects.Add("Rekenen", new String[] {"-", "Meten", "Verbanden", "Verhoudingen", "Getallen"});
            this._subjects.Add("Spelling", new String[] {"-", "Taalverzorging"});
        }

        // GET api/values
        [HttpGet]
        public string Get(DateTime filterDate, string subject, string classDomain, int range)
        {
            if (filterDate == null)
            {
                throw new ArgumentNullException(nameof(filterDate));
            }

            if (subject is null || subject == "-")
            {
                subject = "";
            }

            if (classDomain is null || classDomain == "-")
            {
                classDomain = "";
            }

            StudentDAO dao =  new StudentDAO(this._config);
            IEnumerable<Student> list = dao.GetRoomReport(filterDate, subject, classDomain, range);
            return JsonConvert.SerializeObject(list);
        }

        [HttpGet("subjects")]
        public string GetSubjects() {
            IEnumerable<string> result = (IEnumerable<string>) this._subjects.Keys.Cast<string>().ToList();
            return JsonConvert.SerializeObject(result);
        }

         [HttpGet("domains")]
        public string GetDomains(string subject) {
            
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            IEnumerable<string> result = (IEnumerable<string>) this._subjects[subject];
            return JsonConvert.SerializeObject(result);
        }
        
    }
}