using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingCost.Entities
{
    public class SectorProduct
    {
        public int Sector_Id { get; set; }

        public int Product_Id { get; set; }

        public Product Product { get; set; }

        public Sector Sector { get; set; }

    }
}
