using System;
using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.Core
{
    public class GroupResult
    {
        public object Key { get; set; }
        public IEnumerable<GroupResult> SubGroups { get; set; }
        public override string ToString() => Key.ToString();
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<GroupResult> GroupByMany<TElement>(this IEnumerable<TElement> elements, params Func<TElement, object>[] groupSelectors)
        {
            if (groupSelectors.Length > 0)
            {
                var selector = groupSelectors.First();
                var nextSelectors = groupSelectors.Skip(1).ToArray();
                return elements.GroupBy(selector)
                               .Select(g => new GroupResult
                               {
                                   Key = g.Key,
                                   SubGroups = g.GroupByMany(nextSelectors)
                               });
            }
            else
            {
                return null;
            }
        }
    }
}
