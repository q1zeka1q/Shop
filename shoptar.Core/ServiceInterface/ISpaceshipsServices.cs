

using shoptar.Core.Domain;
using shoptar.Core.Dto;

namespace shoptar.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Create(SpaceshipDto dto);
    }
}
