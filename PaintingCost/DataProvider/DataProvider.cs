using PaintingCost.Entities;
using PaintingCost.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingCost.DataProvider
{
    public class DataProvider : IDataProvider
    {
        private IRepository _repository;
        public DataProvider(IRepository repository)
        {
            _repository = repository;
        }
        public bool TryGetPaintingCost(int productId, int sectorId, double squareMeter, out double result, int year = 30)
        {
            result = 0;
            Tuple<Product, Sector> scProduct = _repository.GetProductByIdOnSectorByID(productId, sectorId);
            if (scProduct == null)
                return false;

            Product product = scProduct.Item1;
            Sector sector = scProduct.Item2;
            result = product.Price * squareMeter * Math.Floor(year / product.RedecorationCycle) * sector.CostMultiplier;
            return true;
        }
    }
}
