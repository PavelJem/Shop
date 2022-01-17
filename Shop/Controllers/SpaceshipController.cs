using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.Spaceship;
using Shop.Core.ServiceInterface;
using Shop.Core.Dtos;
using Shop.Models.Files;
using Microsoft.EntityFrameworkCore;

namespace Shop.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly ISpaceshipService _spaceshipService;
        private readonly IFileService _fileService;

        public SpaceshipController
            (
                ShopDbContext context,
                ISpaceshipService spaceshipService,
                IFileService fileService
            )
        {
            _context = context;
            _spaceshipService = spaceshipService;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            var result = _context.Spaceship
                .Select(x => new SpaceshipListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Type = x.Type,
                    Mass = x.Mass,
                    CreatedAt = x.CreatedAt,
                    Crew = x.Crew,
                    ConstructedAt = x.ConstructedAt
                });

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipService.Delete(id);

            if (spaceship == null)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            SpaceshipViewModel model = new SpaceshipViewModel();

            return View("Edit", model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipViewModel model)
        {
            var dto = new SpaceshipDto()
            {
                Id = model.Id,
                Type = model.Type,
                Name = model.Name,
                Mass = model.Mass,
                Price = model.Price,
                Crew = model.Crew,
                ConstructedAt = model.ConstructedAt,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                Image = model.Image.Select(x => new FileToDatabaseDto 
                { 
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.Spaceship
                }).ToArray()
            };

            var result = await _spaceshipService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _spaceshipService.Edit(id);
            if (spaceship == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabase.Where(x => x.SpaceshipId == id).Select(m => new ImagesViewModel
            {
                ImageData = m.ImageData,
                Id = m.Id,
                Image = string.Format("data:iamge/gif;base64,{0}", Convert.ToBase64String(m.ImageData)),
                ImageTitle = m.ImageTitle,
                SpaceshipId = m.Id,

            }).ToArrayAsync();

            var model = new SpaceshipViewModel();

            model.Id = spaceship.Id;
            model.Type = spaceship.Type;
            model.Name = spaceship.Name;
            model.Mass = spaceship.Mass;
            model.Price = spaceship.Price;
            model.Crew = spaceship.Crew;
            model.ConstructedAt = spaceship.ConstructedAt;
            model.ModifiedAt = spaceship.ModifiedAt;
            model.CreatedAt = spaceship.CreatedAt;
            model.Image.AddRange(photos);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipViewModel model)
        {
            var dto = new SpaceshipDto()
            {
                Id = model.Id,
                Type = model.Type,
                Name = model.Name,
                Mass = model.Mass,
                Price = model.Price,
                Crew = model.Crew,
                ConstructedAt = model.ConstructedAt,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Image = model.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.SpaceshipId
                })
            };

            var result = await _spaceshipService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }


        [HttpPost]
        public async Task<IActionResult> RemoveImage(ExistingFilePathViewModel model)
        {
            var dto = new ExistingFilePathDto()
            {
                FilePath = model.FilePath
            };

            var image = await _fileService.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
