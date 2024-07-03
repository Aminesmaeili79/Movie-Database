using Microsoft.AspNetCore.Mvc;

namespace MovieDatabase.Controllers
{
    public class MovieDatabaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
