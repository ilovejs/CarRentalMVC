using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SofiaCarRental.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        T Find(Expression<Func<T, bool>> predicate);

        void Add(T order);
        IList<T> GetAll();
        void Remove(T order);
    }
}