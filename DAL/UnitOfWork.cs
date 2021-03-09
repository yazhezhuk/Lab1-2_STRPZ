using DAL.Repositories;
using DAL.Repositories.Abstractions;

namespace DAL
{
    public class UnitOfWork
    {
        public IGoodsRepository Goods { get; set; }
        public IEmployeeRepository Employees { get; set; }
        public IWarehouseRepository Warehouses { get; set; }
        public IOrderRepository Order { get; set; }
        public IOrderItemRepository OrderInfos { get; set; }

        public UnitOfWork()
        {
            Goods = new GoodsRepository();
            Employees = new EmployeesRepository();
            Warehouses = new WarehouseRepository();
            Order = new OrdersRepository();
            OrderInfos = new OrderItemsRepository();
        }
    }
}