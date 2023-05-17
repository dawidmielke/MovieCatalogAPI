using Microsoft.AspNetCore.Mvc;

namespace MovieCatalogAPI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
