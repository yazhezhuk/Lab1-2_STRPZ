using System;
using System.Collections.Generic;
using DAL.Repositories.Abstractions;
using Entities;

namespace DAL.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private InMemoryDataStub DataStorage { get; } = InMemoryDataStub.Instance;

        public void Delete(int id)
        {
            var toDelete = DataStorage.WarehousesData
                .Find(warehouse => warehouse.Id == id);
            DataStorage.WarehousesData.Remove(toDelete);
        }

        public List<WarehouseEntity> GetAll(Predicate<WarehouseEntity> filter = null)
        {
            return filter != null
                ? DataStorage.WarehousesData.FindAll(filter)
                : DataStorage.WarehousesData;
        }

        public WarehouseEntity GetById(int id)
        {
            return DataStorage.WarehousesData.Find(warehouse => warehouse.Id == id);
        }

        public void Add(WarehouseEntity obj)
        {
            DataStorage.WarehousesData.Add(obj);
        }

        public void Update(WarehouseEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}