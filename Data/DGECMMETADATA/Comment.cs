using System;
using System.Collections.Generic;

namespace Data.DGECMMETADATA
{
    public partial class Comment
    {
        public decimal Id { get; set; }
        public string Subject { get; set; } = null!;
        public string? Description { get; set; }
        public decimal EntityRk { get; set; }
        public string EntityType { get; set; } = null!;
        public DateTime UploadDate { get; set; }
        public string DeleteFlg { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public decimal? CommentId { get; set; }
        public string? DescriptionJson { get; set; }
    }
}
