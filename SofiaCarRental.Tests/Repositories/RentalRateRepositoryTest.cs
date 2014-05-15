using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.DAL;
using SofiaCarRental.Repositories;
using SofiaCarRental.Tests.Mocks;

namespace SofiaCarRental.Tests.Repositories
{
    [TestClass]
    public class RentalRateRepositoryTest
    {
        private ContextMock contextMock;
        private RentalRateRepository rentalRateRepository;
        private RentalRate rentalRate;

        [TestInitialize]
        public void TestInitialize()
        {
            this.contextMock = new ContextMock();
            this.rentalRateRepository = new RentalRateRepository(this.contextMock);
            this.rentalRate = new RentalRate() { RentalRateID = 1 };
            this.contextMock.List.AddRange(new List<RentalRate>() { this.rentalRate });
        }

        [TestMethod]
        public void OneTest()
        {
            RentalRate rentalRate = this.rentalRateRepository.Find(1);

            Assert.AreSame(rentalRate, this.rentalRate);
        }

    }
}
