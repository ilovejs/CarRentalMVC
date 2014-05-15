using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.Helpers;

namespace SofiaCarRental.Tests
{
    
    [TestClass()]
    public class CarSearchUtilsTest
    {

        [TestMethod()]
        public void GenerateFilterForAvailableCarsTest_DatesNotNull()
        {
            DateTime? pickUpDateTime = new DateTime(2011, 5, 2, 13, 21, 32);
            DateTime? returnDateTime = pickUpDateTime.Value.AddDays(1);

            DateTime? pickUpDateTimeInput = pickUpDateTime;
            DateTime? returnDateTimeInput = returnDateTime;

            CarsSearchUtils.ModifyDatesIfNecessary(ref pickUpDateTimeInput, ref returnDateTimeInput);

            Assert.AreEqual(pickUpDateTime, pickUpDateTimeInput);
            Assert.AreEqual(returnDateTime, returnDateTimeInput);
        }

        [TestMethod()]
        public void GenerateFilterForAvailableCarsTest_DatesNull()
        {
            DateTime? pickUpDateTimeInput = null;
            DateTime? returnDateTimeInput = null;

            CarsSearchUtils.ModifyDatesIfNecessary(ref pickUpDateTimeInput, ref returnDateTimeInput);

            Assert.AreEqual(DateTime.Today, pickUpDateTimeInput);
            Assert.AreEqual(DateTime.Today.AddDays(1), returnDateTimeInput);
        }

        [TestMethod()]
        public void GenerateFilterForAvailableCarsTest_PickUpDateIsNull()
        {
            DateTime? pickUpDateTimeInput = null;
            DateTime? returnDateTimeInput = DateTime.Today;

            CarsSearchUtils.ModifyDatesIfNecessary(ref pickUpDateTimeInput, ref returnDateTimeInput);

            Assert.AreEqual(returnDateTimeInput.Value.AddDays(-1), pickUpDateTimeInput);
        }

        [TestMethod()]
        public void GenerateFilterForAvailableCarsTest_ReturnDateIsNull()
        {
            DateTime? pickUpDateTimeInput = DateTime.Today;
            DateTime? returnDateTimeInput = null;

            CarsSearchUtils.ModifyDatesIfNecessary(ref pickUpDateTimeInput, ref returnDateTimeInput);

            Assert.AreEqual(pickUpDateTimeInput.Value.AddDays(1), returnDateTimeInput);
        }

    }

}
