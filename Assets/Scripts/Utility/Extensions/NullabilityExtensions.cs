using System;
using Object = UnityEngine.Object;

namespace Utility.Extensions
{
    public static class NullabilityExtensions
    {
        public static T OrNull<T>(this T obj, Func<T> supplier)
        {
            return obj is null ? supplier.Invoke() : obj;
        }
    }
}