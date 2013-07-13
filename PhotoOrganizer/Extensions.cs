using System;
using System.Linq.Expressions;

namespace PhotoOrganizer
{
    public static class Extensions
    {
        public static string GetPropertySymbol<T, TR>(this T obj, Expression<Func<T, TR>> expr)
        {
            return ((MemberExpression)expr.Body).Member.Name;
        }
    }
}