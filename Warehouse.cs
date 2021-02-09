using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Lab1Components
{
    public class Warehouse :IPrintable
    {
        public Warehouse(string name, int distance)
        {
            Name = name;
            Distance = distance;
        }

        public string Name { get; set; }
        public int Distance { get; set; }

        public void Print()
        {
            Console.WriteLine($"Warehouse {Name} is {Distance} km away");
        }
    }
}
