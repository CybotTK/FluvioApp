using System.ComponentModel.DataAnnotations;

namespace FluvioApp.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Proiectul trebuie sa aiba un nume")]
        public string ProjectName { get; set; }

        //un proiect poate fi creat de un singur user
        public string? UserId { get; set; }

        //la un proiect pot avea o singura echipa
        public int? TeamId { get; set; }
    }
}
