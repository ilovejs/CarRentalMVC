using System;
using System.Collections.Generic;
using System.Linq;
using SofiaCarRental.DAL;
using SofiaCarRental.Helpers;
using SofiaCarRental.Models;
using SofiaCarRental.Repositories;

namespace SofiaCarRental.Services
{
    public class CarService
    {
        private readonly ICarRepository carRepository;
        private readonly IRentalOrderRepository orderRepository;

        public CarService(ICarRepository carRepository, IRentalOrderRepository orderRepository)
        {
            if (carRepository == null)
            {
                throw new ArgumentNullException("carRepository", "The given parameter cannot be null.");
            }
            if (orderRepository == null)
            {
                throw new ArgumentNullException("orderRepository", "The given parameter cannot be null.");
            }
            this.carRepository = carRepository;
            this.orderRepository = orderRepository;
        }

        public CarsViewModel GetAll()
        {
            return new CarsViewModel
                       {
                           Cars = this.carRepository.GetAll().ToList()
                       };
        }

        public CarsViewModel Find(CarsViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model", "The given parameter cannot be null.");
            }

            DateTime? pickUpDateTime = model.DatePickerModelView.RentalPickUpDate;
            DateTime? returnDateTime = model.DatePickerModelView.RentalReturnDate;

            CarsSearchUtils.ModifyDatesIfNecessary(ref pickUpDateTime, ref returnDateTime);

            model.DatePickerModelView.RentalPickUpDate = pickUpDateTime;
            model.DatePickerModelView.RentalReturnDate = returnDateTime;

            CarsViewModel viewModel = new CarsViewModel();

            this.PopulateCarsInModel(pickUpDateTime, returnDateTime, viewModel);

            return viewModel;
        }

        public CarsViewModel FindToday()
        {
            DateTime rentalPickup = SystemTime.Now();
            DateTime rentalReturn = SystemTime.Now().AddDays(1);

            CarsViewModel viewModel = new CarsViewModel();
            this.PopulateCarsInModel(rentalPickup, rentalReturn, viewModel);

            return viewModel;

        }

        private void PopulateCarsInModel(DateTime? pickUpDate, DateTime? returnDate, CarsViewModel viewModel)
        {
            if (pickUpDate.HasValue == false || returnDate.HasValue == false)
            {
                return;
            }

            viewModel.Cars = this.carRepository.GetAll().Where(x => x.IsAvailable(pickUpDate.Value, returnDate.Value)).ToList();
        }

        public CarDetailViewModel Details(int? carId)
        {
            if (carId.HasValue == false)
            {
                return null;
            }

            Car car = this.carRepository.Find(carId.Value);
            if (car == null)
            {
                return null;
            }

            car.RentalOrders.ToList();
            return new CarDetailViewModel(car, RentalOrderHelper.PrepareNewOrder(car.CarID));
        }
    }
}