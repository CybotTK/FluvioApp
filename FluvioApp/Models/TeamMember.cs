using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ProjectId { get; set; }
    }
}
