namespace usadmin_dashboard.Models
{
    public class AuditLogs
    {
        public uint TrailLogIndex { get; set; }
        public uint UserIndex { get; set; }
        public string UserEmail { get; set; }
        public string Operation { get; set; }
        public string OperationOnTable { get; set; }
        public uint RecordIndex { get; set; }
        public string Json { get; set; }
        public string Changes { get; set; }
        public DateTime Created { get; set; }
    }
}
