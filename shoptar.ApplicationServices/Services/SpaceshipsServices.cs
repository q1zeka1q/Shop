using System;
using System.Collections.Generic;
using System.Linq;
using shoptar.Core.Domain;
using shoptar.Data;
using shoptar.Core.Dto;
using shoptar.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;


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

        public async Task<Spaceship> DetailAsync (Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
           
            return result;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceship = await _context.Spaceships
                .FirstOrDefaultAsync(x =>x.Id == id);

            _context.Spaceships.Remove( spaceship );
            await _context.SaveChangesAsync ();

            return spaceship;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship domain = new();

            domain.Id = dto.Id;
            domain.Name = dto.Name;
            domain.TypeName = dto.TypeName;
            domain.BuiltDate = dto.BuiltDate;
            domain.Crew = dto.Crew;
            domain.EnginePower = dto.EnginePower;
            domain.Passengers = dto.Passengers;
            domain.InnerVolume = dto.InnerVolume;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = DateTime.Now;

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync ();

            return domain;

        }
    }
}
