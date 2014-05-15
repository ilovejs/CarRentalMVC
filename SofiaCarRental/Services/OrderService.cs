using System.Linq;
using SofiaCarRental.DAL;
using SofiaCarRental.Helpers;
using SofiaCarRental.Repositories;
using System;

namespace SofiaCarRental.Services
{
    public class OrderService
    {
        private readonly ICarRepository carRepository;
        private readonly IRentalOrderRepository orderRepository;
        private readonly IRentalRateRepository rateRepository;
        private readonly ISofiaCarRentalContextUnitOfWork unitOfWork;

        public OrderService(ICarRepository carRepository, IRentalOrderRepository orderRepository, IRentalRateRepository rateRepository, ISofiaCarRentalContextUnitOfWork unitOfWork)
        {
            if (carRepository == null)
            {
                throw new ArgumentNullException("carRepository", "The given parameter cannot be null.");
            }
            if (orderRepository == null)
            {
                throw new ArgumentNullException("orderRepository", "The given parameter cannot be null.");
            }
            if (rateRepository == null)
            {
                throw new ArgumentNullException("rateRepository", "The given parameter cannot be null.");
            }
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork", "The given parameter cannot be null.");
            }
            this.carRepository = carRepository;
            this.orderRepository = orderRepository;
            this.rateRepository = rateRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool AddRentalOrder(RentalOrder order)
        {
            if (order==null)
            {
                throw new ArgumentNullException("order", "The given parameter cannot be null.");
            }
            Car relatedCar = this.carRepository.Find(order.CarID);
            RentalRate rate = this.rateRepository.Find(x => x.CategoryID == relatedCar.CategoryID);

            order.DateProcessed = SystemTime.Now();
            order.CustomerID = this.orderRepository.GetAll().First().CustomerID;
            order.EmployeeID = this.orderRepository.GetAll().First().EmployeeID;
            order.CalculateAppliedRate(rate);

            try
            {
                this.orderRepository.Add(order);
                this.unitOfWork.SaveChanges();

                return true;
            }
            catch (Telerik.OpenAccess.OpenAccessException)
            {
            }

            return false;
        }

        public bool DeleteOrder(int id)
        {
            RentalOrder dbOrder = this.orderRepository.Find(id);
            if (dbOrder == null)
            {
                return false;
            }

            try
            {
                this.orderRepository.Remove(dbOrder);
                this.unitOfWork.SaveChanges();

                return true;
            }
            catch (Telerik.OpenAccess.OpenAccessException)
            {
            }

            return false;
        }

        public bool EditOrder(RentalOrder order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order", "The given parameter cannot be null.");
            }
            RentalOrder dbOrder = this.orderRepository.Find(order.RentalOrderID);
            if (dbOrder == null)
            {
                return false;
            }

            try
            {
                RentalRate rate = this.rateRepository.Find(x => x.CategoryID == dbOrder.Car.CategoryID);

                dbOrder.RentStartDate = order.RentStartDate;
                dbOrder.RentEndDate = order.RentEndDate;
                dbOrder.CalculateAppliedRate(rate);

                this.unitOfWork.SaveChanges();

                return true;
            }
            catch (Telerik.OpenAccess.OpenAccessException)
            {
            }

            return false;
        }

        public bool ExistRentalOrder(RentalOrder order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order", "The given parameter cannot be null.");
            }

            Car relatedCar = this.carRepository.Find(order.CarID);
            if (relatedCar == null)
            {
                return false;
            }

            DateTime startDate = order.RentStartDate;
            DateTime endDate = order.RentEndDate;

            return (relatedCar.IsAvailable(startDate, endDate) == false);
        }
    }
}