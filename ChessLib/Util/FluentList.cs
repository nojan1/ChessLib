using System;
using System.Collections.Generic;

namespace ChessLib.Util
{
    public enum WhilePredicateResult
    {
        Include,
        Stop,
        IncludeAndStop
    }

    public static class FluentList
    {
        public static List<T> Create<T>() =>
            new List<T>();

        public static List<T> With<T>(this List<T> list, T item)
        {
            list.Add(item);
            return list;
        }

        public static List<T> WithIf<T>(this List<T> list, T item, Func<T, bool> predicate)
        {
            if (predicate(item))
                list.Add(item);

            return list;
        }

        public static List<T> WithWhile<T>(this List<T> list, T initialItem, Func<T, T> getNextValue, Func<T, WhilePredicateResult> predicate) {
            T item = initialItem;

            while(true){
                var result = predicate(item);
                if(result == WhilePredicateResult.Stop)
                    break;

                list.Add(item);

                if(result == WhilePredicateResult.IncludeAndStop)
                    break;

                item = getNextValue(item);
            }

            return list;
        }

        public static List<T> WithWhile<T>(this List<T> list, T initialItem, Func<T, T> getNextValue, Func<T, bool> predicate) {
            return list.WithWhile(initialItem, getNextValue, (value) => {
                if(predicate(value))
                    return WhilePredicateResult.Include;

                return WhilePredicateResult.Stop;
            });
        }
    }
}