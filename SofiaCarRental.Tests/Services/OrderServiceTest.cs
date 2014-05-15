using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.DAL;
using SofiaCarRental.Helpers;
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
    public class OrderServiceTest
    {
        private CarRepositoryMock carRepository;
        private RentalOrderRepositoryMock orderRepository;
        private RentalRateRepositoryMock rateRepository;
        private ContextMock unitOfWork;
        private OrderService orderService;

        private readonly int TestCarId = 1;
        private readonly DateTime TestCarRentStartDate = SystemTime.Now().AddDays(-100);
        private readonly DateTime TestCarRentEndDate = SystemTime.Now().AddDays(-50);
        private readonly int TestOrderId = 1;

        [TestInitialize]
        public void TestInitialize()
        {
            this.carRepository = this.GetCarRepository();
            this.orderRepository = this.GetOrderRepository();
            this.rateRepository = this.GetRentRepository();
            this.unitOfWork = new ContextMock();
            this.orderService = new OrderService(this.carRepository, this.orderRepository, this.rateRepository, this.unitOfWork);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.carRepository = null;
            this.orderRepository = null;
            this.rateRepository = null;
            this.unitOfWork = null;
            this.orderService = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_CarRepositoryParamIsNull()
        {
            new OrderService(null, this.orderRepository, this.rateRepository, this.unitOfWork);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_OrderRepositoryParamIsNull()
        {
            new OrderService(this.carRepository, null, this.rateRepository, this.unitOfWork);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_RateRepositoryParamIsNull()
        {
            new OrderService(this.carRepository, this.orderRepository, null, this.unitOfWork);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_UnitOfWorkParamIsNull()
        {
            new OrderService(this.carRepository, this.orderRepository, this.rateRepository, null);
        }

        [TestMethod]
        public void Constructor_ShouldCreateAnInstanceOfOrderService()
        {
            // should not throw exception
            new OrderService(this.carRepository, this.orderRepository, this.rateRepository, this.unitOfWork);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddRentalOrder_RentalOrderParamIsNull()
        {
            this.orderService.AddRentalOrder(null);
        }

        [TestMethod]
        public void AddRentalOrder_ShouldAddTheOrderToRentalOrderRepositoryAddedOrders()
        {
            DateTime newRentalStartTime = SystemTime.Now().AddDays(-2);
            DateTime newRentalEndTime = SystemTime.Now().AddDays(2);

            RentalOrder rentalOrder = new RentalOrder();
            rentalOrder.RentStartDate = newRentalStartTime;
            rentalOrder.RentEndDate = newRentalEndTime;
            rentalOrder.CarID = this.TestCarId;

            this.orderService.AddRentalOrder(rentalOrder);
            RentalOrder resultOrder = this.orderRepository.AddedOrders.FirstOrDefault(o =>
                o.CarID == rentalOrder.CarID &&
                o.RentStartDate == rentalOrder.RentStartDate &&
                o.RentEndDate == rentalOrder.RentEndDate);

            Assert.IsNotNull(resultOrder);
            Assert.AreSame(rentalOrder, resultOrder);
        }

        [TestMethod]
        public void DeleteOrder_ShouldDeleteTheOrderWithThatId()
        {
            bool isOrderDeleted = this.orderService.DeleteOrder(TestOrderId);

            Assert.IsTrue(isOrderDeleted);
        }

        [TestMethod]
        public void DeleteOrder_WithInvalidID_ShouldntDeleteOrder()
        {
            int invalidOrderIndex = -1;
            bool isOrderDeleted = this.orderService.DeleteOrder(invalidOrderIndex);

            Assert.IsFalse(isOrderDeleted);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EditOrder_RentalOrderIsNull()
        {
            this.orderService.EditOrder(null);
        }

        [TestMethod]
        public void EditOrder_ShouldEditRentalStartDateAndEndDateOfOrderWithThatId()
        {
            DateTime newOrderStartTime = SystemTime.Now().AddDays(100);
            DateTime newOrderEndtime = SystemTime.Now().AddDays(150);
            RentalOrder editOrder = new RentalOrder();
            editOrder.RentalOrderID = TestOrderId;
            editOrder.RentStartDate = newOrderStartTime;
            editOrder.RentEndDate = newOrderEndtime;

            this.orderService.EditOrder(editOrder);
            RentalOrder dbOrderAfterEdit = this.orderRepository.Orders.Find(o => o.RentalOrderID == TestOrderId);

            Assert.IsNotNull(dbOrderAfterEdit);
            Assert.AreNotSame(dbOrderAfterEdit, editOrder);
            Assert.AreEqual(dbOrderAfterEdit.RentStartDate, editOrder.RentStartDate);
            Assert.AreEqual(dbOrderAfterEdit.RentEndDate, editOrder.RentEndDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExistRentalOrder_RentalOrderisNull()
        {
            this.orderService.ExistRentalOrder(null);
        }

        [TestMethod]
        public void ExistRentalOrder_StartDateConflict_OrderExist()
        {
            RentalOrder order = new RentalOrder();
            order.CarID = TestCarId;
            order.RentStartDate = TestCarRentStartDate.AddDays(-1);
            order.RentEndDate = TestCarRentStartDate.AddDays(1);

            bool doesOrderExist = this.orderService.ExistRentalOrder(order);

            Assert.IsTrue(doesOrderExist);
        }

        [TestMethod]
        public void ExistRentalOrder_EndDateConflict_OrderExist()
        {            
            RentalOrder order = new RentalOrder();
            order.CarID = TestCarId;
            order.RentStartDate = TestCarRentEndDate.AddDays(-1);
            order.RentEndDate = TestCarRentEndDate.AddDays(1);

            bool doesOrderExist = this.orderService.ExistRentalOrder(order);

            Assert.IsTrue(doesOrderExist);
        }

        [TestMethod]
        public void ExistRentalOrder_BetweenStartAndEndDate_OrderExist()
        {
            RentalOrder order = new RentalOrder();
            order.CarID = TestCarId;
            order.RentStartDate = TestCarRentStartDate.AddDays(1);
            order.RentEndDate = TestCarRentEndDate.AddDays(-1);

            bool doesOrderExist = this.orderService.ExistRentalOrder(order);

            Assert.IsTrue(doesOrderExist);
        }

        [TestMethod]
        public void ExistRentalOrder_BeforeStartDate_OrderDoNotExist()
        {
            RentalOrder order = new RentalOrder();
            order.CarID = TestCarId;
            order.RentStartDate = TestCarRentStartDate.AddDays(-1);
            order.RentEndDate = TestCarRentStartDate.AddDays(-2);

            bool doesOrderExist = this.orderService.ExistRentalOrder(order);

            Assert.IsFalse(doesOrderExist);
        }

        [TestMethod]
        public void ExistRentalOrder_AfterEndDate_OrderDoNotExist()
        {
            RentalOrder order = new RentalOrder();
            order.CarID = TestCarId;
            order.RentStartDate = TestCarRentEndDate.AddDays(1);
            order.RentEndDate = TestCarRentEndDate.AddDays(2);

            bool doesOrderExist = this.orderService.ExistRentalOrder(order);

            Assert.IsFalse(doesOrderExist);
        }

        [TestMethod]
        public void ExistRentalOrder_OrderWithoutDates_DefaultOrderDoNotExist()
        {
            RentalOrder order = new RentalOrder();
            order.CarID = TestCarId;

            //should take DateTime.Now() and DateTime.Now().AddDays(1) as default rent dates
            bool doesOrderExist = this.orderService.ExistRentalOrder(order);

            Assert.IsFalse(doesOrderExist);
        }

        private CarRepositoryMock GetCarRepository()
        {
            CarRepositoryMock repository = new CarRepositoryMock();
            List<Car> testData = new List<Car>()
            {
                new Car()
                {
                    CarID = TestCarId,
                    Make = "VW",
                    CategoryID = 1,
                },
                new Car()
                {
                    CarID = 7,
                    Make = "BMW",
                    CategoryID = 1,
                },
                new Car()
                {
                    CarID = 14,
                    Make = "Mercedes",
                    CategoryID = 2,
                },
                new Car()
                {
                    CarID = 21,
                    Make = "Toyota",
                    CategoryID = 2,
                },
            };
            repository.Cars = testData;

            return repository;
        }

        private RentalRateRepositoryMock GetRentRepository()
        {
            RentalRateRepositoryMock repository = new RentalRateRepositoryMock();
            List<RentalRate> testData = new List<RentalRate>()
            {
                new RentalRate()
                {
                    RentalRateID = 1,
                    CategoryID = 1
                },
                new RentalRate()
                {
                    RentalRateID = 2,
                    CategoryID = 2
                },
            };
            repository.RentalRates = testData;

            return repository;
        }

        private RentalOrderRepositoryMock GetOrderRepository()
        {
            RentalOrderRepositoryMock repository = new RentalOrderRepositoryMock();
            List<RentalOrder> testData = new List<RentalOrder>()
            {
                new RentalOrder()
                {
                    CustomerID = 1,
                    EmployeeID = 1,
                    RentalOrderID = TestOrderId,
                    RentStartDate = TestCarRentStartDate,
                    RentEndDate = TestCarRentEndDate,
                    Car = this.carRepository.Find(TestCarId),
                    CarID = TestCarId
                },
                new RentalOrder()
                {
                    CustomerID = 2,
                    EmployeeID = 2,
                    RentalOrderID = 2,
                    RentStartDate = SystemTime.Now().AddDays(-200),
                    RentEndDate = SystemTime.Now().AddDays(-150),
                    Car = this.carRepository.Find(14),
                    CarID = 14
                }
            };
            this.carRepository.Find(TestCarId).RentalOrders.Add(testData[0]);
            this.carRepository.Find(14).RentalOrders.Add(testData[1]);
            repository.Orders = testData;

            return repository;
        }

    }
}
