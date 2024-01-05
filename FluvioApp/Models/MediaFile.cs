using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class MediaFile
    {
        [Key]
        public string Id { get; set; }

        public string TaskId { get; set; }

        public string Type { get; set; }

        [Required(ErrorMessage = "Fiecare resursa necesita un link")]
        public string Link { get; set; }


    }
}
