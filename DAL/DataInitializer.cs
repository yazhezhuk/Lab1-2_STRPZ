using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Entities;
using Types;

namespace DAL
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var goods = new List<GoodsEntity>
            {
                new() { Name = "Apples", Price = 100, Type = GoodsType.Food },
                new() { Name = "Phone", Price = 5000, Type = GoodsType.Electronics },
                new() { Name = "Table", Price = 1000, Type = GoodsType.Furniture }
            };
            goods.ForEach(item => context.GoodsData.AddOrUpdate(item));
            context.SaveChanges();
            
            
            var warehouses = new List<WarehouseEntity>
            {
                new() { CompanyName = "First", RelativeDistance = 100 },
                new() { CompanyName = "Second", RelativeDistance = 200 },
                new() { CompanyName = "Third", RelativeDistance = 500 },
                new() { CompanyName = "Fourth", RelativeDistance = 350 },
                new() { CompanyName = "Fifth", RelativeDistance = 1000 }
            };
            warehouses.ForEach(item => context.WarehousesData.AddOrUpdate(item));
            context.SaveChanges();

            var employees = new List<EmployeeEntity>
            {
                new() {Firstname = "anton", Lastname = "ton", Age = 21, Speciality = Speciality.Driver},
                new() {Firstname = "satra", Lastname = "nadgob", Age = 22, Speciality = Speciality.Manager}
            };
            employees.ForEach(item => context.EmployeesData.AddOrUpdate(item));
            context.SaveChanges();
        }
    }
}