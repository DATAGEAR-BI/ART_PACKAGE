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
                    List<string> numberTypes = new() { 
                    /*,acle Types*/    "int", "smallint", "bigint", "decimal", "float", "real" ,
                    /*SqlServer Types*/    "int" , "smallint" , "tinyint" , "bigint" , "numeric" , "decimal" , "float" , "real"
                    };
                    List<string> stringTypes = new() { 
                    /*,acle Types*/   "char" , "varchar2" , "nchar" , "nvarchar2" , "clob" , "nclob",
                    /*SqlServer Types*/    "char" , "varchar" , "nchar" , "nvarchar" , "text" , "ntext" , "xml"
                    };
                    List<string> dateTypes = new() { 
                    /*,acle Types*/  "date" , "timestamp" , "timestampltz" , "timestamptz",
                    /*SqlServer Types*/     "date" , "datetime" , "datetime2" , "datetimeoffset" , "smalldatetime" , "time"
                    };
                    List<string> boolTypes = new() { 
                    /*,acle Types*/  "bit",
                    /*SqlServer Types*/    "boolean"
                    };
                    return numberTypes.Any(x => SqlDataType.ToLower().Contains(x.ToLower()))
                        ? "number"
                        : stringTypes.Any(x => SqlDataType.ToLower().Contains(x.ToLower()))
                        ? "string"
                        : dateTypes.Any(x => SqlDataType.ToLower().Contains(x.ToLower()))
                        ? "date"
                        : boolTypes.Any(x => SqlDataType.ToLower().Contains(x.ToLower())) ? "boolean" : "string";
                }
            }
        }

    }
}
