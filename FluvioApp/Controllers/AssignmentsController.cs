using FluvioApp.Data;
using FluvioApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FluvioApp.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AssignmentsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles ="User")]
        public IActionResult Delete(int id)
        {
            Assignment ass = db.Assignments.Find(id);

            if (ass.UserId == _userManager.GetUserId(User))
            {
                db.Assignments.Remove(ass);
                db.SaveChanges();

                return Redirect("/Projects/Show/" + ass.ProjectId);
            }
            else
            {
                TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra unui articol care nu va apartine";
                TempData["messageType"] = "alert-danger";
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "User")]
        public IActionResult Edit(int id)
        {

            Assignment ass = db.Assignments.Find(id);

            if (ass.UserId == _userManager.GetUserId(User))
                return View(ass);
            else
            {
                TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra unui articol care nu va apartine";
                TempData["messageType"] = "alert-danger";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Edit(int id, Assignment requestAssignment)
        {
            Assignment ass = db.Assignments.Find(id);

            if (ModelState.IsValid)
            {
                ass.Status = requestAssignment.Status;
                ass.Title = requestAssignment.Title;
                ass.Description = requestAssignment.Description;

                db.SaveChanges();

                return Redirect("/Projects/Show/" + ass.ProjectId);
            }
            else
            {
                return View(requestAssignment);
            }

        }

        /*
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult EditComment([FromForm] Comment comment)
        {
            comment.Date = DateTime.Now;
            // comment.UserId = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return Redirect("/Assignment/Edit/" + comment.AssignmentId);
            }

            else
            {
                
                return View();
            }
        }
        */
    }
}
