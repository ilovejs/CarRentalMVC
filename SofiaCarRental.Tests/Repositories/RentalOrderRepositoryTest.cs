using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.DAL;
using SofiaCarRental.Repositories;
using SofiaCarRental.Tests.Mocks;

namespace SofiaCarRental.Tests.Repositories
{
    [TestClass]
    public class RentalOrderRepositoryTest
    {
        private ContextMock contextMock;
        private RentalOrderRepository rentalOrderRepository;
        private RentalOrder rentalOrder;

        [TestInitialize]
        public void TestInitialize()
        {
            this.contextMock = new ContextMock();
            this.rentalOrderRepository = new RentalOrderRepository(this.contextMock);
            this.rentalOrder = new RentalOrder() { RentalOrderID = 2, RentStartDate = DateTime.Today.AddDays(-5), RentEndDate = DateTime.Today.AddDays(-4) };
            this.contextMock.List.AddRange(new List<RentalOrder>() {
                new RentalOrder() { RentStartDate = DateTime.Today.AddDays(2), RentEndDate = DateTime.Today.AddDays(5)},
                this.rentalOrder,
                new RentalOrder() { RentStartDate = DateTime.Today.AddDays(-2), RentEndDate = DateTime.Today.AddDays(2)}
            });
        }

        [TestMethod]
        public void One()
        {
            RentalOrder order = this.rentalOrderRepository.Find(2);

            Assert.AreSame(order, this.rentalOrder);
        }
        
        [TestMethod]
        public void ByDates()
        {
            DateTime startDate = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(5);

            IList<RentalOrder> filteredOrders = this.rentalOrderRepository.FindByDates(startDate, end).ToList();

            Assert.IsTrue(filteredOrders.Count == 1);
            Assert.AreSame(this.rentalOrder, filteredOrders[0]);
        }

    }
}
