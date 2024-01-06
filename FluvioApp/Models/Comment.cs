using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int? AssignmentId { get; set; }

        public virtual Assignment? Assignment { get; set; }

        // User care a lasat comentariul
        public string? UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }

        [Required(ErrorMessage = "Comentariul nu poate fi gol")]
        public string Content { get; set; }

        // Retinem timestamp la care a fost creat comentariul
        public DateTime Date { get; set; } = (DateTime)default(DateTime?);
    }
}
