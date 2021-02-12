using System;
using System.Runtime.CompilerServices;

namespace Lab1Components
{
    public abstract class Employee : ISaveableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public double LoadedHours { get; set; }
        public Employee(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public abstract void ProcessOrder(Order order);
    }
}