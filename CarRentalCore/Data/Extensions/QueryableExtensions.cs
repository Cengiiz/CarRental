using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRentalCore
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(
            this IQueryable<T> query,
            params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = ApplyIncludes(query, include);
                }
            }
            return query;
        }

        private static IQueryable<T> ApplyIncludes<T>(
            IQueryable<T> query,
            Expression<Func<T, object>> include) where T : class
        {
            var includeString = GetIncludeString(include.Body);
            if (!string.IsNullOrEmpty(includeString))
            {
                query = query.Include(includeString);
            }
            return query;
        }

        private static string GetIncludeString(Expression expression)
        {
            switch (expression)
            {
                case MemberExpression memberExpression:
                    return memberExpression.Member.Name;
                case MethodCallExpression methodCallExpression when methodCallExpression.Method.Name == "Select":
                    var collection = GetIncludeString(methodCallExpression.Arguments[0]);
                    var property = GetIncludeString(methodCallExpression.Arguments[1]);
                    return $"{collection}.{property}";
                case UnaryExpression unaryExpression when unaryExpression.Operand is MemberExpression operand:
                    return operand.Member.Name;
                default:
                    return string.Empty;
            }
        }
    }
}
