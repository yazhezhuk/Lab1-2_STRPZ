using Domain.WarehouseDomain;
using Entities;

namespace Mappers
{
    public class WarehouseMapper
    {
        public WarehouseEntity ToEntity(WarehouseModel warehouse)
        {
            return new WarehouseEntity
            {
                RelativeDistance = warehouse.Distance,
                CompanyName = warehouse.Name
            };
        }

        public WarehouseModel ToModel(WarehouseEntity warehouse)
        {
            return new WarehouseModel
            {
                Distance = warehouse.RelativeDistance,
                Name = warehouse.CompanyName
            };
        }
    }
}