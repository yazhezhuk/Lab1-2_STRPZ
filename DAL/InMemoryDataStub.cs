using System.Collections.Generic;
using System.Linq;
using Entities;
using Types;

namespace DAL
{
    public class InMemoryDataStub
    {
        public List<GoodsEntity> GoodsData { get; set; }
        public List<OrderEntity> OrdersData { get; set; }
        public List<OrderItemEntity> OrderItemsData { get; set; }
        public List<WarehouseEntity> WarehousesData { get; set; }
        public  List<EmployeeEntity> EmployeesData { get; set; }

        private static InMemoryDataStub _instance = new InMemoryDataStub();

        public static InMemoryDataStub Instance
        {
            get => _instance;
        }

        public int GoodsId
        {
            get => GoodsData.Last().Id + 1;
        }

        public int WarehouseId
        {
            get => WarehousesData.Last().Id + 1;
        }

        public int EmployeeId
        {
            get => EmployeesData.Last().Id + 1;
        }

        public int OrderId
        {
            get => (OrdersData.LastOrDefault()?.Id + 1 ?? 0);
        }

        public int OrderItemId
        {
            get => (OrderItemsData.LastOrDefault()?.Id + 1 ?? 0);
        }

        private InMemoryDataStub()
        {
            EmployeesData = new List<EmployeeEntity>
            {
                new EmployeeEntity
                    {Id = 0, Age = 21, Firstname = "Anton", Lastname = "Borisov", Speciality = Speciality.Driver},
                new EmployeeEntity
                    {Id = 1, Age = 23, Firstname = "Evgeniy", Lastname = "Bukur", Speciality = Speciality.Manager}
            };
            GoodsData = new List<GoodsEntity>
            {
                new GoodsEntity {Id = 0, Price = 100, Name = "Apple", Type = GoodsType.Food},
                new GoodsEntity {Id = 1, Price = 2000, Name = "Somsung TV", Type = GoodsType.Electronics}
            };
            WarehousesData = new List<WarehouseEntity>
            {
                new WarehouseEntity {Id = 0, RelativeDistance = 200, CompanyName = "First"},
                new WarehouseEntity {Id = 1, RelativeDistance = 453, CompanyName = "Second"},
                new WarehouseEntity {Id = 2, RelativeDistance = 180, CompanyName = "Second"},
                new WarehouseEntity {Id = 3, RelativeDistance = 500, CompanyName = "Third"},
                new WarehouseEntity {Id = 4, RelativeDistance = 750, CompanyName = "Fourth"}
            };
            OrdersData = new List<OrderEntity>();
            OrderItemsData = new List<OrderItemEntity>();
        }
    }
}