using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titlul taskului este obligatoriu")]
        [StringLength(30, ErrorMessage = "Titlul nu poate avea mai mult de 30 de caractere")]
        [MinLength(5, ErrorMessage = "Titlul trebuie sa aiba mai mult de 5 caractere")]
        public string Title { get; set; }
    
        public string? Description { get; set; }

        [Required(ErrorMessage = "Statusul trebuie completat")]
        public int Status { get; set; }
    
        public DateTime StartDate { get; set; } = (DateTime)default(DateTime?);

        public DateTime? EndDate { get; set;}

        //Un task poate fi creat de un singur user
        public string UserId { get; set; }

        //Un task trebuie sa apartina de un singur proiect
        public int ProjectId { get; set; }

        //Useri si roluri
        public virtual ApplicationUser? User { get; set; }


    }
}
