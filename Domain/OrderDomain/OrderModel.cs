using System;
using System.Collections.Generic;
using Domain.EmployeesDomain;
using Domain.GoodsDomain;
using Domain.WarehouseDomain;

namespace Domain.OrderDomain
{
    public class OrderModel
    {
        public int WarehouseId { get; set; }
        

        public int ManagerId { get; set; }
        public int DriverId { get; set; }

        public int RelativeDistance { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public TimeSpan EstimateProcessTime { get; set; }

        public int TotalCost { get; set; }

        public bool Completed { get; set; } = false;

        public List<GoodsModel> Goods { get; set; }
    }
}