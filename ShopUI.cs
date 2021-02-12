using System;

namespace Lab1Components
{
    public class ShopInterface
    {
        private ShopController Controller { get; set; }
        public ShopInterface(ShopController controller)
        {
            Controller = controller;
        }

        public void Init(string username)
        {
            Console.WriteLine($"Welcome to our shop, {username} \n");
            
            

        }


    }
}