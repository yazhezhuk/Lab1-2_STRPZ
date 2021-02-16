using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1Components
{
    public class InMemoryDataStub
    {
        private Dictionary<string, IEnumerable<ISaveableEntity>> Data { get; }

        private static InMemoryDataStub _instance;

        public static InMemoryDataStub Instance
        {
            get => _instance ?? new InMemoryDataStub();
            set => _instance = value;
        }

        private InMemoryDataStub()
        {
            Data = new Dictionary<string, IEnumerable<ISaveableEntity>>
            {
                {
                    "Manager", new List<Manager>
                        {new Manager(0, "Anton", 21), new Manager(1, "Billy", 40)}
                },
                {
                    "Driver", new List<Driver>
                        {new Driver(0, "Evgeniy", 19), new Driver(1, "Nazar", 20)}
                },
                {
                    "Goods", new List<Goods>
                    {
                        new Goods(0, GoodsType.Food, 100),
                        new Goods(1, GoodsType.Electronics, 1000),
                        new Goods(2, GoodsType.Furniture, 1500)
                    }
                },
                {
                    "Warehouse", new List<Warehouse>
                    {
                        new Warehouse(0, "First", 200),
                        new Warehouse(1, "Second", 100),
                        new Warehouse(2, "Third", 250),
                        new Warehouse(3, "Fourth", 310),
                        new Warehouse(4, "Fifth", 1002),
                    }
                },
                {
                    "Order", new List<Order>()
                }
            };
        }

        public IEnumerable<ISaveableEntity> GetDataByType(Type type)
        {
            return Data[type.Name];
        }
    }
}