using Microsoft.AspNetCore.Mvc;

namespace FluvioApp.Controllers
{
    public class MediaFilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
