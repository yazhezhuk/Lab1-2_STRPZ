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

        public WarehouseService(UnitOfWork context)
        {
            Context = context;
        }

        public void Add(WarehouseModel item)
        {
            Context.Warehouses.Add(item.ToEntity());
        }

        public WarehouseModel Get(int id)
        {
            return Context.Warehouses.GetById(id).ToModel();
        }

        public List<WarehouseModel> GetAll()
        {
            return Context.Warehouses.GetAll()
                .Select(warehouse => warehouse.ToModel())
                .ToList();
        }

        public void Delete(WarehouseModel item)
        {
            Context.Warehouses.Delete(item.ToEntity().Id);
        }
    }
}