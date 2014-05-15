using System;
using System.Collections.Generic;
using SofiaCarRental.DAL;

namespace SofiaCarRental.Repositories
{
    public interface IRentalOrderRepository : IRepository<RentalOrder>
    {
        RentalOrder Find(int id);
        IEnumerable<RentalOrder> FindByDates(DateTime pickUpDate, DateTime returnDate);
    }
}