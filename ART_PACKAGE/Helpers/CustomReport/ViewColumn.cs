namespace ART_PACKAGE.Helpers.CustomReportHelpers
{
    public static partial class DbContextExtentions
    {
        public class ViewColumn
        {
            public string Name { get; set; } = null!;

            public string SqlDataType { get; set; } = null!;

            public string IsNullable { get; set; } = null!;

            public string JsDataType => SqlDataType.ToLower() switch
            {
                "number" or "int" or "smallint" or "bigint" or "decimal" or "float" or "real" => "number",
                "char" or "varchar2" or "nchar" or "nvarchar2" or "clob" or "nclob" => "string",
                "date" or "timestamp" or "timestampltz" or "timestamptz" => "Date",
                "boolean" => "boolean",
                "int" or "smallint" or "tinyint" or "bigint" or "numeric" or "decimal" or "float" or "real" => "number",
                "bit" => "boolean",
                "date" or "datetime" or "datetime2" or "datetimeoffset" or "smalldatetime" or "time" => "date",
                "char" or "varchar" or "nchar" or "nvarchar" or "text" or "ntext" or "xml" => "text",
                _ => "text",// Fallback to "any" if there's no direct mapping.
            };
        }

    }
}
