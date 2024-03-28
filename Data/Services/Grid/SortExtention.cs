using System;
using System.Linq.Expressions;

namespace Data.Services.Grid
{
    public static class SortExtention
    {
        public static Expression<Func<T, object>> GetSortExpression<T>(this SortOption sort)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            MemberExpression member = Expression.Property(param, sort.field);
            // Check if the member type is a nullable value type and convert it to object
            if (Nullable.GetUnderlyingType(member.Type) != null || member.Type.IsValueType)
            {
                return Expression.Lambda<Func<T, object>>(Expression.Convert(member, typeof(object)), param);
            }
            return Expression.Lambda<Func<T, object>>(member, param);
        }

    }
}
