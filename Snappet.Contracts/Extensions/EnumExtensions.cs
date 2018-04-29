using Snappet.Contracts.Assesments.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Snappet.Contracts.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var displayAttribute = field.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

            return displayAttribute != null && displayAttribute.Name != null ? displayAttribute.Name : value.ToString();
        }

        public static int DaysNumber(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var daysAttribute = field.GetCustomAttribute(typeof(DaysAttribute)) as DaysAttribute;

            return daysAttribute != null ? daysAttribute.Number : 0;
        }
    }
}
