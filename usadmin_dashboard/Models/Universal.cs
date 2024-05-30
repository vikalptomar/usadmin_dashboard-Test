using System.ComponentModel.DataAnnotations.Schema;

namespace usadmin_dashboard.Models
{
    public class Universal
    {
        [NotMapped]
        public int Id { get; set; }
        [NotMapped]
        public string Email { get; set; }
    }
    public class UserEmailCountDto
    {
        [NotMapped]
        public string UserEmail { get; set; }
        [NotMapped]
        public int RecordCount { get; set; }
        [NotMapped]
        public List<UserActivityDto> Activity { get; set; }

    }
    public class UserActivityDto
    {
        [NotMapped]
        public string OperationOn { get; set; }

        [NotMapped]
        public OperationsDto Operations { get; set; }
    }
    public class OperationsDto
    {
        [NotMapped]
        public List<int> Add { get; set; }

        [NotMapped]
        public List<int> Update { get; set; }
    }
}
