using System;
using System.Linq;
using System.Linq.Expressions;

namespace WorkVitCenter.Core.Utilities.ExtensionMethods
{
    public static class SorterExtensionMethods
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string sortField, bool ascending)
        {
            if (string.IsNullOrEmpty(sortField)) return query;
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            Expression expBody;
            if (sortField.Contains("."))
                expBody = sortField.Split('.').Aggregate<string, Expression>(param, Expression.Property);
            else
                expBody = Expression.Property(param, sortField);

            var exp = Expression.Lambda(expBody, param);
            string method = ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { query.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, query.Expression, exp);
            return query.Provider.CreateQuery<T>(mce);
        }

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string sortColumn, bool descending)
        {
            // Dynamically creates a call like this: query.OrderBy(p =&gt; p.SortColumn)
            var parameter = Expression.Parameter(typeof(T), "x");

            string command = "OrderBy";

            if (descending)
            {
                command = "OrderByDescending";
            }

            Expression resultExpression;

            var property = typeof(T).GetProperty(sortColumn);
            // this is the part p.SortColumn
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            // this is the part p =&gt; p.SortColumn
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            // finally, call the "OrderBy" / "OrderByDescending" method with the order by lamba expression
            resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { typeof(T), property.PropertyType },
               query.Expression, Expression.Quote(orderByExpression));

            return query.Provider.CreateQuery<T>(resultExpression);
        }
    }
}
