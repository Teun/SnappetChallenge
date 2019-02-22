using MongoDB.Bson;
using System;

namespace StudentsAPI.WebApi.Models
{
    public class ProgressItem
    {
        public DateTime Date { get; set; }
        public float TotalProgress { get; set; }
    }
}
