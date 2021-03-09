using DAL.Repositories.Abstractions;
using Entities;

namespace DAL
{
    public interface IUnitOfWork
    {
        IRepository<GoodsEntity> Goods { get; set; }
        IRepository<EmployeeEntity> Employees { get; set; }
        IRepository<WarehouseEntity> Warehouses { get; set; }
        IRepository<OrderEntity> Orders { get; set; }
        IRepository<OrderItemEntity> OrderInfos { get; set; }

        void CommitChanges();
    }
}