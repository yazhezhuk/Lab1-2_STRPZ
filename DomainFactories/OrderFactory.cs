using System;
using System.Collections.Generic;
using Domain.GoodsDomain;
using Domain.OrderDomain;
using Domain.WarehouseDomain;

namespace DomainFactories
{
    public class OrderFactory
    {
        public OrderModel CreateOrder(WarehouseModel warehouse,
            List<GoodsModel> goods)
        {
            var order = new OrderModel
            {
                Goods = goods,
                RelativeDistance = warehouse.Distance,
                WarehouseId = warehouse.Id,
                TimeOfCreation = DateTime.Now,
            };
            return order;
        }
    }
}