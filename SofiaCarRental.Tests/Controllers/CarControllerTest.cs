using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.Controllers;
using SofiaCarRental.DAL;
using SofiaCarRental.Helpers;
using SofiaCarRental.Models;
using SofiaCarRental.Services;
using SofiaCarRental.Tests.Mocks;

namespace SofiaCarRental.Tests.Controllers
{

    [TestClass]
    public class CarControllerTest
    {
        private CarController controller;
        private CarRepositoryMock carRepositoryMock;
        private RentalOrderRepositoryMock rentalOrderRepositoryMock;
        private RentalRateRepositoryMock rateRepositoryMock;
        private ContextMock contextMock;
        private CarService carService;
        private OrderService orderService;

        [TestInitialize]
        public void TestInitialize()
        {
            DateTime date = new DateTime(2011, 1, 2, 12, 12, 12);
            SystemTime.Now = () => date;

            this.carRepositoryMock = new CarRepositoryMock();
            this.rentalOrderRepositoryMock = new RentalOrderRepositoryMock();
            this.rateRepositoryMock = new RentalRateRepositoryMock();
            this.contextMock = new ContextMock();

            this.orderService = new OrderService(this.carRepositoryMock, this.rentalOrderRepositoryMock, this.rateRepositoryMock, this.contextMock);
            this.carService = new CarService(this.carRepositoryMock, this.rentalOrderRepositoryMock);

            this.controller = new CarController(this.carService, this.orderService);
            this.controller.ControllerContext = new ControllerContext();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            SystemTime.Now = null;
        }

        [TestMethod]
        public void Index()
        {
            this.AddCarToRepository();

            ActionResult result = this.controller.Index();

            var model = result.GetModel<CarsViewModel>();
            Assert.AreEqual(1, model.Cars.Count);
        }

        [TestMethod]
        public void Search()
        {
            this.AddCarToRepository();

            CarsViewModel carsModelView = new CarsViewModel();
            carsModelView.DatePickerModelView.RentalPickUpDate = SystemTime.Now();

            ActionResult result = this.controller.Search(carsModelView);

            Assert.AreEqual(SystemTime.Now().AddDays(1), carsModelView.DatePickerModelView.RentalReturnDate);
            Assert.IsTrue(result.GetModel<CarsViewModel>().Cars.Count == 1);

            result.AssertHasViewName("Index");
        }

        [TestMethod]
        public void Search_OneCarIsUnavailable()
        {
            this.AddUnavailableForTodayCarToRepository();
            CarsViewModel carsModelView = new CarsViewModel();
            carsModelView.DatePickerModelView.RentalPickUpDate = SystemTime.Now();

            ActionResult result = this.controller.Search(carsModelView);

            Assert.AreEqual(SystemTime.Now().AddDays(1), carsModelView.DatePickerModelView.RentalReturnDate);
            Assert.AreEqual(1, result.GetModel<CarsViewModel>().Cars.Count);

            result.AssertHasViewName("Index");
        }

        [TestMethod]
        public void SearchToday()
        {
            this.AddCarToRepository();
            ActionResult result = this.controller.SearchToday();

            Assert.AreEqual(1, result.GetModel<CarsViewModel>().Cars.Count);
            result.AssertHasViewName("Index");
        }

        [TestMethod]
        public void Search_WhenOneCarIsUnavailableToday_ShouldReturnOneCar()
        {
            this.AddUnavailableForTodayCarToRepository();

            ActionResult result = this.controller.SearchToday();

            Assert.AreEqual(1, result.GetModel<CarsViewModel>().Cars.Count);

            result.AssertHasViewName("Index");
        }

        [TestMethod]
        public void Details()
        {
            DateTime date = new DateTime(2011, 1, 2, 12, 12, 12);
            SystemTime.Now = () => date;

            this.AddCarToRepository();

            ActionResult result = this.controller.Details(1);

            CarDetailViewModel viewModel = result.GetModel<CarDetailViewModel>();
            Car expectedCar = this.carRepositoryMock.Cars.OfType<Car>().First(x => x.CarID == 1);

            Assert.AreEqual(expectedCar.CarID, viewModel.Car.CarID);
            Assert.AreEqual(1, viewModel.NewRentalOrder.CarID);
            Assert.AreEqual(date, viewModel.NewRentalOrder.RentStartDate);
            Assert.AreEqual(date.AddDays(7), viewModel.NewRentalOrder.RentEndDate);
            
            SystemTime.Now = null;
        }

        [TestMethod]
        public void Details_NotFound()
        {
            ActionResult result = this.controller.Details(35);

            result.AssertHasViewName("NotFound");
        }

        private void AddCarToRepository()
        {
            this.carRepositoryMock.Cars = new List<Car>() 
            {
                new Car() { CarID = 1 }
            };
        }

        private void AddUnavailableForTodayCarToRepository()
        {

            int unavailableCarId = 2;
            this.carRepositoryMock.Cars = new List<Car>() 
            {
                new Car() 
                { 
                    CarID = 1 
                },
                new Car() 
                { 
                    CarID = unavailableCarId, 
                }
            };
            Car unavailableCar = this.carRepositoryMock.Cars.FirstOrDefault(x => x.CarID == unavailableCarId);
            RentalOrder newOrder = new RentalOrder()
            {
                RentStartDate = SystemTime.Now().AddDays(-2),
                RentEndDate = SystemTime.Now().AddDays(2),
                RentalOrderID = 1,
                CarID = unavailableCarId,
                Car = unavailableCar,
                RateApplied = 5
            };
            unavailableCar.RentalOrders.Add(newOrder);
            this.rentalOrderRepositoryMock.Orders.Add(newOrder);
        }

    }
}
