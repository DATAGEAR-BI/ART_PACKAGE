﻿
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using Filter = Data.Services.Grid.Filter;

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
        Type memType = member.Type;
        ConstantExpression constant = BuildConstantExpression(memType, filter.value);//Expression.Constant(Convert.ChangeType(filter.value, member.Type));
        return filter.@operator switch
        {
            "eq" => !IsDateTimeOrNullableDateTime(member.Type) ? Expression.Equal(member, constant) : Expression.Equal(GetDatePropertyExpression(member), GetDatePropertyExpression(constant)),
            "neq" => !IsDateTimeOrNullableDateTime(member.Type) ? Expression.NotEqual(member, constant) : Expression.NotEqual(GetDatePropertyExpression(member), GetDatePropertyExpression(constant)),
            "isnull" => Expression.Equal(member, Expression.Constant(null, member.Type)),
            "isnotnull" => Expression.NotEqual(member, Expression.Constant(null, member.Type)),
            "isempty" => Expression.Equal(member, Expression.Constant(Convert.ChangeType("", member.Type))),
            "isnotempty" => Expression.NotEqual(member, Expression.Constant(Convert.ChangeType("", member.Type))),
            "startswith" => BuildMethodExpression<string>(nameof(string.StartsWith), member, constant),
            "doesnotstartwith" => Expression.Not(BuildMethodExpression<string>(nameof(string.StartsWith), member, constant)),
            "contains" => BuildMethodExpression<string>(nameof(string.Contains), member, constant),
            "doesnotcontain" => Expression.Not(BuildMethodExpression<string>(nameof(string.Contains), member, constant)),
            "endswith" => BuildMethodExpression<string>(nameof(string.EndsWith), member, constant),
            "doesnotendwith" => Expression.Not(BuildMethodExpression<string>(nameof(string.EndsWith), member, constant)),
            "gt" => !IsDateTimeOrNullableDateTime(member.Type) ? Expression.GreaterThan(member, constant) : Expression.GreaterThan(GetDatePropertyExpression(member), GetDatePropertyExpression(constant)),
            "gte" => !IsDateTimeOrNullableDateTime(member.Type) ? Expression.GreaterThanOrEqual(member, constant) : Expression.GreaterThanOrEqual(GetDatePropertyExpression(member), GetDatePropertyExpression(constant)),
            "lt" => !IsDateTimeOrNullableDateTime(member.Type) ? Expression.LessThan(member, constant) : Expression.LessThan(GetDatePropertyExpression(member), GetDatePropertyExpression(constant)),
            "lte" => !IsDateTimeOrNullableDateTime(member.Type) ? Expression.LessThanOrEqual(member, constant) : Expression.LessThanOrEqual(GetDatePropertyExpression(member), GetDatePropertyExpression(constant)),
            "isnullorempty" => Expression.Or(Expression.Equal(member, Expression.Constant(null, member.Type)), Expression.Equal(member, Expression.Constant(Convert.ChangeType("", member.Type)))),
            "isnotnullorempty" => Expression.And(Expression.NotEqual(member, Expression.Constant(null, member.Type)), Expression.NotEqual(member, Expression.Constant(Convert.ChangeType("", member.Type)))),
            _ => throw new NotSupportedException($"Operator {filter.@operator} is not supported.")
        };

    }

    private static Expression BuildMethodExpression<T>(string methodname, MemberExpression member, ConstantExpression constant)
    {
        MethodInfo startsWithMethod = typeof(T).GetMethod(methodname, new[] { typeof(string) }) ?? throw new InvalidOperationException($"No suitable {methodname} method found on string type.");

        // Ensure the member is of type string
        if (member.Type != typeof(T))
            throw new InvalidOperationException($"{methodname} can only be used with string properties.");

        return Expression.Call(member, startsWithMethod, constant);
    }


    public static MemberExpression GetDatePropertyExpression(Expression memberExpression)
    {
        if (memberExpression == null)
        {
            throw new ArgumentNullException(nameof(memberExpression));
        }

        Type memberType = memberExpression.Type;
        _ = typeof(DateTime).GetMethod("ToLocalTime");

        // Check if the member is a nullable DateTime
        if (Nullable.GetUnderlyingType(memberType) == typeof(DateTime))
        {
            MemberExpression valueProperty = Expression.Property(memberExpression, "Value");
            return Expression.Property(valueProperty, "Date");
        }
        else if (memberType == typeof(DateTime))
        {

            return Expression.Property(memberExpression, "Date");
        }
        else
        {
            throw new ArgumentException("The member is not a DateTime or nullable DateTime type.", nameof(memberExpression));
        }
    }



    private static ConstantExpression BuildConstantExpression(Type fieldType, object value)
    {
        if (fieldType == typeof(DateTime) || Nullable.GetUnderlyingType(fieldType) == typeof(DateTime))
        {
            DateTime dateTime = value is DateTime
                ? ((DateTime)value).ToLocalTime()
                : value is JsonElement jsonElement && jsonElement.TryGetDateTime(out dateTime)
                    ? dateTime.ToLocalTime()
                    : throw new ArgumentException("Invalid date format or value.");
            return Expression.Constant(dateTime.Date, fieldType);
        }
        MethodInfo? method = typeof(FilterExtensions)?.GetMethod(nameof(FilterExtensions.ToObject))?.MakeGenericMethod(fieldType);
        object? @const = method?.Invoke(null, new object[] { (JsonElement)value });
        return Expression.Constant(ConvertToNullableType(@const, fieldType), fieldType);



    }

    public static T ToObject<T>(this JsonElement element)
    {

        string json = element.GetRawText();

        return JsonSerializer.Deserialize<T>(json);
    }

    public static bool IsDateTimeOrNullableDateTime(Type type)
    {
        if (type == null)
        {
            return false;
        }

        // Check if the type is DateTime
        if (type == typeof(DateTime))
        {
            return true;
        }

        // Check if the type is a nullable type and its underlying type is DateTime
        if (Nullable.GetUnderlyingType(type) == typeof(DateTime))
        {
            return true;
        }

        return false;
    }


    private static object ConvertToNullableType(object value, Type targetType)
    {
        if (value == null || Convert.IsDBNull(value))
        {
            return null;
        }

        Type nonNullableType = Nullable.GetUnderlyingType(targetType) ?? targetType;
        return Convert.ChangeType(value, nonNullableType);
    }


    private static bool IsNumericType(Type type)
    {
        return Type.GetTypeCode(type) switch
        {
            TypeCode.Byte or TypeCode.Decimal or TypeCode.Double or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 or TypeCode.SByte or TypeCode.Single or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 => true,
            _ => false,
        };
    }


}