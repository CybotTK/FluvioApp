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
        /*private readonly UserManager<ApplicationUser> _userManager;
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
        public AssignmentsController(
            ApplicationDbContext context
            )
        {
            db = context;
        }

        public IActionResult Delete(int id)
        {
            Assignment ass = db.Assignments.Find(id);
            db.Assignments.Remove(ass);
            db.SaveChanges();

            return Redirect("/Projects/Show/" + ass.ProjectId);
        }

        public IActionResult Edit(int id)
        {
            Assignment ass = db.Assignments.Find(id);

            return View(ass);
        }

        [HttpPost]
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


        [HttpPost]
        // [Authorize(Roles = "User,Editor,Admin")]
        public IActionResult Edit([FromForm] Comment comment)
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
                // SetAccessRights
                return View();
            }
        }
    }
}
