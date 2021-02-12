using System.Collections.Generic;

namespace Lab1Components
{
    public interface IRepository<T>
    {
        void Insert(T obj);
        T GetById(int id);
        List<T> GetAll();
        void Update(T obj);
        void Delete(T obj);
    }
}