using ART_PACKAGE.Helpers.Grid;
using System.Linq.Expressions;
using System.Reflection;

public static class FilterExtensions
{
    public static Expression<Func<T, bool>> ToExpression<T>(this Filter filter)
    {
        if (filter == null)
            return x => true;
        if (filter.filters == null || !filter.filters.Any())
            return x => true;

        ParameterExpression param = Expression.Parameter(typeof(T), "t");
        Expression exp = BuildExpression<T>(param, filter);

        return Expression.Lambda<Func<T, bool>>(exp, param);
    }

    private static Expression BuildExpression<T>(ParameterExpression param, Filter filter)
    {
        Expression? exp = null;
        if (filter.filters is null && !string.IsNullOrEmpty(filter.field))
        {
            exp = BuildIndividualExpression<T>(param, filter);
        }
        else
        {
            foreach (Filter f in filter.filters)
            {
                Expression? childExp = null;

                if (f.filters != null && f.filters.Any())
                {
                    // If f is a nested Filter
                    foreach (Filter item in f.filters)
                    {
                        Expression nestedChildExp = BuildExpression<T>(param, item);
                        childExp = childExp == null
                            ? nestedChildExp
                            : item.logic == "or"
                                ? Expression.OrElse(childExp, nestedChildExp)
                                : Expression.AndAlso(childExp, nestedChildExp);
                    }

                }
                else
                {
                    // If f is an individual FilterModel
                    childExp = BuildIndividualExpression<T>(param, f);
                }

                exp = exp == null
                    ? childExp
                    : filter.logic == "or"
                        ? Expression.OrElse(exp, childExp)
                        : Expression.AndAlso(exp, childExp);
            }
        }


        return exp;
    }

    private static Expression BuildIndividualExpression<T>(ParameterExpression param, Filter filter)
    {
        MemberExpression member = Expression.Property(param, filter.field);
        ConstantExpression constant = Expression.Constant(Convert.ChangeType(filter.value, member.Type));
        return filter.@operator switch
        {
            "eq" => Expression.Equal(member, constant),
            "neq" => Expression.NotEqual(member, constant),
            "isnull" => Expression.Equal(member, Expression.Constant(null)),
            "isnotnull" => Expression.NotEqual(member, Expression.Constant(null)),
            "isempty" => Expression.Equal(member, Expression.Constant(Convert.ChangeType("", member.Type))),
            "isnotempty" => Expression.NotEqual(member, Expression.Constant(Convert.ChangeType("", member.Type))),
            "startswith" => BuildMethodExpression(nameof(string.StartsWith), member, constant),
            "doesnotstartwith" => Expression.Not(BuildMethodExpression(nameof(string.StartsWith), member, constant)),
            "contains" => BuildMethodExpression(nameof(string.Contains), member, constant),
            "doesnotcontain" => Expression.Not(BuildMethodExpression(nameof(string.Contains), member, constant)),
            "endswith" => BuildMethodExpression(nameof(string.EndsWith), member, constant),
            "doesnotendwith" => Expression.Not(BuildMethodExpression(nameof(string.EndsWith), member, constant)),
            "gt" => Expression.GreaterThan(member, Expression.Constant(null)),
            "gte" => Expression.GreaterThanOrEqual(member, Expression.Constant(null)),
            "lt" => Expression.LessThan(member, constant),
            "lte" => Expression.LessThanOrEqual(member, constant),
            "isnullorempty" => Expression.Or(Expression.Equal(member, Expression.Constant(null)), Expression.Equal(member, Expression.Constant(Convert.ChangeType("", member.Type)))),
            "isnotnullorempty" => Expression.And(Expression.NotEqual(member, Expression.Constant(null)), Expression.NotEqual(member, Expression.Constant(Convert.ChangeType("", member.Type)))),
            // Add other operators like "contains", "startswith", etc.
            _ => throw new NotSupportedException($"Operator {filter.@operator} is not supported.")
        };
    }

    private static Expression BuildMethodExpression(string methodname, MemberExpression member, ConstantExpression constant)
    {
        MethodInfo startsWithMethod = typeof(string).GetMethod(methodname, new[] { typeof(string) }) ?? throw new InvalidOperationException($"No suitable {methodname} method found on string type.");

        // Ensure the member is of type string
        if (member.Type != typeof(string))
            throw new InvalidOperationException($"{methodname} can only be used with string properties.");

        return Expression.Call(member, startsWithMethod, constant);
    }

}
