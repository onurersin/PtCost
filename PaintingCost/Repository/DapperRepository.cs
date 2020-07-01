using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintingCost.Entities;
using System.Data.SQLite;

namespace PaintingCost.Repository
{
    public class DapperRepository : IRepository
    {
        private string _conStr;
        public DapperRepository(string conStr)
        {
            _conStr = conStr;
        }
        public Tuple<Product, Sector> GetProductByIdOnSectorByID(int productId, int sectorId)
        {
            string getSectorProduct = "Select * from sectorProducts";
            getSectorProduct = getSectorProduct + " where product_Id=" + productId.ToString();
            getSectorProduct = getSectorProduct + " and sector_Id=" + sectorId.ToString();

            string getProduct = "Select * from products where Id=";
            string getSector = "Select * from sectors where Id=";


            using(var con = new SQLiteConnection(_conStr))
            {
                SectorProduct sectorProduct = con.QueryFirstOrDefault<SectorProduct>(getSectorProduct);
                if (sectorProduct == null)
                    return null;
               
                getProduct = getProduct + sectorProduct.Product_Id.ToString();
                getSector = getSector + sectorProduct.Sector_Id.ToString();
                Product product = con.QueryFirst<Product>(getProduct);
                Sector sector = con.QueryFirst<Sector>(getSector);
                return new Tuple<Product, Sector>(product, sector);
            }
        }

        public IEnumerable<Product> GetProducts(int sectorId)
        {
            string sql = "Select * from products where Id in";
            sql = sql + "(select Product_Id from sectorProducts where Sector_Id =";
            sql = sql + sectorId.ToString() + ")";

            using(var con = new SQLiteConnection(_conStr))
            {
                return con.Query<Product>(sql);
            }
        }

        public IEnumerable<ProjectType> GetProjectTypes()
        {
            string sql = "Select * From projectTypes";
            using (var con = new SQLiteConnection(_conStr))
            {
                return con.Query<ProjectType>(sql);
            }
        }

        public IEnumerable<Sector> GetSectors(int projectTypeId)
        {
            string sql = "Select * from sectors where Id in ";
            sql = sql + "(Select Sector_Id from projectTypeSectors where ProjectType_Id=";
            sql = sql +  projectTypeId.ToString() + ")";

            using (var con = new SQLiteConnection(_conStr))
            {
                return con.Query<Sector>(sql);
            }
        }
    }
}
