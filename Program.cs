namespace Lab1Components
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ShopController shopContorller = new ShopController(new DataRepository());
            shopContorller.InitShop();
        }
    }
}