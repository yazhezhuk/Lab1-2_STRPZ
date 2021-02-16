using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Lab1Components
{
    public class GenericRepository<T> : IRepository<T> where T : ISaveableEntity
    {
        private List<T> DataStorage { get; } = (List<T>)InMemoryDataStub.
                                                Instance.GetDataByType(typeof(T));

        public virtual void Delete(T obj)
        {
            DataStorage.Remove(obj);
        }

        public virtual List<T> GetAll(Predicate<T> filter = null)
        {
            return filter != null ? DataStorage.FindAll(filter) : DataStorage;
        }

        public virtual T GetById(int id)
        {
            return DataStorage.Find(e => e.Id == id);
        }

        public virtual void Insert(T obj)
        {
            DataStorage.Add(obj);
        }

        public virtual void Update(T obj)
        {

        }
    }
}