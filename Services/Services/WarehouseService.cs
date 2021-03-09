using System.Collections.Generic;
using System.Linq;
using DAL;
using Domain.WarehouseDomain;
using Mappers;
using Services.Abstractions;

namespace Services.Services
{
    public class WarehouseService : IService<WarehouseModel>
    {
        private UnitOfWork Context { get; set; }
        private WarehouseMapper WarehouseMapper { get; }
        
        
        public WarehouseService(UnitOfWork context)
        {
            Context = context;
            WarehouseMapper = new WarehouseMapper();
        }

        public void Add(WarehouseModel item)
        {
            Context.Warehouses.Add(WarehouseMapper.ToEntity(item));
        }

        public WarehouseModel Get(int id)
        {
            return WarehouseMapper.ToModel(Context.Warehouses.GetById(id));
        }

        public List<WarehouseModel> GetAll()
        {
            return Context.Warehouses.GetAll()
                .Select(warehouse => WarehouseMapper.ToModel(warehouse))
                .ToList();
        }

        public void Delete(WarehouseModel item)
        {
            Context.Warehouses.Delete(WarehouseMapper.ToEntity(item).Id);
        }
    }
}