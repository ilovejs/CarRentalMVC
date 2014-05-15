using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.Helpers;
using SofiaCarRental.Models;

namespace SofiaCarRental.Tests.ModelViewTests
{
    [TestClass]
    public class DatePickerModelViewTest
    {
        private DatePickerModelView datePickerModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this.datePickerModel = new DatePickerModelView();
        }

        [TestMethod]
        public void RentalPickUpDatePropertyTest_RentalPickUpDateTimeIsNull()
        {
            IList<string> eventsCalled = new List<string>();

            DateTime date = new DateTime(2011, 01, 01);
            DateTime expectedDateTime = new DateTime(date.Year, date.Month, date.Day,
                SystemTime.Now().Hour, SystemTime.Now().Minute, SystemTime.Now().Second);

            this.datePickerModel.RentalPickUpDate = date;

            Assert.AreEqual(expectedDateTime, this.datePickerModel.RentalPickUpDate);
        }

        [TestMethod]
        public void RentalPickUpDatePropertyTest_RentalPickUpDateTimeNotNull()
        {
            this.datePickerModel.RentalPickUpDate = new DateTime(2015, 06, 07, 03, 04, 05);
            DateTime? initialDate = this.datePickerModel.RentalPickUpDate;

            DateTime date = new DateTime(2011, 01, 01);
            DateTime expectedDateTime = new DateTime(date.Year, date.Month, date.Day,
                initialDate.Value.Hour, initialDate.Value.Minute, initialDate.Value.Second);

            this.datePickerModel.RentalPickUpDate = date;

            Assert.AreEqual(expectedDateTime, this.datePickerModel.RentalPickUpDate);
        }

        [TestMethod]
        public void RentalPickUpDatePropertyTest_ValueIsNull()
        {
            this.datePickerModel.RentalPickUpDate = new DateTime(2015, 06, 07, 03, 04, 05);
            DateTime? initialDate = this.datePickerModel.RentalPickUpDate;

            this.datePickerModel.RentalPickUpDate = null;

            Assert.AreEqual(initialDate, this.datePickerModel.RentalPickUpDate);
        }

        [TestMethod]
        public void RentalReturnDatePropertyTest_RentalReturnDateTimeIsNull()
        {
            IList<string> eventsCalled = new List<string>();

            DateTime date = new DateTime(2011, 01, 01);
            DateTime expectedDateTime = new DateTime(date.Year, date.Month, date.Day,
                SystemTime.Now().Hour, SystemTime.Now().Minute, SystemTime.Now().Second);

            this.datePickerModel.RentalReturnDate = date;

            Assert.AreEqual(expectedDateTime, this.datePickerModel.RentalReturnDate);
        }

        [TestMethod]
        public void RentalReturnDatePropertyTest_RentalReturnDateNotNull()
        {
            this.datePickerModel.RentalReturnDate = new DateTime(2015, 06, 07, 03, 04, 05);
            DateTime? initialDate = this.datePickerModel.RentalReturnDate;

            DateTime date = new DateTime(2011, 01, 01);
            DateTime expectedDateTime = new DateTime(date.Year, date.Month, date.Day,
                initialDate.Value.Hour, initialDate.Value.Minute, initialDate.Value.Second);

            this.datePickerModel.RentalReturnDate = date;

            Assert.AreEqual(expectedDateTime, this.datePickerModel.RentalReturnDate);
        }

        [TestMethod]
        public void RentalReturnDatePropertyTest_ValueIsNull()
        {
            this.datePickerModel.RentalReturnDate = new DateTime(2015, 06, 07, 03, 04, 05);
            DateTime? initialDate = this.datePickerModel.RentalReturnDate;

            this.datePickerModel.RentalReturnDate = null;

            Assert.AreEqual(initialDate, this.datePickerModel.RentalReturnDate);
        }


        [TestMethod]
        public void RentalPickUpTimePropertyTest_RentalPickUpTimeIsNull()
        {
            DateTime date = new DateTime(2011, 01, 01, 12, 59, 59);
            DateTime expectedDateTime = new DateTime(SystemTime.Now().Year, SystemTime.Now().Month, SystemTime.Now().Day,
                date.Hour, date.Minute, date.Second);

            this.datePickerModel.RentalPickUpTime = date;

            Assert.AreEqual(expectedDateTime, this.datePickerModel.RentalPickUpTime);
        }

        [TestMethod]
        public void RentalPickUpTimePropertyTest_RentalPickUpTimeNotNull()
        {
            this.datePickerModel.RentalPickUpTime = new DateTime(2015, 06, 07, 03, 04, 05);
            DateTime? initialDate = this.datePickerModel.RentalPickUpTime;

            IList<string> eventsCalled = new List<string>();

            DateTime date = new DateTime(2011, 01, 01, 12, 59, 59);
            DateTime expectedDateTime = new DateTime(SystemTime.Now().Year, SystemTime.Now().Month, SystemTime.Now().Day,
                date.Hour, date.Minute, date.Second);

            this.datePickerModel.RentalPickUpTime = date;

            Assert.AreEqual(expectedDateTime, this.datePickerModel.RentalPickUpTime);
        }

        [TestMethod]
        public void RentalPickUpTimePropertyTest_ValueIsNull()
        {
            this.datePickerModel.RentalPickUpTime = new DateTime(2015, 06, 07, 03, 04, 05);
            DateTime? initialDate = this.datePickerModel.RentalPickUpTime;

            this.datePickerModel.RentalPickUpTime = null;

            Assert.AreEqual(initialDate, this.datePickerModel.RentalPickUpTime);
        }

        [TestMethod]
        public void RentalReturnTimePropertyTest_RentalReturnTimeIsNull()
        {
            IList<string> eventsCalled = new List<string>();

            DateTime date = new DateTime(2011, 01, 01, 12, 59, 59);
            DateTime expectedDateTime = new DateTime(SystemTime.Now().Year, SystemTime.Now().Month, SystemTime.Now().Day,
                date.Hour, date.Minute, date.Second);

            this.datePickerModel.RentalReturnTime = date;

            Assert.AreEqual(expectedDateTime, this.datePickerModel.RentalReturnTime);
        }

        [TestMethod]
        public void RentalReturnTimePropertyTest_RentalReturnTimeNotNull()
        {
            this.datePickerModel.RentalReturnTime = new DateTime(2015, 06, 07, 03, 04, 05);
            DateTime? initialDate = this.datePickerModel.RentalReturnTime;

            DateTime date = new DateTime(2011, 01, 01, 12, 59, 59);
            DateTime expectedDateTime = new DateTime(SystemTime.Now().Year, SystemTime.Now().Month, SystemTime.Now().Day,
                date.Hour, date.Minute, date.Second);

            this.datePickerModel.RentalReturnTime = date;

            Assert.AreEqual(expectedDateTime, this.datePickerModel.RentalReturnTime);
        }

        [TestMethod]
        public void RentalReturnTimePropertyTest_ValueIsNull()
        {
            this.datePickerModel.RentalReturnTime = new DateTime(2015, 06, 07, 03, 04, 05);
            DateTime? initialDate = this.datePickerModel.RentalReturnTime;

            this.datePickerModel.RentalReturnTime = null;

            Assert.AreEqual(initialDate, this.datePickerModel.RentalReturnTime);
        }

    }
}
