using System;
using System.Collections.Generic;
using System.Linq;
using SofiaCarRental.DAL;
using SofiaCarRental.Repositories;

namespace SofiaCarRental.Tests.Mocks
{
    public class RentalOrderRepositoryMock : IRentalOrderRepository
    {
        public List<RentalOrder> Orders { get; set; }
        public List<RentalOrder> AddedOrders { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public RentalOrderRepositoryMock()
        {
            this.Orders = new List<RentalOrder>();
            this.AddedOrders = new List<RentalOrder>();
        }

        public IList<RentalOrder> GetAll()
        {
            return this.Orders;
        }

        public RentalOrder Find(int id)
        {
            return this.Orders.FirstOrDefault(x => x.RentalOrderID == id);
        }

        public void Add(RentalOrder order)
        {
            this.AddedOrders.Add(order);
        }

        public void Remove(RentalOrder order)
        {
            this.Orders.Remove(order);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public RentalOrder Find(System.Linq.Expressions.Expression<Func<RentalOrder, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RentalOrder> FindByDates(DateTime pickUpDate, DateTime returnDate)
        {
            this.StartDate = pickUpDate;
            this.EndDate = returnDate;

            return this.Orders;
        }
    }
}
