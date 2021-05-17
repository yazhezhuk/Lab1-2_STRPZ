using EfRepository;
using EfRepository.Abstractions;
using Entities;

namespace DAL.UnitOfWork
{
public interface IUnitOfWork
    { 
	    ShopContext Context { get; set; }
        IRepository<GoodsEntity> Goods { get; set; }
        IRepository<EmployeeEntity> Employees { get; set; }
        IRepository<WarehouseEntity> Warehouses { get; set; }
        IRepository<OrderEntity> Orders { get; set; }
        IRepository<OrderItemEntity> OrderInfos { get; set; }

        void CommitChanges();
    }
}