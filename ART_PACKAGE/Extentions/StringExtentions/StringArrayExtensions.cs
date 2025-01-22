using iTextSharp.text.pdf;

namespace ART_PACKAGE.Extentions.StringExtentions
{
    public static class StringArrayExtensions
    {
        public static string[] MapHeaderNames(this string[] array)
        {
            return Array.ConvertAll(array, MapToHeaderName);
        }
        public static string ProcessToArabic(this string input, int maxLength = 50)
        {
           
            var arabicLanguageProcessor = new ArabicLigaturizer();

            List<string> lines = new List<string>();

            if (string.IsNullOrEmpty(input) || maxLength <= 0)
            {
                return "";
            }

            int currentIndex = 0;
            while (currentIndex < input.Length)
            {
                int length = Math.Min(maxLength, input.Length - currentIndex);
                string line = input.Substring(currentIndex, length);

                // If the line does not end with a space, adjust to split at the last space
                if (line.Length == maxLength && line[maxLength - 1] != ' ')
                {
                    int lastSpaceIndex = line.LastIndexOf(' ');
                    if (lastSpaceIndex != -1)
                    {
                        line = line.Substring(0, lastSpaceIndex);
                    }
                }

                lines.Add(line.Trim());
                currentIndex += line.Length;

                // Skip any leading spaces in the next line
                while (currentIndex < input.Length && input[currentIndex] == ' ')
                {
                    currentIndex++;
                }
            }
            var processedText = (string.Join("\n", lines.Select(a => arabicLanguageProcessor.Process(a))) ?? "");
            return processedText;
        }
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
