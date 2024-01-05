using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class Team
    { 
        [Key]   
        public int Id { get; set; }

        public string? TeamName { get; set; }

        // O echipa are mai multi TeamMembers
        public virtual ICollection<TeamMember>? TeamMembers { get; set; }
    }
}
