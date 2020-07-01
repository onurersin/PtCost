using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingCost.DataProvider
{
    public interface IDataProvider
    {
        bool TryGetPaintingCost(int productId, int sectorId, double squareMeter, out double result, int year = 30);
    }
}
