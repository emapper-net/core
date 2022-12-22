using System;
using System.Collections.Generic;
using System.Linq;

namespace emapper.net;

internal static class TypeScanner
{
    private static IEnumerable<TResult> FlatMap<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
    {
        foreach (TSource element in source)
        {
            foreach (TResult subElement in selector(element))
            {
                yield return subElement;
            }
        }
    }

    public static IEnumerable<Type> Find(Func<Type, bool> predicate)
    {
        return AppDomain.CurrentDomain
            .GetAssemblies()
            .FlatMap(
                assembly => assembly
                    .GetTypes()
                    .Where(type => predicate(type))
            );
    }
}