using Microsoft.AspNetCore.Mvc;

namespace shoptar.Controllers
{
    public class SpaceshipsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
