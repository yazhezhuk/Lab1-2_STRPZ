using System;
using System.Collections.Generic;

namespace DAL.Repositories.Abstractions
{
    public interface IRepository<T>
    {
        void Add(T obj);

        List<T> GetAll(Predicate<T> filter = null);

        T GetById(int id);

        void Update(T obj);

        void Delete(int id);
    }
}