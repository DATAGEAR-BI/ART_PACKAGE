using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtUpdatedWatchListConfig : ReportConfig
    {
        public ArtUpdatedWatchListConfig()
        {
            //ShowExportPdf = (s => true);
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "WatchListName", new GridColumnConfiguration { DisplayName = "Watch List Name"}},
                    { "LastInsertedDate", new GridColumnConfiguration { DisplayName = "Last Inserted Date"}},
                    { "LastInsertedCount", new GridColumnConfiguration { DisplayName = "Last Inserted Count"}},
                    { "DownloadStatus", new GridColumnConfiguration { DisplayName = "Download Status"}},
                    { "LoadStatus", new GridColumnConfiguration { DisplayName = "Load Status"}},
            };

            ReportTitle = "Updated Watch List Report";
            ReportDescription = "Presents all the updated watch list with the related information as below";
            SkipList = new List<string>
            {
                "UpdateDate"
            };
        }
    }
}
