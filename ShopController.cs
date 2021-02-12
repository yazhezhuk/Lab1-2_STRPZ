namespace Lab1Components
{
    public class ShopController
    {
        private ShopInterface ShopInterface { get; set; }
        private DataRepository DataRepository { get; set; }

        public ShopController(ShopInterface shopInterface, DataRepository repository)
        {
            ShopInterface = shopInterface;
            DataRepository = repository;
        }

        public void 
    }
}