// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EnumarableExtensions.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//  <author>Valiukevich, Evgeny</author>
// --------------------------------------------------------------------------------------------------------------------
namespace Demo.Report.API.Extensions

{
    using System;
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static IEnumerable<float> CumulativeMovingAverage(this IEnumerable<float> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            float total = 0;
            int count = 0;

            foreach (float d in source)
            {
                count++;
                total += d;
                yield return total / count;
            }
        }
    }
}