namespace Data.Data.FTI
{
    public class ArtFtiEndToEndEcmEventsWorkflow
    {
        public string? EcmReference { get; set; }//ECM_REFERENCE
        public string? CaseComments { get; set; }//CASE_COMMENTS
        public string? EcmEventStep { get; set; }//ECM_EVENT_STEP
        public string? EcmEventCreatedBy { get; set; }//ECM_EVENT_CREATED_BY
        public DateTime? EcmEventCreatedDate { get; set; }//ECM_EVENT_CREATED_DATE
        public string? EcmEventTimeDifference { get; set; }//ECM_EVENT_TIM_EDIFFERENCE
    }
}
