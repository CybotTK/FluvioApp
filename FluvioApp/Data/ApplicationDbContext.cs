using FluvioApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FluvioApp.Data
{
    //asta e pasul 3 de la useri si roluri
    // pun applicationuser la baza de date
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<MediaFile> MediaFiles { get; set; }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // definire relatii cu modelele Team si Project (FK) one-to-one
            modelBuilder.Entity<Project>()
                .HasOne<Team>(proj => proj.Team)
                .WithOne(team => team.Project)
                .HasForeignKey<Project>(proj => proj.TeamId);

            // definire relatii cu modelele TeamMember si Team (FK) one-to-many
            modelBuilder.Entity<TeamMember>()
                .HasOne<Team>(teamMember => teamMember.Team)
                .WithMany(team => team.TeamMembers)
                .HasForeignKey(teamMember => teamMember.TeamId);

            // definire relatii cu modelele Assignment si Project (FK) one-to-many
            modelBuilder.Entity<Assignment>()
                .HasOne<Project>(ass => ass.Project)
                .WithMany(proj => proj.Assignments)
                .HasForeignKey(ass => ass.ProjectId);

        }

    }
}

