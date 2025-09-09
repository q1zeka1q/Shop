

using shoptar.Core.Domain;
using shoptar.Core.Dto;

namespace shoptar.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Create(SpaceshipDto dto);
        Task<Spaceship> DetailAsync(Guid id);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
    }
}
