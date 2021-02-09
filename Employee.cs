using System;
using System.Runtime.CompilerServices;

namespace Lab1Components
{
    public enum EmployeeState
    {
        Busy,
        Free
    }

    public abstract class Employee:IPrintable
    {
        public string Name { get; set; }
        public EmployeeState State { get; set; }
        public int LoadHours { get; set; }

        protected Employee(string name)
        {
            Name = name;
            LoadHours = 0;
            State = EmployeeState.Free;
        }

        public void Print()
        {
            Console.WriteLine(Name);
        }
        public abstract void ProcessOrder(Order order);

    }
}