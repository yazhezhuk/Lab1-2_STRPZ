using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Lab1Components
{
    public class Warehouse : ISaveableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Distance { get; set; }

        public Warehouse(string name, int distance)
        {
            Name = name;
            Distance = distance;
        }
    }
}
