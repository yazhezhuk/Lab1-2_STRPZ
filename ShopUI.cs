using System;
using System.Collections.Generic;

namespace Lab1Components
{
    public class ShopUserInterface
    {
        public IMenuState State { get; set; }

        private ShopController Controller { get; set; }

        private List<string> MainMenuOptions { get; set; }
        private List<string> GoodsMenuOptions { get; set; }
        private List<string> WarehouseMenuOptions { get; set; }

        public ShopUserInterface(ShopController controller)
        {
            Controller = controller;
            MainMenuOptions = new List<string>
            {
                [0] = "1)Goods menu.",
                [1] = "2)Warehouse menu.",
                [2] = "3)Order menu.",
                [3] = "4)Exit."
            };

            GoodsMenuOptions = new List<string>
            {
                [0] = "1)View goods.",
                [1] = "2)Order goods.",
                [2] = "3)Show already ordered.",
                [3] = "4)Return."
            };

            WarehouseMenuOptions = new List<string>
            {
                [0] = "1)View warehouses.",
                [1] = "2)Select warehouse.",
                [2] = "3)Return."
            };
        }

        public void Start(string username)
        {
            Console.WriteLine($"Welcome to our shop, {username} \n");

        }

        private void MainMenuHandler()
        {
            while (true)
            {
                Console.WriteLine($"----------Main menu-----------, \n");
                MainMenuOptions.ForEach(Console.WriteLine);

                var choice = Console.ReadKey().Key;
                switch (choice)
                {
                    case ConsoleKey.D1:
                        
                        break;

                }
            }
        }

        private void GoodsMenuHandler()
        {
            while (true)
            {
                Console.WriteLine($"----------Goods menu-----------, \n");
                GoodsMenuOptions.ForEach(Console.WriteLine);

                var choice = Console.ReadKey().Key;
                switch (choice)
                {
                    case ConsoleKey.D1:

                        break;

                }
            }
        }


    }
}