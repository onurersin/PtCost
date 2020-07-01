using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintingCost.Entities;
using PaintingCost.SeedDb;

namespace PaintingCost.SeedDb
{
    public class SeedDb : ISeedDb
    {
        public ProjectType[] GetProjectTypes()
        {
            return new ProjectType[] {

                new ProjectType
                {
                    Id = 1,
                    Name = "Interior"
                },

                new ProjectType
                {
                    Id = 2,
                    Name = "Exterior"
                }
            };
        }

        public Sector[] GetSectors()
        {
            return new Sector[] {

                new Sector
                {
                    Id = 1,
                    Name = "Hospital",
                    CostMultiplier = 1.1,
                },

                new Sector
                {
                    Id = 2,
                    Name = "School",
                    CostMultiplier = 1,
                },

                new Sector
                {
                    Id = 3,
                    Name = "Housing",
                    CostMultiplier = 0.9,
                },

                new Sector
                {
                    Id = 4,
                    Name = "Hall",
                    CostMultiplier = 1,
                },

                new Sector
                {
                    Id = 5,
                    Name = "Park",
                    CostMultiplier = 0.8,
                }

            };
        }

        public Product[] GetProducts()
        {
            return new Product[] {
                new Product
                {
                    Id = 1,
                    Name = "Benjamin Moore",
                    Price = 0.4,
                    RedecorationCycle = 5
                },

                new Product
                {
                    Id = 2,
                    Name = "Marshall",
                    Price = 0.1,
                    RedecorationCycle = 1
                },

                new Product
                {
                    Id = 3,
                    Name = "Glidden Pro",
                    Price = 0.8,
                    RedecorationCycle = 9
                },

                new Product
                {
                    Id = 4,
                    Name = "Behr",
                    Price = 0.6,
                    RedecorationCycle = 3
                },

                new Product
                 {
                     Id = 5,
                     Name = "Valspar",
                     Price = 0.8,
                     RedecorationCycle = 8
                 }

            };
        }

        public ProjectTypeSector[] GetProjectTypeSectors()
        {
            return new ProjectTypeSector[] { 
                new ProjectTypeSector
                {
                    Sector_Id = 1,
                    ProjectType_Id = 1
                },

                new ProjectTypeSector
                {
                    Sector_Id = 1,
                    ProjectType_Id = 2
                },

                new ProjectTypeSector
                {
                    Sector_Id = 2,
                    ProjectType_Id = 1
                },

                new ProjectTypeSector
                {
                    Sector_Id = 2,
                    ProjectType_Id = 2
                },

                new ProjectTypeSector
                {
                    Sector_Id = 3,
                    ProjectType_Id = 1
                },

                new ProjectTypeSector
                {
                    Sector_Id = 3,
                    ProjectType_Id = 2
                },

                new ProjectTypeSector
                {
                    Sector_Id = 4,
                    ProjectType_Id = 1
                },

                new ProjectTypeSector
                {
                    Sector_Id = 5,
                    ProjectType_Id = 2
                },


            };
        }

        public SectorProduct[] GetProductSectors()
        {
            return new SectorProduct[] { 
                new SectorProduct
                {
                    Product_Id = 1,
                    Sector_Id = 1
                },

                new SectorProduct
                {
                    Product_Id = 1,
                    Sector_Id = 2
                },

                new SectorProduct
                {
                    Product_Id = 1,
                    Sector_Id = 4
                },

                new SectorProduct
                {
                    Product_Id = 2,
                    Sector_Id = 2
                },

                new SectorProduct
                {
                    Product_Id = 2,
                    Sector_Id = 3
                },

                new SectorProduct
                {
                    Product_Id = 2,
                    Sector_Id = 5
                },

                new SectorProduct
                {
                    Product_Id = 3,
                    Sector_Id = 1
                },

                new SectorProduct
                {
                    Product_Id = 4,
                    Sector_Id = 3
                },

                new SectorProduct
                {
                    Product_Id = 4,
                    Sector_Id = 4
                },

                new SectorProduct
                {
                    Product_Id = 4,
                    Sector_Id = 5
                },

                new SectorProduct
                {
                    Product_Id = 5,
                    Sector_Id = 1
                },
                
                new SectorProduct
                {
                    Product_Id = 5,
                    Sector_Id = 2
                },

                new SectorProduct
                {
                    Product_Id = 5,
                    Sector_Id = 3
                },

                new SectorProduct
                {
                    Product_Id = 5,
                    Sector_Id = 4
                },

                new SectorProduct
                {
                    Product_Id = 5,
                    Sector_Id = 5
                },





            };
        }
    }
}
