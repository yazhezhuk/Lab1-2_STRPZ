namespace Lab1Components
{
    public class DataRepository
    {
        public IRepository<Goods> Goods { get; }
        public IRepository<Manager> Managers { get; }
        public IRepository<Driver> Drivers { get; }
        public IRepository<Warehouse> Warehouses { get; }

        public DataRepository()
        {
            Goods = new ShopRepository<Goods>();
            Managers = new ShopRepository<Manager>();
            Drivers = new ShopRepository<Driver>();
            Warehouses = new ShopRepository<Warehouse>();
        }
    }
}