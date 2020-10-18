using System;
using System.Collections.Generic;

namespace ChessLib.Util
{
    public static class FluentList
    {
        public static List<T> Create<T>() =>
            new List<T>();

        public static List<T> With<T>(this List<T> list, T item){
            list.Add(item);
            return list;
        }

        public static List<T> WithIf<T>(this List<T> list, T item, Func<T, bool> predicate){
            if(predicate(item))
                list.Add(item);
                
            return list;
        }
    }
}