namespace Data.Data.ECM
{
    public partial class ArtUpdatedWatchList
    {

        public string WatchListName { get; set; } = null!;
        public string? LastInsertedDate { get; set; }
        public int? LastInsertedCount { get; set; }
        public string? DownloadStatus { get; set; }
        public string? LoadStatus { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
