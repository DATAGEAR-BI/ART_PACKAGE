using Data.Constants.db;

namespace ART_PACKAGE.Helpers.CustomReport
{
    public static partial class DbContextExtentions
    {
        public class ViewColumn
        {
            public string Name { get; set; } = null!;

            public string SqlDataType { get; set; } = null!;

            public string IsNullable { get; set; } = null!;


            public string JsDataType
            {
                get
                {
                    if (ColumnsTypesSQLToJSMapper.numberTypes.Any(x => SqlDataType.ToLower().Contains(x.ToLower())))
                        return "number";
                    if (ColumnsTypesSQLToJSMapper.stringTypes.Any(x => SqlDataType.ToLower().Contains(x.ToLower())))
                        return "string";
                    return ColumnsTypesSQLToJSMapper.dateTypes.Any(x => SqlDataType.ToLower().Contains(x.ToLower()))
                        ? "date"
                        : ColumnsTypesSQLToJSMapper.boolTypes.Any(x => SqlDataType.ToLower().Contains(x.ToLower())) ? "boolean" : "string";
                }
            }
        }

    }
}
