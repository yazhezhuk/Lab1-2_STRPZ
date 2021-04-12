using System.Data.Entity;
using EfRepository.Abstractions;
using EfRepository.Repositories;
using Entities;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ShopContext Context;
        

        public UnitOfWork(ShopContext context)
        {
            Context = context;
            Goods = new GenericRepository<GoodsEntity>(context.GoodsData);
            Employees = new GenericRepository<EmployeeEntity>(context.EmployeesData);
            Warehouses = new GenericRepository<WarehouseEntity>(context.WarehousesData);
            Orders = new GenericRepository<OrderEntity>(context.OrdersData);
            OrderInfos = new GenericRepository<OrderItemEntity>(context.OrderItemsData);
        }

        public IRepository<GoodsEntity> Goods { get; set; }
        public IRepository<EmployeeEntity> Employees { get; set; }
        public IRepository<WarehouseEntity> Warehouses { get; set; }
        public IRepository<OrderEntity> Orders { get; set; }
        public IRepository<OrderItemEntity> OrderInfos { get; set; }

        public void CommitChanges()
        {
            Context.SaveChanges();
        }
    }
}