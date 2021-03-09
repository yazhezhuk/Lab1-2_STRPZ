using Domain.WarehouseDomain;
using Entities;

namespace Mappers
{
    public static class WarehouseMapper
    {
        public static WarehouseEntity ToEntity(this WarehouseModel warehouse)
        {
            return new WarehouseEntity
            {
                RelativeDistance = warehouse.Distance,
                CompanyName = warehouse.Name
            };
        }

        public static WarehouseModel ToModel(this WarehouseEntity warehouse)
        {
            return new WarehouseModel
            {
                Distance = warehouse.RelativeDistance,
                Name = warehouse.CompanyName
            };
        }
    }
}