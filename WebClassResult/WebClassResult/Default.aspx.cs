using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassResult.App_Code;

namespace WebClassResult
{
    public partial class Default : System.Web.UI.Page
    {
        List<Work> workItems = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                workItems = LoadJson();
                //filter desired data
                var ItemsToday = workItems.Where(item => item.SubmitDateTime > new DateTime(2015, 3, 24, 0, 0, 0) 
                                                    && item.SubmitDateTime <= new DateTime(2015, 3, 24, 11, 30, 0)
                                                    && item.Progress != 0);
                //initiate reportviewer and load report
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/ReportClassToday.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ItemsToday);
                ReportViewer1.LocalReport.DataSources.Clear();
                //add our datasource
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
        }

        public List<Work> LoadJson()
        {
            using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/work.json")))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Work>>(json);
            }
        }
    }
}