using System;
using System.Collections.Generic;
using System.Linq;
using SofiaCarRental.DAL;
using SofiaCarRental.Repositories;

namespace SofiaCarRental.Tests.Mocks
{
    class CarRepositoryMock : ICarRepository
    {
        public List<Car> Cars { get; set; }

        public CarRepositoryMock()
        {
            this.Cars = new List<Car>();
        }

        public IList<Car> GetAll()
        {
            return this.Cars;
        }

        public Car Find(int id)
        {
            return this.Cars.SingleOrDefault(x => x.CarID == id);
        }

        public void Add(Car order)
        {
            throw new NotImplementedException();
        }

        public void Remove(Car order)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Car Find(System.Linq.Expressions.Expression<Func<Car, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
