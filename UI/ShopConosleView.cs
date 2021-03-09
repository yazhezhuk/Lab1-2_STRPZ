using System;
using System.Collections.Generic;
using Domain.GoodsDomain;
using Domain.OrderDomain;
using Domain.WarehouseDomain;
using UI.ViewStates;

namespace UI
{
    public class ShopConsoleView
    {
        public MenuState State { get; set; }

        public ShopController Controller { get; set; }

        public List<GoodsModel> SelectedGoods { get; set; }
        public WarehouseModel SelectedWarehouse { get; set; }

        public List<string> MainMenuOptions { get; set; }
        public List<string> GoodsMenuOptions { get; set; }
        public List<string> WarehouseMenuOptions { get; set; }
        public List<string> OrderMenuOptions { get; set; }

        public ShopConsoleView()
        {
            SelectedGoods = new List<GoodsModel>();
            State = new MainMenuState(this);
            MainMenuOptions = new List<string>(4)
            {
                "1)Goods menu.",
                "2)Warehouse menu.",
                "3)Order menu.",
                "4)Exit."
            };

            GoodsMenuOptions = new List<string>(3)
            {
                "1)View goods.",
                "2)Order goods.",
                "3)View already ordered.",
                "4)Return to previous menu."
            };

            WarehouseMenuOptions = new List<string>(3)
            {
                "1)View warehouses.",
                "2)Select warehouse.",
                "2)Return to previous menu."
            };

            OrderMenuOptions = new List<string>(4)
            {
                "1)Process order.",
                "2)Return to previous menu"
            };
        }

        public void OperationFailed()
        {
            Console.WriteLine("Operation failed, try again.");
        }

        public void OperationSuccessful()
        {
            Console.WriteLine("Operation was successful!");
        }

        public void DisplayOrder(OrderModel order)
        {
            Console.WriteLine($"Estimate preparation and delivery time - {order.EstimateProcessTime.Days } d.{ order.EstimateProcessTime.Hours} h. {order.EstimateProcessTime.Minutes} m. \n" +
                              $"Total price - {order.TotalCost}$ \n");
        }

        public void DisplayGoods(GoodsModel goods)
        {
            Console.WriteLine($"Type - {goods.Type} \n" +
                              $"Price - {goods.Price} \n");
        }

        public void Start(string username)
        {
            Console.WriteLine($"Welcome to our shop, {username} \n");
            while (true)
            {
                State.PrintMenuOptions();
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();
                State.ButtonPressed(key);
            }
        }

        public void DisplayWarehouse(WarehouseModel warehouse)
        {
            Console.WriteLine($"Name - {warehouse.Name} \n" +
                              $"Distance i- {warehouse.Distance} \n");
        }

        public void Exit()
        {
            System.Environment.Exit(1);
        }

        public void PrintMenuItems(List<string> items, string menuName)
        {
            Console.WriteLine($"----------{menuName} Menu-----------");
            items.ForEach(Console.WriteLine);
        }
    }
}