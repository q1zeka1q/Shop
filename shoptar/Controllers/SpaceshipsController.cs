using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using shoptar.Core.Dto;
using shoptar.Core.ServiceInterface;
using shoptar.Data;
using shoptar.Models.Spaceships;

namespace shoptar.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShoptarContext _context;
        private readonly ISpaceshipsServices _SpaceshipsServices;
        public SpaceshipsController
            (
               ShoptarContext context,
               ISpaceshipsServices ISpaceshipsServices

            )
        {
            _context = context;
            _SpaceshipsServices = ISpaceshipsServices;
        }

        public  IActionResult Index()
        {

            var result = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    BuiltDate = x.BuiltDate,
                    TypeName = x.TypeName,
                    Crew = x.Crew
                });


            return View(result);
        }
        [HttpGet]

        public  IActionResult Create()
        {
            SpaceshipCreateViewModel result = new();

            return View("Create", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                TypeName = vm.TypeName,
                BuiltDate = vm.BuiltDate,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                Passengers = vm.Passengers,
                InnerVolume = vm.InnerVolume,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };

            var result = await _SpaceshipsServices.Create(dto);

            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
