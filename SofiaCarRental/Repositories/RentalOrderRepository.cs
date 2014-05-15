using System;
using System.Collections.Generic;
using System.Linq;
using SofiaCarRental.DAL;

namespace SofiaCarRental.Repositories
{
    public class RentalOrderRepository : Repository<RentalOrder>, IRentalOrderRepository
    {
        public RentalOrderRepository( ISofiaCarRentalContextUnitOfWork context ) 
            : base(context)
        {
        }

        public RentalOrder Find(int id)
        {
            return this.Context.GetAll<RentalOrder>().FirstOrDefault(x => x.RentalOrderID == id);
        }

        public IEnumerable<RentalOrder> FindByDates(DateTime pickUpDate, DateTime returnDate)
        {
            return this.Context.GetAll<RentalOrder>()
                               .Where<RentalOrder>(x => x.RentStartDate >= returnDate || x.RentEndDate <= pickUpDate);
        }
    }
}