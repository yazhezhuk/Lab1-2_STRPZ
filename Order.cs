using System.Collections.Generic;
using System.Linq;

namespace Lab1Components
{
    public class Order : ISaveableEntity
    {
        public int Id { get; set; } = 0;

        public Warehouse Warehouse { get; }
        public List<Goods> Goods { get; }

        public List<Employee> ProcessingEmployees { get; set; }

        public double EstimateDeliveryTime { get; set; }

        public Order(int id,List<Goods> goods, Warehouse warehouse)
        {
            Id = id;
            Warehouse = warehouse;
            Goods = goods;
            ProcessingEmployees = new List<Employee>();
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