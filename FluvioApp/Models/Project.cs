using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluvioApp.Models
{
    public class Project
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Numele proiectului nu poate avea mai mult de 100 de caractere")]
        [MinLength(5, ErrorMessage = "Numele proiectului trebuie sa aiba mai mult de 5 caractere")]
        [Required(ErrorMessage = "Proiectul trebuie sa aiba un nume")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Descrierea proiectului este necesara")]
        public string ProjectDescription { get; set; }

        //un proiect poate fi creat de un singur user
        public string? UserId { get; set; }

        //la un proiect pot avea o singura echipa
        public int? TeamId { get; set; }

        public virtual Team? Team { get; set; }

        //Fac o colectie de tip Assignment(Task)
        //pentru a afisa taskurile din proiect
        public virtual ICollection<Assignment>? Assignments { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
