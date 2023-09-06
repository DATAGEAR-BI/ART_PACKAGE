namespace Data.FCFKC.AmlAnalysis
{
    public partial class FskComment
    {
        public decimal CommentId { get; set; }
        public string ObjectTypeCd { get; set; } = null!;
        public string ObjectId { get; set; } = null!;
        public string? CommentText { get; set; }
        public string CommentCategoryCd { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public string? LstupdateUserId { get; set; }
        public DateTime? LstupdateDate { get; set; }
        public string LogicalDeleteInd { get; set; } = null!;
    }
}
