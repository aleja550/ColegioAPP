using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Utilities.Extensions
{
    public static class EnumerableExtensions
    {
        public static void Iterate<T>(this IEnumerable<T> source, Action<T> next)
        {
            foreach (T item in source.ToList())
                next(item);
        }

        public static IEnumerable<T> DistinctBy<T, TProperty>(this IEnumerable<T> source, Func<T, TProperty> propertySelector) => source.GroupBy(propertySelector).Select(s => s.First());

        public static IEnumerable<int> GetNumericValues(this IEnumerable<string> source) => source.Select(x => (IsNumber: int.TryParse(x, out int num), Num: num)).Where(x => x.IsNumber).Select(x => x.Num);
    }
}
