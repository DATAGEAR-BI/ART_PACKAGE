using Microsoft.EntityFrameworkCore;



namespace ART_PACKAGE.Extentions.DbContextExtentions
{
    public static class BulkOperationsExtentions
    {

        public static bool Insert<TModel>(this DbContext _context, IEnumerable<TModel> data)
        {
            if (data == null || !data.Any())
            {
                return false;
            }

            try
            {
                // _context.BulkInsert(data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //if (data == null || !data.Any())
            //{
            //    return false;
            //}


            //if (_context.Database.IsOracle())
            //    return _context.OracleBulkInsert(data);

            //Microsoft.EntityFrameworkCore.Metadata.IEntityType? entityType = _context.Model.FindEntityType(typeof(TModel));
            //string? tableName = entityType?.GetTableName() ?? entityType?.GetViewName();

            //StringBuilder stringBuilder = new();
            //_ = stringBuilder.AppendLine($"INSERT INTO {tableName} (");

            //List<Microsoft.EntityFrameworkCore.Metadata.IProperty> properties = entityType.GetProperties().Where(p => p.PropertyInfo != null && p.Name != "Id").ToList();
            //string columns = string.Join(", ", properties.Select(p => p?.GetColumnName() ?? p.Name));

            //_ = stringBuilder.AppendLine(columns);
            //_ = stringBuilder.AppendLine(") VALUES");

            //List<string> parameterList = new();

            //foreach (TModel entity in data)
            //{
            //    IEnumerable<string> values = properties.Select(p =>
            //    {
            //        object? value = p.PropertyInfo.GetValue(entity);
            //        if (value != null)
            //        {

            //            if (p.PropertyInfo.PropertyType == typeof(string) || Nullable.GetUnderlyingType(p.PropertyInfo.PropertyType) == typeof(string))
            //            {
            //                // Escape single quotes in string values
            //                value = ((string?)value)?.Replace("'", "''"); // Handle nullable string
            //                return $"'{value}'";
            //            }
            //            else
            //            {
            //                return p.PropertyInfo.PropertyType == typeof(DateTime) || Nullable.GetUnderlyingType(p.PropertyInfo.PropertyType) == typeof(DateTime)
            //                    ? $"'{(DateTime)value:yyyy-MM-dd HH:mm:ss}'"
            //                    : $"{value}";
            //            }
            //        }
            //        else
            //        {
            //            return "NULL";
            //        }
            //    });

            //    parameterList.Add($"({string.Join(", ", values)})");
            //}

            //_ = stringBuilder.AppendLine(string.Join(",\n", parameterList));
            //_ = stringBuilder.AppendLine(";");


            //string insertStatment = stringBuilder.ToString();
            //int effected = _context.Database.ExecuteSqlRaw(insertStatment);
            //return effected > 0;
        }


        //private static bool OracleBulkInsert<TModel>(this DbContext _context, IEnumerable<TModel> data)
        //{
        //    Microsoft.EntityFrameworkCore.Metadata.IEntityType? entityType = _context.Model.FindEntityType(typeof(TModel));
        //    string? tableName = entityType?.GetTableName() ?? entityType?.GetViewName();
        //    OracleConnection connection = (OracleConnection)_context.Database.GetDbConnection();
        //    OracleBulkCopy bulkCopy = new(connection)
        //    {
        //        DestinationTableName = tableName // Replace with your table name
        //    };
        //    try
        //    {
        //        DataTable dataTable = new();
        //        List<Microsoft.EntityFrameworkCore.Metadata.IProperty> properties = entityType.GetProperties().Where(p => p.PropertyInfo != null && p.Name != "Id").ToList();
        //        foreach (Microsoft.EntityFrameworkCore.Metadata.IProperty property in properties)
        //        {
        //            _ = dataTable.Columns.Add(property?.GetColumnName());
        //        }
        //        foreach (TModel? item in data)
        //        {
        //            DataRow row = dataTable.NewRow();

        //            foreach (Microsoft.EntityFrameworkCore.Metadata.IProperty prop in properties)
        //            {
        //                row[prop?.GetColumnName()] = prop.PropertyInfo.GetValue(item, null);
        //            }

        //            dataTable.Rows.Add(row);
        //        }
        //        connection.Open();
        //        bulkCopy.WriteToServer(dataTable.Select());
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;

        //    }
        //    //Microsoft.EntityFrameworkCore.Metadata.IEntityType? entityType = _context.Model.FindEntityType(typeof(TModel));
        //    //string? tableName = entityType?.GetTableName() ?? entityType?.GetViewName();

        //    //StringBuilder stringBuilder = new();
        //    //string Begin = "Begin";
        //    //string End = "End;";

        //    //stringBuilder.AppendLine(Begin);

        //    //List<Microsoft.EntityFrameworkCore.Metadata.IProperty> properties = entityType.GetProperties().Where(p => p.PropertyInfo != null && p.Name != "Id").ToList();
        //    //string columns = string.Join(", ", properties.Select(p => p?.GetColumnName() ?? p.Name));



        //    //List<string> parameterList = new();

        //    //foreach (TModel entity in data)
        //    //{
        //    //    stringBuilder.AppendLine($"INSERT INTO {tableName} (");
        //    //    stringBuilder.AppendLine(columns);
        //    //    stringBuilder.AppendLine(") VALUES");
        //    //    IEnumerable<string> values = properties.Select(p =>
        //    //    {
        //    //        object? value = p.PropertyInfo.GetValue(entity);
        //    //        if (value != null)
        //    //        {

        //    //            if (p.PropertyInfo.PropertyType == typeof(string) || Nullable.GetUnderlyingType(p.PropertyInfo.PropertyType) == typeof(string))
        //    //            {
        //    //                // Escape single quotes in string values
        //    //                value = ((string?)value)?.Replace("'", "''"); // Handle nullable string
        //    //                return $"'{value}'";
        //    //            }
        //    //            else
        //    //            {
        //    //                return p.PropertyInfo.PropertyType == typeof(DateTime) || Nullable.GetUnderlyingType(p.PropertyInfo.PropertyType) == typeof(DateTime)
        //    //                    ? $"'{(DateTime)value:yyyy-MM-dd HH:mm:ss}'"
        //    //                    : $"{value}";
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            return "NULL";
        //    //        }
        //    //    });

        //    //    stringBuilder.AppendLine($"({string.Join(", ", values)});");
        //    //}

        //    //stringBuilder.AppendLine(string.Join(";\n", parameterList));
        //    //stringBuilder.AppendLine(End);


        //    //try
        //    //{
        //    //    _context.Database.ExecuteSqlRaw(stringBuilder.ToString());
        //    //    return true;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return false;
        //    //}
        //}
    }
}
