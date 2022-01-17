using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.Domain;

namespace Shop.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Spaceship> Spaceship { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }


    }
}
