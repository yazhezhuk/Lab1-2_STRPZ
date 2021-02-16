using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lab1Components
{
    public interface IRepository<T>
    {
        void Insert(T obj);

        List<T> GetAll(Predicate<T> filter = null);

        T GetById(int id);

        void Update(T obj);
        
        void Delete(T obj);
    }
}