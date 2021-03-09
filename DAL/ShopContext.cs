using System.Data.Entity;
using Entities;

namespace DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext():base("ShopDB")
        {
            
        }
        
        public DbSet<GoodsEntity> GoodsData { get; set; }
        public DbSet<EmployeeEntity> EmployeesData { get; set; }
        public DbSet<WarehouseEntity> WarehousesData { get; set; }
        public DbSet<OrderItemEntity> OrderItemsData { get; set; }
        public DbSet<OrderEntity> OrdersData { get; set;  }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //todo some setup stuff
        }
    }
    
}