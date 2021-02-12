using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1Components
{
    public class InMemoryStorage
    {
        private Dictionary<string, IList> Data { get; }

        private static InMemoryStorage _instance;
        public static InMemoryStorage Instance
        {
            get => _instance ?? new InMemoryStorage();
            set => _instance = value;
        }

        private InMemoryStorage()
        {
            Data = new Dictionary<string, IList>
            {
                { "Managers", new List<Employee>() },
                { "Drivers", new List<Employee>() },
                { "Goods", new List<Goods>() },
                { "Warehouse", new List<Warehouse>() }
            };
        }

        public void DataInit()
        {
            
        }

        public IList GetDataByType(Type type)
        {
            return Data[type.FullName + "s"];
        }
    }
}