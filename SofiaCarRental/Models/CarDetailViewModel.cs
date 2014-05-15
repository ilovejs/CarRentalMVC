using SofiaCarRental.DAL;

namespace SofiaCarRental.Models
{
    public class CarDetailViewModel
    {
        public CarDetailViewModel(Car car, RentalOrder order)
        {
            this.Car = car;
            this.NewRentalOrder = order;
        }

        public Car Car { get; set; }
        public RentalOrder NewRentalOrder { get; set; }
    }
}