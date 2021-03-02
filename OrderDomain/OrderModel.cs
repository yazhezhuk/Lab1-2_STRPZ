using Lab1Components.Model.ModelEntities;
using System;
using System.Collections.Generic;

namespace Lab1Components.BLL.ModelEntities
{
    public class OrderModel
    {
        public int WarehouseId { get; set; }
        public WarehouseModel Warehouse { get; set; }
        public int ManagerId { get; set; }
        public ManagerModel Manager { get; set; }
        public int DriverId { get; set; }
        public DriverModel Driver { get; set; }

        public DateTime TimeOfCreation { get; set; }
        public TimeSpan EstimateProcessTime { get; set; }
        public int TotalCost { get; set; }

        public bool Completed { get; set; } = false;

        public List<EmployeeModel> Employees { get; set; }
        public List<GoodsModel> Goods { get; set; }
    }
}