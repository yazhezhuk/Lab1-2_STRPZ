using System.Collections.Generic;
using Domain.GoodsDomain;
using Domain.OrderDomain;
using Domain.WarehouseDomain;

namespace Services.Abstractions
{
    public interface IOrderService : IService<OrderModel>
    {
        OrderModel MakeOrder(List<GoodsModel> selectedGoods,WarehouseModel selectedWarehouse);
        void ProcessOrder(OrderModel order);
    }
}