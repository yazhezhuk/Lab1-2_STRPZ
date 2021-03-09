using System;
using System.Collections.Generic;
using DAL.Repositories.Abstractions;
using Entities;

namespace DAL.Repositories
{
    public class GoodsRepository : IGoodsRepository
    {
        private InMemoryDataStub DataStorage { get; } = InMemoryDataStub.Instance;

        public void Delete(int id)
        {
            var toDelete = DataStorage.GoodsData
                .Find(goods => goods.Id == id);
            DataStorage.GoodsData.Remove(toDelete);
        }

        public List<GoodsEntity> GetAll(Predicate<GoodsEntity> filter = null)
        {
            return filter != null
                ? DataStorage.GoodsData.FindAll(filter)
                : DataStorage.GoodsData;
        }

        public GoodsEntity GetById(int id)
        {
            return DataStorage.GoodsData.Find(goods => goods.Id == id);
        }

        public void Add(GoodsEntity obj)
        {
            DataStorage.GoodsData.Add(obj);
        }

        public void Update(GoodsEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}