using Microsoft.AspNetCore.Mvc;

namespace FluvioApp.Controllers
{
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
