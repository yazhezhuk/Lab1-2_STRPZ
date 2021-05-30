using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Entities;
using Types;

namespace EfRepository
{
    public class DataInitializer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
	        var employeeTypes = new List<EmployeeSpecialityEntity>
	        {
		        new() { Speciality = Speciality.Driver },
		        new() { Speciality = Speciality.Manager }
	        };
	        employeeTypes.ForEach(item => context.EmployeeSpecialities.AddOrUpdate(item));
	        context.SaveChanges();
	        
	        var goodsTypes = new List<GoodsTypeEntity>
	        {
		        new() { Type = GoodsType.Food },
		        new() { Type = GoodsType.Electronics },
		        new() { Type = GoodsType.Furniture }
	        };
	        goodsTypes.ForEach(item => context.GoodsTypes.AddOrUpdate(item));
	        context.SaveChanges();
	        
            var goods = new List<GoodsEntity>
            {
                new() { Name = "Apples", Price = 100, GoodsTypeId = 1},
                new() { Name = "Phone", Price = 5000, GoodsTypeId = 2},
                new() { Name = "Table", Price = 1000, GoodsTypeId = 3}
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
                new() { Firstname = "Takumi", Lastname = "Fujiwara", Age = 21,EmployeeSpecialityId = 1 },
                new() { Firstname = "satra", Lastname = "saradip", Age = 22,EmployeeSpecialityId = 2 },
                new() { Firstname = "Kaneki", Lastname = "Ken", Age = 20,EmployeeSpecialityId = 1 },
                new() { Firstname = "Billy", Lastname = "Herrington", Age = 30,EmployeeSpecialityId = 2 }
            };
            employees.ForEach(item => context.EmployeesData.AddOrUpdate(item));
            context.SaveChanges();

            
        }
    }
}