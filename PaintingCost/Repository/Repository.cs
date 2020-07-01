using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using PaintingCost.Entities;

namespace PaintingCost.Repository
{
    public class Repository : IRepository
    {
        public Tuple<Product, Sector> GetProductByIdOnSectorByID(int productId, int sectorId)
        {
            using(var ctx = new ProjectDbContext())
            {
                SectorProduct sectorProduct = ctx.sectorProducts.Include(x => x.Product)
                                .Include(x => x.Sector)
                                .Where(x => x.Product_Id == productId && x.Sector_Id == sectorId)
                                .FirstOrDefault();
                if (sectorProduct == null)
                    return null;

                return new Tuple<Product, Sector>(sectorProduct.Product, sectorProduct.Sector);
            }
        }

        public IEnumerable<Product> GetProducts(int sectorId)
        {
           
            using(var ctx = new ProjectDbContext())
            {
                return ctx.sectorProducts.Where(x => x.Sector_Id == sectorId)
                                         .Select(x => x.Product)
                                         .ToList();
            }
        }

        public IEnumerable<ProjectType> GetProjectTypes()
        {
            using (var ctx = new ProjectDbContext())
            {
                return ctx.projectTypes.ToList();
            }
        }

        public IEnumerable<Sector> GetSectors(int projectTypeId)
        {
            using(var ctx = new ProjectDbContext())
            {
                return ctx.projectTypeSectors.Where(x => x.ProjectType_Id == projectTypeId)
                                             .Select(x => x.Sector)
                                             .ToList();
            }
        }
    }
}
