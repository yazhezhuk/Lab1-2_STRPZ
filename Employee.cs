using System;
using System.Runtime.CompilerServices;

namespace Lab1Components
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public double LoadHours { get; set; }

        protected Employee(string name)
        {
            Name = name;
            LoadHours = 0;
        }

        public abstract void ProcessOrder(Order order);
    }
}