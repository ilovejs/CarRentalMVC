using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.DAL;
using SofiaCarRental.Repositories;
using SofiaCarRental.Tests.Mocks;

namespace SofiaCarRental.Tests
{

    [TestClass()]
    public class CarRepositoryTest
    {
        private ContextMock contextMock;
        private CarRepository carRepository;
        private Car car;

        [TestInitialize]
        public void TestInitialize()
        {
            this.contextMock = new ContextMock();
            this.carRepository = new CarRepository(this.contextMock);
            this.car = new Car() { CarID = 1 };
            this.contextMock.List.AddRange(new List<Car>() { this.car });
        }

        [TestMethod]
        public void OneTest()
        {
            Car car = this.carRepository.Find(1);

            Assert.AreSame(car, this.car);
        }
    }
}
