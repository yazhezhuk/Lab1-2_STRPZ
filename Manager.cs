using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace Lab1Components
{
    public class Manager: Employee
    {
        public Manager(string name):base(name) { }

        public override void ProcessOrder(Order order)
        {
            LoadHours += order.Goods.ProcessTime;
            order.EstimateTime += LoadHours;
            System.Console.WriteLine(
                $"Manager {Name} will soon start to process your order, please wait {order.EstimateTime} hours");
        }

    }
}