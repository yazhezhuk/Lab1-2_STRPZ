using Domain.GoodsDomain;
using DomainFactories;
using Entities;

namespace Mappers
{
    public class GoodsMapper
    {
        public GoodsEntity ToEntity( GoodsModel goods)
        {
            return new GoodsEntity
            {
                Id = goods.Id,
                Price = goods.Price,
                Name = goods.Name,
                Type = goods.Type
            };
        }

        public GoodsModel ToModel(GoodsEntity goods)
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