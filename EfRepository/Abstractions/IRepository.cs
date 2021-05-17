using System.Collections.Generic;

namespace EfRepository.Abstractions
{
    public interface IRepository<T>
    {
        void AddOrUpdate(T obj);
        void Add(T obj);
        List<T> GetAll();

        T GetById(int id);
        
        void Delete(T id);
        void Update(T obj);
    }
}