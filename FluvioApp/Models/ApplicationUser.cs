using Microsoft.AspNetCore.Identity;

namespace FluvioApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        //un user poate crea mai multe proiecte
        public virtual ICollection<Project> Projects { get; set; }  

        //un user poate crea mai multe taskuri
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}