namespace TeamMantaEducationalApi.Models
{
    public class Operation
    {
        public int OperationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EstimatedCompletionTime { get; set; }
        public int ProgressPercentage { get; set; }
        public bool IsDelayed { get; set; }
    }
}