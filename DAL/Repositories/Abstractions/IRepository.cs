using System;
using System.Collections.Generic;

namespace DAL.Repositories.Abstractions
{
    public interface IRepository<T>
    {
        void AddOrUpdate(T obj);
        List<T> GetAll();

        T GetById(int id);
        
        void Delete(int id);
    }
}