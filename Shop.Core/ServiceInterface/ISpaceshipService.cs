using Shop.Core.Domain;
using Shop.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface ISpaceshipService:IApplicationService
    {
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Add(SpaceshipDto dto);
        Task<Spaceship> Edit(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
    }
}
