using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class Team
    { 
        [Key]   
        public int Id { get; set; }

        public string? TeamName { get; set; }

        public int? TeamId { get; set; }

        public virtual Project? Project { get; set; }

        // O echipa are mai multi TeamMembers
        public virtual ICollection<TeamMember>? TeamMembers { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
