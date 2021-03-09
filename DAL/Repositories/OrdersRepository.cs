using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repositories.Abstractions;
using Entities;

namespace DAL.Repositories
{
    public class OrdersRepository : IOrderRepository
    {
        private InMemoryDataStub DataStorage { get; } = InMemoryDataStub.Instance;

        public void Delete(int id)
        {
            var toDelete = DataStorage.OrdersData
                .Find(order => order.Id == id);
            DataStorage.OrdersData.Remove(toDelete);
        }

        public List<OrderEntity> GetAll(Predicate<OrderEntity> filter = null)
        {
            return filter != null
                ? DataStorage.OrdersData.FindAll(filter)
                : DataStorage.OrdersData;
        }

        public OrderEntity GetById(int id)
        {
            return DataStorage.OrdersData.Find(order => order.Id == id);
        }

        public void Add(OrderEntity obj)
        {
            DataStorage.OrdersData.Add(obj);
        }

        public void Update(OrderEntity obj)
        {
            throw new NotImplementedException();
        }

        public List<GoodsEntity> GetOrderGoods(int id)
        {
            return DataStorage.OrderItemsData
                .FindAll(ord => ord.Id == id)
                .Select(orderItem => orderItem.GoodsId)
                .Select(goodsId => DataStorage.GoodsData
                    .Find(goods => goods.Id == goodsId))
                .ToList();
        }
    }
}