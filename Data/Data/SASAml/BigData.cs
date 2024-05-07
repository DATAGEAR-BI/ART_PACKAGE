namespace Data.Data.SASAml
{
    public class BigData
    {

        public decimal EntityWatchListKey { get; set; } // Non-nullable
        public string EntityWatchListNumber { get; set; } // Non-nullable
        public string WatchListName { get; set; } // Non-nullable
        public string? CategoryDesc { get; set; } // Nullable
        public string? TypeDesc { get; set; } // Nullable
        public string? FirstName { get; set; } // Nullable
        public string? LastName { get; set; } // Nullable
        public string? EntityName { get; set; } // Nullable
        public string? EntityTitle { get; set; } // Nullable
        public string? OccupationDesc { get; set; } // Nullable
        public string? CityName { get; set; } // Nullable
        public string? StateName { get; set; } // Nullable
        public string? CountryCode { get; set; } // Nullable
        public string? CountryName { get; set; } // Nullable
        public string? FullAddress { get; set; } // Nullable
        public string? NationalityCountryCode { get; set; } // Nullable
        public string? NationalityCountryName { get; set; } // Nullable
        public char? PoliticallyExposedPersonInd { get; set; } // Nullable
        public DateTime? CreateDate { get; set; } // Nullable
        public DateTime? UpdateDate { get; set; } // Nullable
        public char? ExcludeInd { get; set; } // Nullable
        public DateTime ChangeBeginDate { get; set; } // Non-nullable
        public DateTime ChangeEndDate { get; set; } // Non-nullable
        public char ChangeCurrentInd { get; set; } // Non-nullable
    }
}
