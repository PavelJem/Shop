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
    public class ProductServices : IProductService
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileService _file;

        public ProductServices
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

        public async Task<Product> Delete(Guid id)
        {
            var photos = await _context.ExistingFilePath.Where(x => x.ProductId == id).Select(y => new ExistingFilePathDto()
            {
                ProductId = y.ProductId,
                FilePath = y.FilePath,
                PhotoId = y.Id
            })
            .ToArrayAsync();
            var productId = await _context.Product.Include(x => x.ExistingFilePaths).FirstOrDefaultAsync(x => x.Id == id);

            await _file.RemoveImages(photos);
            _context.Product.Remove(productId);
            await _context.SaveChangesAsync();

            return productId;
        }

        public async Task<Product> Add(ProductDto dto)
        {
            Product product = new Product();

            product.Id = Guid.NewGuid();
            product.Description = dto.Description;
            product.Name = dto.Name;
            product.Amount = dto.Amount;
            product.Price = dto.Price;
            product.ModifiedAt = DateTime.Now;
            product.CreatedAt = DateTime.Now;
            //ProcessUploadedFile(dto, product);
            _file.ProcessUploadedFile(dto, product);


            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Edit(Guid id)
        {
            var result = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Product> Update(ProductDto dto)
        {
            Product product = new Product();
            product.Id = dto.Id;
            product.Description = dto.Description;
            product.Name = dto.Name;
            product.Amount = dto.Amount;
            product.Price = dto.Price;
            product.ModifiedAt = dto.ModifiedAt;
            product.CreatedAt = dto.CreatedAt;
            _file.ProcessUploadedFile(dto, product);


            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

       /* public async Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto)
        {
            var imageId = await _context.ExistingFilePath.FirstOrDefaultAsync(x => x.Id == dto.PhotoId);
            _context.ExistingFilePath.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }

        public string ProcessUploadedFile(ProductDto dto, Product product)
        {
            string uniqueFileName = null;

            if(dto.Files != null && dto.Files.Count > 0)
            {
                if(!Directory.Exists(_env.EnvironmentName + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_env.ContentRootPath + "\\multipleFileUpload\\");
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
       */

    }
}


