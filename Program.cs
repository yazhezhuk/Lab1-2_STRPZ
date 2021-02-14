using System;

namespace Lab1Components
{
  class Program
  {
    static void Main(string[] args)
    {
      ShopController shopContorller = new ShopController(new DataRepository());
      shopContorller.InitShop();

    }
  }
}

