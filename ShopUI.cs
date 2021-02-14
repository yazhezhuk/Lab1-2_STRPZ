using System;
using System.Collections.Generic;

namespace Lab1Components
{
  public class ShopUserInterface
  {
    public MenuState State { get; set; }

    public ShopController Controller { get; set; }

    public List<string> MainMenuOptions { get; set; }
    public List<string> GoodsMenuOptions { get; set; }
    public List<string> WarehouseMenuOptions { get; set; }

    public ShopUserInterface(ShopController controller)
    {
      Controller = controller;
      MainMenuOptions = new List<string>(4);
      MainMenuOptions.Add("1)Goods menu.");
      MainMenuOptions.Add("2)Warehouse menu.");
      MainMenuOptions.Add("3)Order menu.");
      MainMenuOptions.Add("4)Exit.");

      GoodsMenuOptions = new List<string>(3);
      GoodsMenuOptions.Add("1)View goods.");
      GoodsMenuOptions.Add("2)Order goods.");
      GoodsMenuOptions.Add("3)View already ordered.");
      GoodsMenuOptions.Add("4)Return to previous menu.");

      WarehouseMenuOptions = new List<string>(3);
      WarehouseMenuOptions.Add("1)View warehouses.");
      WarehouseMenuOptions.Add("2)Select warehouse.");
      WarehouseMenuOptions.Add("2)Return to previous menu.");
    }
    public void OperationFailed()
    {
      Console.WriteLine("Operation failed, try again.");
    }
    public void OperationSuccessful()
    {
      Console.WriteLine("Operation was succesful!");
    }

    public void DisplayGoods(Goods goods)
    {
      Console.WriteLine($"{goods.Id}) Type:{goods.Type} , price: {goods.Price}");
    }
    public void Start(string username)
    {
      Console.WriteLine($"Welcome to our shop, {username} \n");
      while (true)
      {
        Console.WriteLine(5);
        ConsoleKeyInfo info = Console.ReadKey();
        int key = Convert.ToInt32(info.Key);
        Console.WriteLine(5);
        State.ButtonPressed(key);
      }
    }

    public void Exit()
    {
    }

    public void PrintMenuItems(List<string> items)
    {
      items.ForEach(Console.WriteLine);
    }

  }
}