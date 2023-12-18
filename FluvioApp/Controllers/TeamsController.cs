using Microsoft.AspNetCore.Mvc;

namespace FluvioApp.Controllers
{
    public class TeamsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
