using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintingCost.Entities;

namespace PaintingCost.Repository
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts(int sectorId);
        IEnumerable<Sector> GetSectors(int projectTypeId);
        IEnumerable<ProjectType> GetProjectTypes();

        Tuple<Product, Sector> GetProductByIdOnSectorByID(int productId, int sectorId);
    }
}
