using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.DAL;

namespace SofiaCarRental.Tests.DTO
{
    [TestClass]
    public class RentalOrderTest
    {
        private const decimal dailyRate = 2;
        private const decimal weeklyRate = 12;
        private const decimal monthlyRate = 44;

        private DateTime date = new DateTime(2011, 5, 1, 13, 21, 32);

        private RentalOrder orderMock;
        private RentalRate rentalRate;

        [TestInitialize]
        public void TestInitialize()
        {
            this.orderMock = new RentalOrder();
            this.rentalRate = new RentalRate() { Daily = dailyRate, Weekly = weeklyRate, Monthly = monthlyRate };
        }

        [TestMethod]
        public void CalculateAppliedRateTest_Daily()
        {
            this.orderMock.RentStartDate = date;
            this.orderMock.RentEndDate = date.AddDays(1);

            this.orderMock.CalculateAppliedRate(this.rentalRate);

            Assert.AreEqual(dailyRate, this.orderMock.RateApplied);
        }

        [TestMethod]
        public void CalculateAppliedRateTest_Weekly()
        {
            this.orderMock.RentStartDate = date;
            this.orderMock.RentEndDate = date.AddDays(15);

            this.orderMock.CalculateAppliedRate(this.rentalRate);

            Assert.AreEqual(weeklyRate, this.orderMock.RateApplied);
        }

        [TestMethod]
        public void CalculateAppliedRateTest_Monthly()
        {
            this.orderMock.RentStartDate = date;
            this.orderMock.RentEndDate = date.AddMonths(1);

            this.orderMock.CalculateAppliedRate(this.rentalRate);

            Assert.AreEqual(monthlyRate, this.orderMock.RateApplied);
        }

    }
}
