using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingCost.Entities
{
    public class ProjectTypeSector
    {
        public int ProjectType_Id { get; set; }

        public int Sector_Id { get; set; }

        public ProjectType ProjectType { get; set; }

        public Sector Sector { get; set; }
    }
}
