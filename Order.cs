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

        public double EstimateTime { get; set; }

        public Order(Goods goods,Warehouse warehouse)
        {
            Warehouse = warehouse;
            Goods = goods;
        }

        public double Cost
        {
            get => Goods.Price + Warehouse.Distance * 0.2;
        }

        public void Print()
        {
            Console.WriteLine($"Your order total cost (goods cost + delivery) is {Cost} hrn. \n" +
                              $"Ordered items:");
            Goods.Print();
            Console.WriteLine($"-----This order will be delivered to {Warehouse.Name} warehouse in about {EstimateTime} hours------");
        }
    }
}