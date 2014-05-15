using System.Collections.Generic;
using System.Linq;
using SofiaCarRental.DAL;
using Telerik.OpenAccess;

namespace SofiaCarRental.Tests.Mocks
{
    public class ContextMock : ISofiaCarRentalContextUnitOfWork
    {
        public ContextMock()
        {
            this.List = new List<object>();
            this.AddedObjects = new List<object>();
            this.SaveChangesCalled = false;
        }

        public List<object> List { get; set; }
        public List<object> AddedObjects { get; set; }
        public object DeletedObject { get; set; }
        public bool SaveChangesCalled { get; set; }

        public IQueryable<T> GetAll<T>()
        {
            return this.List.OfType<T>().AsQueryable();
        }

        public void Add(object entity)
        {
            this.AddedObjects.Add(entity);
        }

        public void SaveChanges()
        {
            this.SaveChangesCalled = true;
        }

        public void Delete(object entity)
        {
            this.DeletedObject = entity;
        }

        public IQueryable<RentalRate> RentalRates
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public IQueryable<RentalOrder> RentalOrders
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public IQueryable<Employee> Employees
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public IQueryable<Customer> Customers
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public IQueryable<Category> Categories
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public IQueryable<Car> Cars
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }


        public void ClearChanges()
        {
            throw new System.NotImplementedException();
        }

        public T GetObjectByKey<T>( ObjectKey key )
        {
            throw new System.NotImplementedException();
        }
    }
}
