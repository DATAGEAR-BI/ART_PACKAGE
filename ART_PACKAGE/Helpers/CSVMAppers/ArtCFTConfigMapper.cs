using CsvHelper.Configuration;
using Data.Data.ECM;
using HtmlAgilityPack;
using System.Text;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ArtCFTConfigMapper : ClassMap<ArtCFTConfig>
    {
        private readonly List<string> _includedColumns;
        public ArtCFTConfigMapper(List<string> includedColumns)
        {
            _includedColumns = includedColumns;
            DictionaryConverter converter = new(_includedColumns);
            Map(x => x.CaseId).Name("Case Id");
            Map(x => x.Maker).Name("Maker");
            Map(x => x.Checker).Name("Checker");
            Map(x => x.MakerDate).Name("Maker Date");
            Map(x => x.CheckerDate).Name("Checker Date");
            Map(x => x.CheckerAction).Name("Checker Action");
            Map(x => x.ActionDetail).Convert(arg => ConvertHtmlToTableLikeString(arg.Value.ActionDetail)).Name("Action Detail");
        }

        string ConvertHtmlToTableLikeString(string htmlText)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlText);

            // Remove script and style elements
            htmlDoc.DocumentNode.Descendants()
                .Where(n => n.Name == "script" || n.Name == "style")
                .ToList()
                .ForEach(n => n.Remove());

            StringBuilder stringBuilder = new StringBuilder();

            // Find and append the non-table text content
            var nonTableTexts = htmlDoc.DocumentNode.SelectNodes("//div/p");
            if (nonTableTexts != null)
            {
                foreach (var text in nonTableTexts)
                {
                    stringBuilder.AppendLine(text.InnerText.Trim());
                }
                stringBuilder.AppendLine(); // Add extra line break after non-table texts
            }

            // Process each 'column' div (assuming each contains a separate table or label)
            var columns = htmlDoc.DocumentNode.SelectNodes("//div/div");
            if (columns != null)
            {
                foreach (var column in columns)
                {
                    var labels = column.SelectNodes(".//label");
                    if (labels != null)
                    {
                        foreach (var label in labels)
                        {
                            stringBuilder.AppendLine(label.InnerText.Trim());
                        }
                    }

                    var table = column.SelectSingleNode(".//table");
                    if (table != null)
                    {
                        // Process each row in the table
                        var rows = table.SelectNodes(".//tr");
                        foreach (var row in rows)
                        {
                            // Process each cell in the row
                            if (string.IsNullOrEmpty(row.InnerHtml))
                                continue;



                            foreach (var cell in row.SelectNodes(".//th|td"))
                            {
                                // Append the text from the cell, followed by a fixed number of spaces
                                stringBuilder.Append(cell.InnerText.Trim().PadRight(25, ' ') + "    "); // 4 spaces
                            }
                            stringBuilder.AppendLine(); // New line at the end of each row
                        }
                    }
                    stringBuilder.AppendLine(); // Extra line to separate sections
                }
            }

            return stringBuilder.ToString().Trim(); // Trim to remove the last new line
        }
    }


}