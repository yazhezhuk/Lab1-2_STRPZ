using DAL;
using Domain.OrderDomain;
using Entities;

namespace Mappers
{
    public class OrderMapper
    {
        public OrderEntity ToEntity(OrderModel order)
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

        public OrderModel ToModel(OrderEntity order)
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