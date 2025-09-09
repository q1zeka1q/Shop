using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using shoptar.ApplicationServices.Services;
using shoptar.Core.Domain;
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
            SpaceshipCreateUpdateViewModel result = new();

            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateUpdateViewModel vm)
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

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _SpaceshipsServices.DetailAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new SpaceshipDeleteViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.TypeName = spaceship.TypeName;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.Passengers = spaceship.Passengers;
            vm.InnerVolume = spaceship.InnerVolume;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View(vm);
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var spaceship = await _SpaceshipsServices.Delete(id);

            if (spaceship == null)
            {
              return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship= await _SpaceshipsServices.DetailAsync(id);

            if (spaceship==null)
            {
                return NotFound();
            }

            var vm = new SpaceshipCreateUpdateViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.TypeName = spaceship.TypeName;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.Passengers = spaceship.Passengers;
            vm.InnerVolume = spaceship.InnerVolume;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipCreateUpdateViewModel vm)
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
            var result = await _SpaceshipsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
