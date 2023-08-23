
namespace Data.Data.AmlAnalysis
{
    public class ArtAmlAnalysisRule
    {

        public int Id { get; set; }
        public string ReadableOutPut { get; set; } = null!;
        public string TableName { get; set; } = null!;
        public string Sql { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? Action { get; set; }
        public string? RouteToUser { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }


    }
}
