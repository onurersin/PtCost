using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingCost.Entities
{
    public class ProjectType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<ProjectTypeSector> ProjectTypeSectors { get; set; }

    }
}
