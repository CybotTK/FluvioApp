using Microsoft.AspNetCore.Mvc;

namespace FluvioApp.Controllers
{
    public class AssignmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
