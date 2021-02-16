using System.Collections.Generic;
using System.Linq;

namespace Lab1Components
{
    public class Order : ISaveableEntity
    {
        public int Id { get; set; } = 0;

        public Driver Driver { get; set; }
        public Manager Manager { get; set; }
        public Warehouse Warehouse { get; set; }
        public List<Goods> Goods { get; set; }

        public double EstimateDeliveryTime { get; set; }

        public Order(Driver driver, Manager manager, Warehouse warehouse, List<Goods> goods)
        {
            Driver = driver;
            Manager = manager;
            Warehouse = warehouse;
            Goods = goods;
        }

        public double Cost
        {
            get
            {
                return Goods.Sum(e => e.Price) + Warehouse.Distance * 0.2;
            }
        }
    }
}