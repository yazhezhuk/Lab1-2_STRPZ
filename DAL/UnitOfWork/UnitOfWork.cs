using EfRepository;
using EfRepository.Abstractions;
using EfRepository.Repositories;
using Entities;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

	    public ShopContext Context { get; set; }


	    public UnitOfWork(ShopContext context)
        {
            Context = context;
            Goods = new GenericRepository<GoodsEntity>(context,context.GoodsData);
            Employees = new GenericRepository<EmployeeEntity>(context,context.EmployeesData);
            Warehouses = new GenericRepository<WarehouseEntity>(context,context.WarehousesData);
            Orders = new GenericRepository<OrderEntity>(context,context.OrdersData);
            EmployeeSpecialities = new GenericRepository<EmployeeSpecialityEntity>(context,context.EmployeeSpecialities);
            OrderInfos = new GenericRepository<OrderItemEntity>(context,context.OrderItemsData);
            GoodsTypes = new GenericRepository<GoodsTypeEntity>(context, context.GoodsTypes);
        }

        public IRepository<GoodsEntity> Goods { get; set; }
        public IRepository<EmployeeEntity> Employees { get; set; }
        public IRepository<WarehouseEntity> Warehouses { get; set; }
        public IRepository<OrderEntity> Orders { get; set; }
        public IRepository<OrderItemEntity> OrderInfos { get; set; }
        public IRepository<EmployeeSpecialityEntity> EmployeeSpecialities { get; set; }
        public IRepository<GoodsTypeEntity> GoodsTypes { get; set; }
        


        public void CommitChanges() =>
		Context.SaveChanges();
    }
}