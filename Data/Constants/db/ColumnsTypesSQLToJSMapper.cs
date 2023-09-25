namespace Data.Constants.db
{
    public static class ColumnsTypesSQLToJSMapper
    {
        public static List<string> numberTypes = new() { 
                    /*,acle Types*/    "int", "smallint", "bigint", "decimal", "float", "real" ,
                    /*SqlServer Types*/    "int" , "smallint" , "tinyint" , "bigint" , "numeric" , "decimal" , "float" , "real"
                    };
        public static List<string> stringTypes = new() { 
                    /*,acle Types*/   "char" , "varchar2" , "nchar" , "nvarchar2" , "clob" , "nclob",
                    /*SqlServer Types*/    "char" , "varchar" , "nchar" , "nvarchar" , "text" , "ntext" , "xml"
                    };
        public static List<string> dateTypes = new() { 
                    /*,acle Types*/  "date" , "timestamp" , "timestampltz" , "timestamptz",
                    /*SqlServer Types*/     "date" , "datetime" , "datetime2" , "datetimeoffset" , "smalldatetime" , "time"
                    };
        public static List<string> boolTypes = new() { 
                    /*,acle Types*/  "bit",
                    /*SqlServer Types*/    "boolean"
                    };
    }
}
