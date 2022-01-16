using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.Dtos;
using Shop.Core.ServiceInterface;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Shop.ApplicationServices.Services;

namespace Shop.ApplicationServices.Services
{
    public class SpaceshipServices : ISpaceshipService
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileService _file;

        public SpaceshipServices
            (
                ShopDbContext context,
                IWebHostEnvironment env,
                IFileService file

            )
        {
            _context = context;
            _env = env;
            _file = file;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var photos = await _context.ExistingFilePath.Where(x => x.SpaceshipId == id).Select(y => new ExistingFilePathDto()
            {
                SpaceshipId = y.SpaceshipId,
                FilePath = y.FilePath,
                PhotoId = y.Id
            })
            .ToArrayAsync();
            var spaceshipId = await _context.Spaceship.Include(x => x.ExistingFilePaths).FirstOrDefaultAsync(x => x.Id == id);

            await _file.RemoveImages(photos);
            _context.Spaceship.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }

        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            spaceship.Id = dto.Id;
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.Mass = dto.Mass;
            spaceship.Price = dto.Price;
            spaceship.Crew = dto.Crew;
            spaceship.ConstructedAt = dto.ConstructedAt;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            _file.ProcessUploadedFile(dto, spaceship);

            await _context.Spaceship.AddAsync(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;

        }

        public async Task<Spaceship> Edit(Guid id)
        {
            var result = await _context.Spaceship
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            spaceship.Id = dto.Id;
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.Mass = dto.Mass;
            spaceship.Price = dto.Price;
            spaceship.Crew = dto.Crew;
            spaceship.ConstructedAt = dto.ConstructedAt;
            spaceship.CreatedAt = dto.CreatedAt;
            spaceship.ModifiedAt = dto.ModifiedAt;
            _file.ProcessUploadedFile(dto, spaceship);

            _context.Spaceship.Update(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;
        }
    }
}


