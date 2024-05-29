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
}
