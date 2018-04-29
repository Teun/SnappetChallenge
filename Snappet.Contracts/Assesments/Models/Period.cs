using Snappet.Contracts.Assesments.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Snappet.Contracts.Assesments.Models
{
    public enum PeriodType
    {
        [Display(Name = "Last Week")]
        [Days(Number = 7)]
        Week,
        [Display(Name = "Last Month")]
        [Days(Number = 30)]
        Month,
        [Display(Name = "Previous Lesson")]
        [Days(Number = 7)]
        PreviousLesson
    }
}
