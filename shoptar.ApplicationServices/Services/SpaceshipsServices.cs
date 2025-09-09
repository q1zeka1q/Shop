using System;
using System.Collections.Generic;
using System.Linq;
using shoptar.Core.Domain;
using shoptar.Data;
using shoptar.Core.Dto;
using shoptar.Core.ServiceInterface;


namespace shoptar.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly ShoptarContext _context;

        public SpaceshipsServices
            (
            ShoptarContext context
            )
        {
            _context = context;
        }
        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
           Spaceship spaceship = new Spaceship();
            
            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.TypeName = dto.TypeName;
            spaceship.BuiltDate = dto.BuiltDate;
            spaceship.Crew = dto.Crew;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Passengers = dto.Passengers;
            spaceship.InnerVolume = dto.InnerVolume;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            await _context.Spaceships.AddAsync( spaceship );
            await _context.SaveChangesAsync();

            return spaceship;
        }
    }
}
