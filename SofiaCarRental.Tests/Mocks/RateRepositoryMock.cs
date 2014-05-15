using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SofiaCarRental.DAL;
using SofiaCarRental.Repositories;

namespace SofiaCarRental.Tests.Mocks
{
    public class RentalRateRepositoryMock : IRentalRateRepository
    {
        public RentalRateRepositoryMock()
        {
            this.RentalRates = new List<RentalRate>();
        }

        public List<RentalRate> RentalRates { get; set; }

        public RentalRate Find(int id)
        {
            return this.RentalRates.FirstOrDefault(x => x.RentalRateID == id);
        }

        public void Add(RentalRate order)
        {
            throw new NotImplementedException();
        }

        public IList<RentalRate> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(RentalRate order)
        {
            throw new NotImplementedException();
        }

        public RentalRate Find(Expression<Func<RentalRate, bool>> predicate)
        {
            return this.RentalRates.AsQueryable().FirstOrDefault(predicate);
        }
    }
}
