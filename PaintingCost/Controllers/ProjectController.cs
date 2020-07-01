using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintingCost.DataProvider;
using PaintingCost.Entities;
using PaintingCost.Repository;

namespace PaintingCost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IRepository _repository;

        private IDataProvider _dataProvider;

        public ProjectController(IRepository repository, IDataProvider dataProvider) : base()
        {
            _repository = repository;
            _dataProvider = dataProvider;
        }

        [HttpGet]
        [Route("projecttypes")] 
        public IEnumerable<ProjectType> GetProjectTypes()
        {
            return _repository.GetProjectTypes();
        }

        [HttpGet]
        [Route("sectors")]
        public IEnumerable<Sector> GetSectors(int projectTypeId)
        {
            return _repository.GetSectors(projectTypeId);
        }

        [HttpGet]
        [Route("products")]
        public IEnumerable<Product> GetProducts(int sectorId)
        {
            return _repository.GetProducts(sectorId);
        }

        [HttpGet]
        [Route("paintingcost")]
        public ActionResult<double> GetPaintingCost(int productId, int sectorId, double squareMeter)
        {
            if(_dataProvider.TryGetPaintingCost(productId, sectorId, squareMeter, out double result))
            {
                return result;
            }

            return BadRequest();
        }
    }
}
