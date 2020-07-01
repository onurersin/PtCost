using NUnit.Framework;
using PaintingCost.DataProvider;
using PaintingCost.Repository;
using Moq;
using PaintingCost.Entities;
using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TestProject
{
    public class DataProviderTests
    {
        IDataProvider _dataProvider;
        Mock<IRepository> _moqRepo;

        public DataProviderTests()
        {
            _moqRepo = new Mock<IRepository>();
            _dataProvider = new DataProvider(_moqRepo.Object);
        }

        [SetUp]
        public void Setup()
        {
            _moqRepo.Setup(x => x.GetProductByIdOnSectorByID(-1, -1)).Returns((Tuple<Product, Sector>)null);
            _moqRepo.Setup(x => x.GetProductByIdOnSectorByID(1, 1))
                                 .Returns(new Tuple<Product, Sector>(new Product 
                                 {
                                     Id = 1,
                                     Price = 0.4,
                                     RedecorationCycle = 5,
                                 }, 
                                 new Sector
                                 { 
                                     CostMultiplier = 1.1                              
                                 }));

        }

        [Test]
        [TestCase(-1, -1, 100, false, 0)]
        [TestCase(1, 1, 100, true, 264)]
        [TestCase(1, 1, 1000, true, 2640)]

        public void Test_TryGetPaintingCost(int productId, int sectorId, double squareMeter, 
                                            bool testReturn, double calculationResult)
        {
            bool funcReturn = _dataProvider.TryGetPaintingCost(productId, sectorId, squareMeter, out double result);
            Assert.AreEqual(testReturn, funcReturn);
            Assert.AreEqual(calculationResult, result);
        }
    }
}