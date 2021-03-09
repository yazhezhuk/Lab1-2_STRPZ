using System;
using System.Collections.Generic;
using DAL.Repositories.Abstractions;
using Entities;

namespace DAL.Repositories
{
    public class OrderItemsRepository : IOrderItemRepository
    {
        private InMemoryDataStub DataStorage { get; } = InMemoryDataStub.Instance;

        public void Delete(int id)
        {
            var toDelete = DataStorage.OrderItemsData
                .Find(item => item.Id == id);
            DataStorage.OrderItemsData.Remove(toDelete);
        }

        public List<OrderItemEntity> GetAll(Predicate<OrderItemEntity> filter = null)
        {
            return filter != null
                ? DataStorage.OrderItemsData.FindAll(filter)
                : DataStorage.OrderItemsData;
        }

        public OrderItemEntity GetById(int id)
        {
            return DataStorage.OrderItemsData.Find(items => items.Id == id);
        }

        public void Add(OrderItemEntity obj)
        {
            DataStorage.OrderItemsData.Add(obj);
        }

        public void Update(OrderItemEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}