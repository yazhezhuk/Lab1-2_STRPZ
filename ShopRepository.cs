using System;
using System.Collections.Generic;

namespace Lab1Components
{
  public class ShopRepository<T> : IRepository<T> where T : ISaveableEntity
  {
    private List<T> DataStorage = (List<T>)InMemoryStorage.Instance.GetDataByType(typeof(T));
    public virtual void Delete(T obj)
    {
      DataStorage.Remove(obj);
    }

    public virtual List<T> GetAll()
    {
      return DataStorage;
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
      throw new InvalidOperationException();
    }
  }
}