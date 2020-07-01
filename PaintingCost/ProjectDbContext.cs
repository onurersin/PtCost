using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaintingCost.SeedDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PaintingCost.Entities
{
    public class ProjectDbContext : DbContext
    {
        ISeedDb _seedDb;
        public DbSet<ProjectType> projectTypes { get; set; }

        public DbSet<Sector> Sectors { get; set; }
         
        public DbSet<Product> products { get; set; }

        public DbSet<ProjectTypeSector> projectTypeSectors { get; set; }

        public DbSet<SectorProduct> sectorProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-U27JD77\User\(localdb)\MSSQLLocalDB;Database=ProductSector;Trusted_Connection=True;");

            optionsBuilder.UseSqlite("Data Source=projectSector.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _seedDb = new SeedDb.SeedDb();

            modelBuilder.Entity<SectorProduct>().HasKey(x => new { x.Product_Id, x.Sector_Id });

            modelBuilder.Entity<ProjectTypeSector>().HasKey(x => new { x.Sector_Id, x.ProjectType_Id });

            modelBuilder.Entity<SectorProduct>()
                        .HasOne(x => x.Product)
                        .WithMany(x => x.SectorProducts)
                        .HasForeignKey(x => x.Product_Id);

            modelBuilder.Entity<SectorProduct>()
                        .HasOne(x => x.Sector)
                        .WithMany(x => x.SectorProducts)
                        .HasForeignKey(x => x.Sector_Id);

            modelBuilder.Entity<ProjectTypeSector>()
                        .HasOne(x => x.ProjectType)
                        .WithMany(x => x.ProjectTypeSectors)
                        .HasForeignKey(x => x.ProjectType_Id);

            modelBuilder.Entity<ProjectTypeSector>()
                        .HasOne(x => x.Sector)
                        .WithMany(x => x.ProjectTypeSectors)
                        .HasForeignKey(x => x.Sector_Id);

            ProjectType[] projectTypes = _seedDb.GetProjectTypes();
            modelBuilder.Entity<ProjectType>().HasData(projectTypes);

            Sector[] sectors = _seedDb.GetSectors();
            modelBuilder.Entity<Sector>().HasData(sectors);

            Product[] products = _seedDb.GetProducts();
            modelBuilder.Entity<Product>().HasData(products);

            ProjectTypeSector[] projectTypSctrs = _seedDb.GetProjectTypeSectors();
            modelBuilder.Entity<ProjectTypeSector>().HasData(projectTypSctrs);

            SectorProduct[] sectorProducts = _seedDb.GetProductSectors();
            modelBuilder.Entity<SectorProduct>().HasData(sectorProducts);


        }
    }
}
