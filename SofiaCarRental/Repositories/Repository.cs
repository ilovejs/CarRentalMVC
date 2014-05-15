using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SofiaCarRental.DAL;

namespace SofiaCarRental.Repositories
{
    public abstract class Repository<T> : IDisposable, IRepository<T>
        where T : class
    {
        protected ISofiaCarRentalContextUnitOfWork Context
        {
            get;
            private set;
        }

        protected Repository( ISofiaCarRentalContextUnitOfWork context )
        {
            this.Context = context;
        }

        public IList<T> GetAll()
        {
            return this.Context.GetAll<T>().ToList();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return this.Context.GetAll<T>().FirstOrDefault(predicate);
        }

        public void Add(T order)
        {
            this.Context.Add(order);
        }

        public void Remove(T order)
        {
            this.Context.Delete(order);
        }

        public void Dispose()
        {
            this.Context = null;
        }
    }
}