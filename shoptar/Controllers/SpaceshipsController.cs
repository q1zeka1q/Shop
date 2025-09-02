using Microsoft.AspNetCore.Mvc;
using shoptar.Data;
using shoptar.Models.Spaceships;

namespace shoptar.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShoptarContext _context;

        public SpaceshipsController
            (
               ShoptarContext context
            )
        {
            _context = context;
                }

        public IActionResult Index()
        {

            var result = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    BuiltDate=x.BuiltDate,
                    TypeName=x.TypeName,
                    Crew=x.Crew
                });


            return View(result);
        }
    }
}
