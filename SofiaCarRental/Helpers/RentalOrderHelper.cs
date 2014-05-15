using SofiaCarRental.DAL;

namespace SofiaCarRental.Helpers
{
    public class RentalOrderHelper
    {
        public static RentalOrder PrepareNewOrder(int carId)
        {
            return new RentalOrder
                       {
                           CarID = carId,
                           RentStartDate = SystemTime.Now(),
                           RentEndDate = SystemTime.Now().AddDays(7)
                       };
        }
    }
}