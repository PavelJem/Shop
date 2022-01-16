using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.Dtos;
using Shop.Core.ServiceInterface;
using Shop.Data;

namespace Shop.ApplicationServices.Services
{
    public class FileServices : IFileService
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FileServices
            (
                ShopDbContext context,
                IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }

        public async Task<ExistingFilePath> RemoveImages(ExistingFilePathDto[] dto)
        {
            foreach(var dtos in dto)
            {
                var fileId = await _context.ExistingFilePath
                    .FirstOrDefaultAsync(x => x.FilePath == dtos.FilePath);

                string photoPath = _env.WebRootPath + "\\multipleFileUpload\\" + dtos.FilePath;

                File.Delete(photoPath);

                _context.ExistingFilePath.Remove(fileId);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto)
        {
            var photoId = await _context.ExistingFilePath
                .FirstOrDefaultAsync(x => x.FilePath == dto.FilePath);

            string photoPath = _env.WebRootPath + "\\multipleFileUpload\\" + dto.FilePath;

            File.Delete(photoPath);

            _context.ExistingFilePath.Remove(photoId);
            await _context.SaveChangesAsync();

        return photoId;
        }

        public string ProcessUploadedFile(ProductDto dto, Product product)
        {
            string uniqueFileName = null;

            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_env.WebRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_env.WebRootPath + "\\multipleFileUpload\\");
                }

                foreach (var photo in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "multipleFileUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);

                        ExistingFilePath paths = new ExistingFilePath
                        {
                            Id = Guid.NewGuid(),
                            FilePath = uniqueFileName,
                            ProductId = product.Id
                        };

                        _context.ExistingFilePath.Add(paths);
                    }
                }
            }
            return uniqueFileName;
        }

        public string ProcessUploadedFile(SpaceshipDto dto, Spaceship spaceship)
        {
            string uniqueFileName = null;

            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_env.WebRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_env.WebRootPath + "\\multipleFileUpload\\");
                }

                foreach (var photo in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "multipleFileUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);

                        ExistingFilePath paths = new ExistingFilePath
                        {
                            Id = Guid.NewGuid(),
                            FilePath = uniqueFileName,
                            SpaceshipId = spaceship.Id
                        };

                        _context.ExistingFilePath.Add(paths);
                    }
                }
            }
            return uniqueFileName;
        }
    }
}
