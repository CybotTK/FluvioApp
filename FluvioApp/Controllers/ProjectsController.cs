using FluvioApp.Data;
using FluvioApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluvioApp.Controllers
{
    public class ProjectsController : Controller
    {
        //Introducerea rolurilor si userului
        /*private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ProjectsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }*/

        private readonly ApplicationDbContext db;
        public ProjectsController(
            ApplicationDbContext context
            )
        {
            db = context;
        }

        //Se afiseaza lista tuturor proiectelor
        //[Authorize(Roles = "User,Admin")]
        public IActionResult Index()
        {
            var projects = db.Projects.Include("Assignments");
            ViewBag.Projects = projects;   

            return View();
        }

        //Se afiseaza un singur proiect impreuna cu taskurile din el
        //Se afiseaza si userul care a creat proiectul respectiv
        //cat si echipa --> de facut pentru mai tarziu
        //[Authorize(Roles = "User,Admin")]
        public IActionResult Show(int id)
        {
            Project project = db.Projects.Include("Assignments")
                              .Where(proj => proj.Id == id)
                              .First();

            return View(project);
        }

        //Adaugarea unui task asociat unui proiect in baza de date
        [HttpPost]
        public IActionResult Show([FromForm] Assignment assignment)
        {
            assignment.StartDate = DateTime.Now;

            try
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return Redirect("/Projects/Show/" + assignment.ProjectId);
            }
            catch (Exception e) 
            {
                Project project = db.Projects.Include("Assignments")
                              .Where(proj => proj.Id == assignment.ProjectId)
                              .First();

                return View(project);
            }

        }

        //Se afiseaza formularul
        //in care se va completa datele unui proiect
        public IActionResult New()
        {
            Project project = new Project();

            return View(project);
        }

        //Adaug proiectul in baza de date
        [HttpPost]
        public IActionResult New(Project project)
        {

            if (ModelState.IsValid)
            {
                project.Assignments = new List<Assignment>();
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return View("New");
            }
        }

        //Afisez formularul cu datele proiectului
        public IActionResult Edit(int id)
        {
            Project project = db.Projects.Where(proj => proj.Id == id).First();

            return View(project);
        }

        //Se adauga proiectul modificat in baza de date
        [HttpPost]
        public IActionResult Edit(int id, Project requestProject) 
        {
            Project project = db.Projects.Find(id);

            if (ModelState.IsValid)
            {
                project.ProjectName = requestProject.ProjectName;
                project.ProjectDescription = requestProject.ProjectDescription;
                //probabil trebuie sa adaug si schimbarea TeamId
                TempData["message"] = "s-au produs modificarile";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(requestProject);
            }

        }

        //Se sterge proiectul din baza de date
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            TempData["message"] = "Proiectul a fost sters";
            return RedirectToAction("Index");
        }

    }
}
