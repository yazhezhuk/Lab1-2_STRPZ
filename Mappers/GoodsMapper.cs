using Domain.GoodsDomain;
using DomainFactories;
using Entities;

namespace Mappers
{
    public static class GoodsMapper
    {
        public static GoodsEntity ToEntity(this GoodsModel goods)
        {
            return new GoodsEntity
            {
                Id = goods.Id,
                Price = goods.Price,
                Name = goods.Name,
                Type = goods.Type
            };
        }

        public static GoodsModel ToModel(this GoodsEntity goods)
        {
            var factory = new GoodsFactory();
            var convertedGoods = factory.GetGoods(goods.Type);
            convertedGoods.Id = goods.Id;
            convertedGoods.Name = goods.Name;
            convertedGoods.Price = goods.Price;

            return convertedGoods;
        }
    }
}