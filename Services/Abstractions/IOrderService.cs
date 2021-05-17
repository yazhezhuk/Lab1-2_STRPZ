using System.Collections.Generic;
using Domain.GoodsDomain;
using Domain.OrderDomain;
using Domain.WarehouseDomain;

namespace Services.Abstractions
{
    public interface IOrderService : IService<OrderModel>
    {
        OrderModel MakeOrder();
        void ProcessOrder(OrderModel order);

        OrderModel? GetPendingOrder();

        void Clear();
    }
}