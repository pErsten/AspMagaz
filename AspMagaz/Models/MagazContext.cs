using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz.Models
{
    public class MagazContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LaptopProduct> LaptopProducts { get; set; }
        public DbSet<SmartphoneProduct> SmartphoneProducts { get; set; }
        public DbSet<Photo> Photoes { get; set; }

        public MagazContext(DbContextOptions<MagazContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Photo>().HasIndex(x => new { x.IsPrimary, x.ProductId }).IsUnique().HasDatabaseName("UX_ProductPrimary_Photoes");
            //modelBuilder.Entity<Order>().HasIndex(x => x.UserId).HasDatabaseName("IX_OrderUser").IncludeProperties(x => x.Products);
            /*modelBuilder.Entity<LaptopProduct>().ToTable("Products");
            modelBuilder.Entity<SmartphoneProduct>().ToTable("Products");*/
        }
    }
}
