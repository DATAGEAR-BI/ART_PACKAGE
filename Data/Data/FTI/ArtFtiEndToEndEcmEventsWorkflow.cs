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
        public string? Assignee { get; set; }//ASSIGNEE
        public string? AssignedBy { get; set; }//ASSIGNED_BY
        public DateTime? AssignedTime { get; set; }//ASSIGNED_TIME
        public string? UnAssignee { get; set; }//UNASSIGNEE
        public string? UnAssignedBy { get; set; }//UNASSIGNED_BY
        public DateTime? UnAssignedTime { get; set; }//UNASSIGNED_TIME
        public string? AssignedTimeDifference { get; set; }//ASSIGN_TIME_DIFFERENCE
    }
}
