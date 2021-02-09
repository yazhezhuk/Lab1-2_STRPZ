using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

namespace Lab1Components
{
    public class Shop
    {

        public List<Employee> Managers { get; set; }
        public List<Employee> Drivers { get; set; }
        public List<Goods> Goods { get; set; }
        public List<Warehouse> Warehouses { get; set; }

        public string Name { get; set; }

        public Shop(string name)
        {
            Managers = new List<Employee>();
            Drivers = new List<Employee>();
            Goods = new List<Goods>();
            Warehouses = new List<Warehouse>();

            Managers.AddRange(new Employee[]
                { new Manager("Vitaliy"),new Manager("Denis"),new Manager("Artem") });
            Drivers.AddRange(new Employee[]
                { new Driver("Yuriy"), new Driver("Yaroslave"), new Driver("Billy") });
            Warehouses.AddRange(new Warehouse[]
                { new Warehouse("First",200),new Warehouse("Second",350)
                    ,new Warehouse("Third",400),new Warehouse("Fourth",500)  });

            Name = name;
        }

        public void OrderBuilder(string username)
        {
            Console.WriteLine($"Welcome to our shop \n");
            PrintItems(new List<IPrintable>(Goods));
            Order order;
            Goods selectedProduct = null;
            Warehouse selectedWarehouse = null;
            while (true)
            {
                Console.WriteLine($"Menu: \n " +
                                  $"0)Exit" +
                                  $"1)Select goods" +
                                  $"2)Select warehouse" +
                                  $"3)Process order");
                int choice = Console.Read();
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        selectedProduct = GoodsSelector();
                        break;
                    case 2:
                        selectedWarehouse = WarehouseSelector();
                        break;
                    case 3:
                        if (selectedWarehouse != null && selectedProduct != null)
                        {
                            order = new Order(selectedProduct,selectedWarehouse);
                            ProcessOrder(order);
                            order.Print();

                            Unselect(ref selectedProduct, ref selectedWarehouse);
                        }
                        break;
                } 
                
            }






        }

        private void Unselect(ref Goods goods, ref Warehouse warehouse)
        {
            goods = null;
            warehouse = null;
        }

        private Goods GoodsSelector()
        {
            Console.WriteLine($"Please choose one of our goods to order or press 0 to leave:");
            PrintItems(new List<IPrintable>(Goods));
            int choice = Console.Read();
            if (choice == 0)
            {
                return null;
            } 
            else if (choice < Goods.Count)
            {
                return Goods[choice + 1];
            }

            return null;
        }

        private Warehouse WarehouseSelector()
        {
            Console.WriteLine($"Please choose one of our warehouses or press 0 to leave:");
            PrintItems(new List<IPrintable>(Warehouses));
            int choice = Console.Read();
            if (choice == 0)
            {
                return null;
            }
            else if (choice < Warehouses.Count)
            {
                return Warehouses[choice + 1];
            }

            return null;
        }

        private void PrintItems(List<IPrintable> items)
        {
            items.ForEach(i => i.Print());
        }

        public void ProcessOrder(Order order)
        {
            Employee driver = FindLeastBusyEmployee(Drivers);
            Employee manager = FindLeastBusyEmployee(Managers);

            driver.ProcessOrder(order);
            manager.ProcessOrder(order);
        }

        public Employee FindLeastBusyEmployee(List<Employee> employees)
        {
            Employee leastBusy = Managers.First();
            foreach (var employee in employees)
            {
                leastBusy = (leastBusy.LoadHours < employee.LoadHours) 
                    ? employee
                    : leastBusy;
            }
            return leastBusy;
        }

    }
}