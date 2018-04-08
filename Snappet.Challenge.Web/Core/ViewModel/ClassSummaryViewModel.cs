using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.KeyVault.Models;
using Snappet.Challenge.Web.Core.Models;

namespace Snappet.Challenge.Web.Core.ViewModel
{
    public class ClassSummaryViewModel
    {
        public Summary TopStudent { get; set; }
        public Summary ClassSummary { get; set; }
        public IEnumerable<Summary> ClassResults { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SearchDate { get; set; }
    }
}