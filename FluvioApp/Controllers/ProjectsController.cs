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
        private readonly ApplicationDbContext db;
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
        }

        //Se afiseaza lista tuturor proiectelor
        [Authorize(Roles = "User,Admin")]
        public IActionResult Index()
        {
            var projects = db.Projects.Include("Assignments").Include("User");
            ViewBag.Projects = projects;   

            return View();
        }

        //Se afiseaza un singur proiect impreuna cu taskurile din el
        //Se afiseaza si userul care a creat proiectul respectiv
        //cat si echipa --> de facut pentru mai tarziu
        [Authorize(Roles = "User,Admin")]
        public IActionResult Show(int id)
        {
            Project project = db.Projects.Include("Assignments").Include("User")
                              .Where(proj => proj.Id == id)
                              .First();

            return View(project);
        }

        //Adaugarea unui task asociat unui proiect in baza de date
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Show([FromForm] Assignment assignment)
        {
            assignment.StartDate = DateTime.Now;

            try
            {

                Project project = db.Projects.Include(p => p.Assignments)
                                             .Where(p => p.Id == assignment.ProjectId && p.UserId == _userManager.GetUserId(User))
                                             .First();

                if (project == null)
                {
                    TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra unui articol care nu va apartine";
                    TempData["messageType"] = "alert-danger";
                    return Redirect("/Projects/Show/" + assignment.ProjectId);
                }

                assignment.UserId = project.UserId;

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
        [Authorize(Roles = "User,Admin")]
        public IActionResult New()
        {
            Project project = new Project();

            return View(project);
        }

        [Authorize(Roles = "User,Admin")]
        //Adaug proiectul in baza de date
        [HttpPost]
        public IActionResult New(Project project)
        {
            project.UserId = _userManager.GetUserId(User);

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
        [Authorize(Roles = "User")]
        public IActionResult Edit(int id)
        {
            Project project = db.Projects
                .Where(proj => proj.Id == id).First();

            var allUsers = db.Users.ToList();
            var allTasks = db.Assignments.
                            Where(ass => ass.ProjectId == id)
                            .ToList();

            ViewBag.AllUsers = allUsers; 
            ViewBag.AllTasks = allTasks;

            if (project.UserId == _userManager.GetUserId(User))
            {
                return View(project);
            }
            else
            {
                TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra unui articol care nu va apartine";
                TempData["messageType"] = "alert-danger";
                return RedirectToAction("Index");
            }

        }

        //Adaugarea persoanelor intr-o echipa asociata unui proiect in baza de date
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult EditTeam(int projectId, string teamName, List<string> selectedUserIds, string selectedTask, string newTeamName)
        {

            // Obtine proiectul si echipa asociata
            Project project = db.Projects
                .Include("Team")
                .Where(proj => proj.Id == projectId)
                .FirstOrDefault();

            if (project.UserId == _userManager.GetUserId(User))
            {
                if (project.Team != null)
                {
                    // Actualizeaza numele echipei cu noul nume introdus in formular
                    project.Team.TeamName = newTeamName;

                    // Adauga utilizatorii selectati în colectia TeamMembers
                    foreach (var userId in selectedUserIds)
                    {
                        var teamMember = new TeamMember
                        {
                            UserId = userId,
                            TeamId = project.Team.Id
                        };

                        project.Team.TeamMembers.Add(teamMember);
                    }

                    // Salvează modificările în baza de date
                    db.SaveChanges();
                }

                // Alege sa incarce lista de membrii ai echipei pentru a o afisa în View
                var teamMembers = db.TeamMembers
                    .Include(tm => tm.User)
                    .Where(tm => tm.TeamId == project.TeamId)
                    .ToList();

                ViewBag.TeamMembers = teamMembers;

                // Redirectează către acțiunea de editare a proiectului (Edit) pentru a afișa modificările
                return RedirectToAction("Edit", new { id = projectId });
            }
            else
            {
                TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra unui articol care nu va apartine";
                TempData["messageType"] = "alert-danger";
                return RedirectToAction("Index");
            }
        }


        //Se adauga proiectul modificat in baza de date
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Edit(int id, Project requestProject) 
        {
            Project project = db.Projects.Find(id);

            if (ModelState.IsValid)
            {
                if (project.UserId == _userManager.GetUserId(User))
                {
                    project.ProjectName = requestProject.ProjectName;
                    project.ProjectDescription = requestProject.ProjectDescription;
                    TempData["message"] = "s-au produs modificarile";
                    TempData["messageType"] = "alert-success";
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra unui articol care nu va apartine";
                    TempData["messageType"] = "alert-danger";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(requestProject);
            }

        }

        //Se sterge proiectul din baza de date
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Delete(int id) 
        {
            Project project = db.Projects.Find(id);

            if (project.UserId == _userManager.GetUserId(User) || User.IsInRole("Admin"))
            {
                db.Projects.Remove(project);
                db.SaveChanges();
                TempData["message"] = "Proiectul a fost sters";
                TempData["messageType"] = "alert-success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Nu aveti dreptul sa stergeti un articol care nu va apartine";
                TempData["messageType"] = "alert-danger";
                return RedirectToAction("Index");
            }
        }

    }
}
