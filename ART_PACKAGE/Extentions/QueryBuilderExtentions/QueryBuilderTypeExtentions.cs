namespace ART_PACKAGE.Extentions.QueryBuilderExtentions
{
    public static class QueryBuilderTypeExtentions
    {
        private static readonly HashSet<Type> IntTypes = new()
        {
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort)
        };
        private static readonly HashSet<Type> DoubleTypes = new()
        {
            typeof(decimal),
            typeof(float),
            typeof(double),
        };
        private static readonly HashSet<Type> DateTypes = new()
        {
            typeof(DateTime),

        };
        private static readonly HashSet<Type> BoolTypes = new()
        {
            typeof(bool),

        };



        internal static string GetQueryBuilderType(this Type type)
        {
            return IntTypes.Contains(type) ||
                   IntTypes.Contains(Nullable.GetUnderlyingType(type))
                ? "integer"
                : DoubleTypes.Contains(type) ||
                   DoubleTypes.Contains(Nullable.GetUnderlyingType(type))
                ? "double"
                : DateTypes.Contains(type) ||
                   DateTypes.Contains(Nullable.GetUnderlyingType(type))
                ? "date"
                : BoolTypes.Contains(type) ||
                   BoolTypes.Contains(Nullable.GetUnderlyingType(type))
                ? "boolean"
                : "string";
        }
    }
}
