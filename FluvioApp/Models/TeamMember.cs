using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluvioApp.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int TeamId { get; set; }

        public virtual Team? Team { get; set; } 

        public virtual ApplicationUser User { get; set; }
    }
}
