using System;
using System.Collections.ObjectModel;

namespace Entities
{
    public class OrderEntity : ISaveableEntity
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }
        public int ManagerId { get; set; }
        public int DriverId { get; set; }

        public DateTime TimeOfCreation { get; set; }
        public TimeSpan EstimateProcessTime { get; set; }

        public bool Completed { get; set; }

        public virtual Collection<EmployeeEntity> Employees { get; }
        public virtual Collection<GoodsEntity> Goods { get; }
    }
}