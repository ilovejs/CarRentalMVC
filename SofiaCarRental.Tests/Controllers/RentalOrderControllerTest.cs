using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.Controllers;
using SofiaCarRental.DAL;
using SofiaCarRental.Helpers;
using SofiaCarRental.Services;
using SofiaCarRental.Tests.Mocks;

namespace SofiaCarRental.Tests.Controllers
{

    [TestClass]
    public class RentalOrderControllerTest
    {
        private RentalOrderRepositoryMock rentalOrderRepositoryMock;
        private CarRepositoryMock carRepositoryMock;
        private RentalRateRepositoryMock rateRepositoryMock;
        private ContextMock contextMock;
        private CarService carService;
        private OrderService orderService;

        private CarController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            this.carRepositoryMock = new CarRepositoryMock();
            this.rateRepositoryMock = new RentalRateRepositoryMock();
            this.rentalOrderRepositoryMock = new RentalOrderRepositoryMock();
            this.contextMock = new ContextMock();

            this.orderService = new OrderService(this.carRepositoryMock, this.rentalOrderRepositoryMock, this.rateRepositoryMock, this.contextMock);
            this.carService = new CarService(this.carRepositoryMock, this.rentalOrderRepositoryMock);
            
            this.controller = new CarController(this.carService, this.orderService);
            this.controller.ControllerContext = new ControllerContext();
        }

        [TestMethod]
        public void Create_Post()
        {
            int customerID = 2;
            int employeeID = 3;
            this.AddRentalOrderToRepository(customerID, employeeID);
            this.AddRentalRateToRepository();

            DateTime date = new DateTime(2011, 1, 2, 12, 12, 12);
            SystemTime.Now = () => date;
            DateTime startDate = DateTime.Now;
            RentalOrder order = new RentalOrder { CarID = 1, RentStartDate = startDate, RentEndDate = startDate.AddDays(13) };
            this.carRepositoryMock.Cars.Add(new Car() { CarID = 1, CategoryID = 1 });

            ActionResult result = this.controller.CreateOrder(order.RentStartDate, order.RentEndDate, order.CarID);

            result.AssertHasViewName("Details");
            RentalOrder createdOrder = this.rentalOrderRepositoryMock.AddedOrders.First();
            Assert.IsNotNull(createdOrder);
            Assert.AreEqual(date, createdOrder.DateProcessed);
            Assert.AreEqual(customerID, createdOrder.CustomerID);
            Assert.AreEqual(employeeID, createdOrder.EmployeeID);
            Assert.AreEqual(3, createdOrder.RateApplied);
            Assert.IsTrue(this.contextMock.SaveChangesCalled);

            SystemTime.Now = null;
        }

        [TestMethod]
        public void Create_Post_Exception()
        {
            SystemTime.Now = () => { throw new NotImplementedException(); };
            RentalOrder order = new RentalOrder();
            ActionResult result = this.controller.CreateOrder(order.RentStartDate, order.RentEndDate, order.CarID); 

            result.AssertIsViewResult();

            SystemTime.Now = null;
        }

        [TestMethod]
        public void Edit_Post()
        {
            this.AddRentalOrderToRepository();
            this.AddRentalRateToRepository();

            DateTime start = new DateTime(2015, 12, 2);
            Car car = new Car() { CategoryID = 1 };
            RentalOrder order = new RentalOrder() 
            {
                RentalOrderID = 1,
                RentStartDate = start,
                RentEndDate = start.AddDays(13),
                Car = car
            };

            ActionResult result = this.controller.EditOrder(order, 0);

            result.AssertRedirectTo("Details", "Car");
            RentalOrder updatedOrder = this.rentalOrderRepositoryMock.Orders
                .First(x => x.RentalOrderID == 1);
            Assert.AreEqual(start, updatedOrder.RentStartDate);
            Assert.AreEqual(start.AddDays(13), updatedOrder.RentEndDate);
            Assert.AreEqual(3, updatedOrder.RateApplied);
            Assert.IsTrue(this.contextMock.SaveChangesCalled);
        }

       

        [TestMethod]
        public void Edit_Post_NotFound()
        {
            ActionResult result = this.controller.EditOrder(new RentalOrder() { RentalOrderID = 15 }, 0);

            result.AssertIsViewResult();
        }

        private void AddRentalOrderToRepository(int customerID = 2, int employeeID = 3)
        {
            Car car = new Car { CarID = 1, CategoryID = 1 };

            RentalOrder order = new RentalOrder()
            {
                RentalOrderID = 1,
                RentStartDate = new DateTime(2012, 12, 2),
                RentEndDate = new DateTime(2013, 12, 2),
                Car = car,
                CustomerID = customerID,
                EmployeeID = employeeID
            };

            this.rentalOrderRepositoryMock.Orders.Add(order);
        }

        private void AddRentalRateToRepository()
        {
            RentalRate rate = new RentalRate() { RentalRateID = 1, CategoryID = 1, Weekly = 3 };
            this.rateRepositoryMock.RentalRates.Add(rate);
        }

    }
}
