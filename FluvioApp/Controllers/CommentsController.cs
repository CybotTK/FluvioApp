<<<<<<< Updated upstream
﻿using FluvioApp.Data;
using FluvioApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FluvioApp.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CommentsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult New(Comment comm)
        {
            return View();
        }

        [HttpPost]
        // [Authorize(Roles = "User,Editor,Admin")]
        public IActionResult Delete(int id)
        {
            Comment comm = db.Comments.Find(id);

            if (comm.UserId == _userManager.GetUserId(User) || User.IsInRole("Admin"))
            {
                db.Comments.Remove(comm);
                db.SaveChanges();
                return Redirect("/Assignment/Edit/" + comm.AssignmentId);
            }

            else
            {
                TempData["message"] = "Nu aveti dreptul sa stergeti comentariul";
                TempData["messageType"] = "alert-danger";
                return RedirectToAction("Show", "Projects");
            }
            

            return Redirect("/Assignment/Edit/" + comm.AssignmentId);
        }

        [Authorize(Roles = "User,Editor,Admin")]
        public IActionResult Edit(int id)
        {
           
            Comment comm = db.Comments.Find(id);

           
           if (comm.UserId == _userManager.GetUserId(User) || User.IsInRole("Admin"))
           {
               return View(comm);
           }

           else
           {
               TempData["message"] = "Nu aveti dreptul sa editati comentariul";
               TempData["messageType"] = "alert-danger";
               return RedirectToAction("Show", "Projects");
           }
           

            return View(comm);
        }

        [HttpPost]
        [Authorize(Roles = "User,Editor,Admin")]
        public IActionResult Edit(int id, Comment requestComment)
        {
            Comment comm = db.Comments.Find(id);

            if (comm.UserId == _userManager.GetUserId(User) || User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    comm.Content = requestComment.Content;
                    db.SaveChanges();
                    return Redirect("/Assignment/Edit/" + comm.AssignmentId);
                }
                else
                {
                    return View(requestComment);
                }
            
            }
            else
            {
                TempData["message"] = "Nu aveti dreptul sa faceti modificari";
                TempData["messageType"] = "alert-danger";
                return RedirectToAction("Show", "Projects");
            }
            
        }
    }
}
=======
﻿using FluvioApp.Data;
using FluvioApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FluvioApp.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CommentsController(ApplicationDbContext contenxt)
        {
            db = contenxt;
        }

        [HttpPost]
        // [Authorize(Roles = "User,Editor,Admin")]
        public IActionResult Delete(int id)
        {
            Comment comm = db.Comments.Find(id);

            /*
            if (comm.UserId == _userManager.GetUserId(User) || User.IsInRole("Admin"))
            {
                db.Comments.Remove(comm);
                db.SaveChanges();
                return Redirect("/Assignment/Edit/" + comm.AssignmentId);
            }

            else
            {
                TempData["message"] = "Nu aveti dreptul sa stergeti comentariul";
                TempData["messageType"] = "alert-danger";
                return RedirectToAction("Show", "Projects");
            }
            */

            return Redirect("/Assignment/Edit/" + comm.AssignmentId);
        }

        // [Authorize(Roles = "User,Editor,Admin")]
        public IActionResult Edit(int id)
        {
           
            Comment comm = db.Comments.Find(id);

           /*
           if (comm.UserId == _userManager.GetUserId(User) || User.IsInRole("Admin"))
           {
               return View(comm);
           }

           else
           {
               TempData["message"] = "Nu aveti dreptul sa editati comentariul";
               TempData["messageType"] = "alert-danger";
               return RedirectToAction("Show", "Projects");
           }
           */

            return View(comm);
        }

        [HttpPost]
        [Authorize(Roles = "User,Editor,Admin")]
        public IActionResult Edit(int id, Comment requestComment)
        {
            Comment comm = db.Comments.Find(id);

            // if (comm.UserId == _userManager.GetUserId(User) || User.IsInRole("Admin"))
            // {
                if (ModelState.IsValid)
                {
                    comm.Content = requestComment.Content;
                    db.SaveChanges();
                    return Redirect("/Assignment/Edit/" + comm.AssignmentId);
                }
                else
                {
                    return View(requestComment);
                }
            /*
            }
            else
            {
                TempData["message"] = "Nu aveti dreptul sa faceti modificari";
                TempData["messageType"] = "alert-danger";
                return RedirectToAction("Show", "Projects");
            }
            */
        }
    }
}
>>>>>>> Stashed changes
