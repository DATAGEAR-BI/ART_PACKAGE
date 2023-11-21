namespace Data.Data.FTI
{
    public class ArtFtiEndToEndFtiEventsWorkflow
    {
        public string? FtiReference { get; set; } //FTI_REFERENCE
        public string? EventSteps { get; set; }//Event_Steps
        public string? StepStatus { get; set; }//STEP_STATUS
        public DateTime? StartedTime { get; set; }//STARTED_TIME
        public DateTime? LastModTime { get; set; }//LAST_MOD_TIME
        public string? TimeDifference { get; set; }//TIMEDIFFERENCE
        public string? LastModUser { get; set; }//LAST_MOD_USER
    }
}
