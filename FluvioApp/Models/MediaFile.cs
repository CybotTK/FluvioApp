using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class MediaFile
    {
        [Key]
        public string Id { get; set; }

        public int AssignmentId { get; set; }

        public virtual Assignment? Assignment { get; set; }

        public string Type { get; set; }

        [Required(ErrorMessage = "Fiecare resursa necesita un link")]
        public string Link { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
