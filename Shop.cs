using System;
using System.Collections.Generic;
using System.Linq;

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
            Warehouses.AddRange(new[]
                { new Warehouse("First",200),new Warehouse("Second",350)
                    ,new Warehouse("Third",400),new Warehouse("Fourth",500)  });
            Goods.AddRange(new[]
                { new Goods(GoodsType.Food,100), new Goods(GoodsType.Furniture,1500),
                    new Goods(GoodsType.Electronics,2000) });

            Name = name;
        }

        public void OrderBuilder(string username)
        {
            Console.WriteLine($"Welcome to {Name}, {username} \n");
            Order order;
            Goods selectedProduct = null;
            Warehouse selectedWarehouse = null;
            while (true)
            {
                Console.WriteLine($"Menu: \n" +
                                  $"0)Exit. \n" +
                                  $"1)Select goods. \n" +
                                  $"2)Select warehouse. \n" +
                                  $"3)Process order. \n");
                ConsoleKey choice = Console.ReadKey().Key;
                Console.WriteLine();
                switch (choice)
                {
                    case ConsoleKey.D0:
                        return;

                    case ConsoleKey.D1:
                        selectedProduct = GoodsSelector();
                        break;
                    case ConsoleKey.D2:
                        selectedWarehouse = WarehouseSelector();
                        break;
                    case ConsoleKey.D3:
                        if (selectedWarehouse != null && selectedProduct != null)
                        {
                            order = new Order(selectedProduct, selectedWarehouse);
                            ProcessOrder(order);
                            order.Print();

                            Unselect(ref selectedProduct, ref selectedWarehouse);
                        }
                        else
                        {
                            Console.WriteLine($"Something is missing here, be sure to select warehouse and goods \n");
                        }
                        break;
                }

            }
        }

        private void Unselect(ref Goods goods,ref  Warehouse warehouse)
        {
            goods = null;
            warehouse = null;
        }

        private Goods GoodsSelector()
        {
            Console.WriteLine($"Please choose one of our goods to order or press 0 to leave:");
            PrintItems(new List<IPrintable>(Goods));
            do
            {
                int choice = Convert.ToChar(Console.ReadKey().Key) - '0';
                if (choice == 0)
                {
                    return null;
                }
                else if (choice <= Goods.Count)
                {
                    Console.WriteLine("Goods selected!");
                    return Goods[choice - 1];
                }
            } while (Console.ReadKey().Key != ConsoleKey.Enter);

            return null;
        }

        private Warehouse WarehouseSelector()
        {
            Console.WriteLine($"Please choose one of our warehouses or press 0 to leave:");
            PrintItems(new List<IPrintable>(Warehouses));
            do
            {
                int choice = Convert.ToChar(Console.ReadKey().Key) - '0';
                if (choice == 0)
                {
                    return null;
                }
                else if (choice <= Warehouses.Count)
                {
                    Console.WriteLine("Warehouse selected!");
                    return Warehouses[choice - 1];
                }
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
            return null;
        }

        public void PrintItems(List<IPrintable> items)
        {
            items.ForEach(i => i.Print());
        }

        public void ProcessOrder(Order order)
        {
            Employee driver = FindLeastBusyEmployee(Drivers);
            Employee manager = FindLeastBusyEmployee(Managers);

            manager.ProcessOrder(order);
            driver.ProcessOrder(order);
        }

        public Employee FindLeastBusyEmployee(List<Employee> employees)
        {
            Employee leastBusy = employees.First();
            foreach (var employee in employees)
            {
                leastBusy = (leastBusy.LoadHours > employee.LoadHours)
                    ? employee
                    : leastBusy;
            }
            return leastBusy;
        }

    }
}