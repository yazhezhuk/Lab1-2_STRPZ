
namespace Lab1Components
{
    public class ApplicationContext 
    {
        public IRepository<Goods> Goods { get; set; }
        public IRepository<Manager> Managers { get; set; }
        public IRepository<Driver> Drivers{ get; set; }
        public IRepository<Warehouse> Warehouses{ get; set; }
        public IRepository<Order> Order{ get; set; }

        public ApplicationContext()
        {
            Goods = new GenericRepository<Goods>();
            Managers = new GenericRepository<Manager>();
            Drivers = new GenericRepository<Driver>();
            Warehouses = new GenericRepository<Warehouse>();
            Order = new GenericRepository<Order>();
        }

    }
}