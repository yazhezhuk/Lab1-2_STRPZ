using DAL;
using Domain.OrderDomain;
using Entities;

namespace Mappers
{
    public static class OrderMapper
    {
        public static OrderEntity ToEntity(this OrderModel order)
        {
            return new OrderEntity
            {
                Id = InMemoryDataStub.Instance.OrderId,
                WarehouseId = order.WarehouseId,
                ManagerId = order.ManagerId,
                DriverId = order.DriverId,
                Completed = order.Completed,
                EstimateProcessTime = order.EstimateProcessTime,
                TimeOfCreation = order.TimeOfCreation
            };
        }

        public static OrderModel ToModel(this OrderEntity order)
        {
            return new OrderModel
            {
                WarehouseId = order.WarehouseId,
                ManagerId = order.ManagerId,
                DriverId = order.DriverId,
                Completed = order.Completed,
                EstimateProcessTime = order.EstimateProcessTime,
                TimeOfCreation = order.TimeOfCreation
            };
        }
    }
}