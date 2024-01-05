using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class Team
    { 
        [Key]
        public int Id { get; set; }

        public string TeamName { get; set; }

        //o echipa poate lucra la mai multe proiecte
        public virtual ICollection<Project> Projects { get; set; }
    }
}
