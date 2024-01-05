using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string TaskId { get; set; }

        [Required(ErrorMessage = "Comentariul nu poate fi gol")]
        public string Content { get; set; }

        public DateTime Date { get; set; } = (DateTime)default(DateTime?);
    }
}
