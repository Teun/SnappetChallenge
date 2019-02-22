using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace StudentsAPI.WebApi.Models
{
    public class Progress
    {
        public IEnumerable<ProgressItem> ProgressItems { get; set; }
        public float TotalMonthProgress { get; set; }
        public float AverageProgress { get; set; }
    }
}
