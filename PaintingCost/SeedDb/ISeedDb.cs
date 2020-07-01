using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintingCost.Entities;

namespace PaintingCost.SeedDb
{
    public interface ISeedDb
    {
        ProjectType[] GetProjectTypes();

        Sector[] GetSectors();

        Product[] GetProducts();

        ProjectTypeSector[] GetProjectTypeSectors();

        SectorProduct[] GetProductSectors();
    }
}
