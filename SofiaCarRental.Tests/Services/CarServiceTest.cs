using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.DAL;
using SofiaCarRental.Models;
using SofiaCarRental.Services;
using SofiaCarRental.Tests.Mocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SofiaCarRental.Tests.Services
{
    [TestClass]
    public class CarServiceTest
    {
        private CarRepositoryMock carRepository;
        private RentalOrderRepositoryMock orderRepository;
        private CarService carService;

        [TestInitialize]
        public void TestInitialize()
        {
            this.carRepository = this.GetCarRepository();
            this.orderRepository = new RentalOrderRepositoryMock();
            this.carService = new CarService(this.carRepository, this.orderRepository);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.carRepository = null;
            this.orderRepository = null;
            this.carService = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_CarRepositoryParamIsNull()
        {
            new CarService(null, this.orderRepository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_OrderRepositoryParamIsNull()
        {
            new CarService(this.carRepository, null);
        }

        [TestMethod]
        public void Constructor_ShouldCreateAnInstanceOfCarService()
        {
            // should not throw exception
            new CarService(this.carRepository, this.orderRepository);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllCarsFromRepository()
        {
            CarsViewModel carsViewModel = this.carService.GetAll();

            CollectionAssert.AreEqual(carsViewModel.Cars as ICollection, this.carRepository.Cars as ICollection);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Find_CarsViewModelParamIsNull()
        {
            this.carService.Find(null);
        }

        [TestMethod]
        public void Find_AvailableCars_ShouldReturnAvailableCarsFromRepository()
        {
            CarsViewModel carsViewModel = this.GetCarsViewModel();

            CarsViewModel availableCarsViewModel = this.carService.Find(carsViewModel);

            CollectionAssert.AreEqual(carsViewModel.Cars as ICollection, availableCarsViewModel.Cars as ICollection);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Find_AvailableCars_CarsViewModelParamIsNull()
        {
            CarsViewModel availableCarsViewModel = this.carService.Find(null);
        }

        [TestMethod]
        public void FindToday_AvailableCarsForToday_ShouldReturnAvailableCarsForToday()
        {
            CarsViewModel availableCarsViewModel = this.carService.FindToday();

            CollectionAssert.AreEqual(this.carRepository.Cars as ICollection, availableCarsViewModel.Cars as ICollection);
        }

        [TestMethod]
        public void Details_CarIdIsNull_ShouldReturnNull()
        {
            CarDetailViewModel result = this.carService.Details(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Details_CarIdIsInvalid_ShouldReturnNull()
        {
            CarDetailViewModel result = this.carService.Details(200);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Details_ShouldReturnCorrectCarDetails()
        {
            int carId = 1;
            var car = this.carRepository.Cars.FirstOrDefault(x => x.CarID == carId);

            CarDetailViewModel result = carService.Details(carId);

            Assert.IsNotNull(car);
            Assert.IsNotNull(result);
            Assert.AreSame(car, result.Car);
        }

        private CarsViewModel GetCarsViewModel()
        {
            CarsViewModel carsViewModel = new CarsViewModel();
            carsViewModel.Cars = this.carRepository.Cars;
            carsViewModel.DatePickerModelView = new DatePickerModelView()
            {
                RentalPickUpDate = new DateTime(2012, 11, 6, 15, 40, 30),
                RentalPickUpTime = new DateTime(2012, 11, 6, 6, 15, 40, 30),
                RentalReturnDate = new DateTime(2012, 11, 7, 6, 15, 40, 30),
                RentalReturnTime = new DateTime(2012, 11, 7, 6, 15, 40, 30)
            };
            return carsViewModel;
        }

        private CarRepositoryMock GetCarRepository()
        {
            CarRepositoryMock repository = new CarRepositoryMock();
            List<Car> testData = new List<Car>()
            {
                new Car()
                {
                    CarID = 1,
                    Make = "VW",
                },
                new Car()
                {
                    CarID = 7,
                    Make = "BMW",
                },
                new Car()
                {
                    CarID = 14,
                    Make = "Mercedes",
                },
                new Car()
                {
                    CarID = 21,
                    Make = "Toyota",
                },
            };
            repository.Cars = testData;

            return repository;
        }


    }
}
