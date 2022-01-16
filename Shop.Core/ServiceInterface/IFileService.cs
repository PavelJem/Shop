using Shop.Core.Domain;
using Shop.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface IFileService : IApplicationService
    {
        string ProcessUploadedFile(ProductDto dto, Product produtct);
        string ProcessUploadedFile(SpaceshipDto dto, Spaceship spaceship);
        Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);
        Task<ExistingFilePath> RemoveImages(ExistingFilePathDto[] dto);
    }
}
