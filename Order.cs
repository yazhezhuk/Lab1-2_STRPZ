using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab1Components
{
    public class Order : IPrintable
    {
        public Warehouse Warehouse { get; }
        public Goods Goods { get; }

        public int EstimateTime { get; set; }

        public Order(Goods goods,Warehouse warehouse)
        {
            Warehouse = warehouse;
            Goods = goods;
        }

        public double Cost
        {
            get => Goods.Price + Warehouse.Distance * 0.1;
        }

        public void Print()
        {
            Console.WriteLine($"Your order will cost {Cost} hrn:");
            Goods.Print();
            Console.WriteLine($"and will be delivered to {Warehouse.Name} in about {EstimateTime} hours");
        }
    }
}