using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab1Components
{
    public class Order : ISaveableEntity
    {
        public int Id { get; set; }

        public Warehouse Warehouse { get; }
        public List<Goods> Goods { get; }

        public double EstimateDeliveryTime { get; set; }

        public Order(List<Goods> goods,Warehouse warehouse)
        {
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