using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Models;

namespace SnappetChallenge.WebApp.Models
{
    public class TodayResultViewModel
    {
        public int numberOfStudents { get; set; }
        public int numberOfQuestions { get; set; }
        public decimal correctRatio { get; set; }
        public decimal incorrectRatio { get; set; }
        public decimal progressAverage { get; set; }

    }
}