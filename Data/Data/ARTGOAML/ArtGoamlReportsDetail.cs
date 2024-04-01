namespace Data.Data.ARTGOAML
{
    public partial class ArtGoamlReportsDetail
    {
        public int Id { get; set; }
        public string? Reportcode { get; set; }

        public string? Reportstatuscode { get; set; }
        public DateTime? Reportcreateddate { get; set; }

        public DateTime? Submissiondate { get; set; }
        public string? Priority { get; set; }

        public string? Reportuserlockid { get; set; }
        public string? Reportcreatedby { get; set; }
        public string? Action { get; set; }
        public string? Currencycodelocal { get; set; }

        public DateTime? LastUpdatedDate { get; set; }


        public string? Entityreference { get; set; }
        public string? Fiurefnumber { get; set; }
        public string? Rentitybranch { get; set; }
        public string? Reportingpersontype { get; set; }


        public string? Reason { get; set; }
        public DateTime? Reportcloseddate { get; set; }




        public string? Version { get; set; }
        public bool? Isvalid { get; set; }
        public string? Location { get; set; }
        public int Rentityid { get; set; }
        public string? Reportrisksignificance { get; set; }
        public string? Reportxml { get; set; }
        public string? Submissioncode { get; set; }
    }
}
