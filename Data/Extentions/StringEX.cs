using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extentions
{
    public static class StringEX
    {
        public static string MapToHeaderName(this string header)
        {
            // Split the entity name by underscores
            string[] parts = header.Split('_');

            // Capitalize the first letter of each part
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Length > 0 ? char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower() : parts[i];
            }
            var h = string.Join(" ", parts);
            // Join the parts with spaces
            return string.Join(" ", parts);
        }
    }
}
