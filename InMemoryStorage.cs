using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1Components
{
  public class InMemoryStorage
  {
    private Dictionary<string, IEnumerable<ISaveableEntity>> Data { get; }

    private static InMemoryStorage _instance;
    public static InMemoryStorage Instance
    {
      get => _instance ?? new InMemoryStorage();
      set => _instance = value;
    }

    private InMemoryStorage()
    {
      Data = new Dictionary<string, IEnumerable<ISaveableEntity>>
            {
                { "Manager", new List<Manager>() },
                { "Driver", new List<Driver>() },
                { "Goods", new List<Goods>() },
                { "Warehouse", new List<Warehouse>() }
            };
    }

    public void DataInit()
    {

    }

    public IEnumerable<ISaveableEntity> GetDataByType(Type type)
    {
      return Data[type.Name];
    }
  }
}