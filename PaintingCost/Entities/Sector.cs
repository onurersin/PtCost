using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingCost.Entities
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double CostMultiplier { get; set; }
        public IList<SectorProduct> SectorProducts { get; set; }
        public IList<ProjectTypeSector> ProjectTypeSectors { get; set; }

    }
}