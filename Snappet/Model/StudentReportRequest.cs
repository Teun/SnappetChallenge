using System;
using System.ComponentModel.DataAnnotations;

namespace Snappet.Model
{
    public class StudentReportRequest
    {
        [Required]
        public long StudentId { get; set; }
        public DateTime? Date { get; set; }
    }
}