﻿using Domain.GoodsDomain;
using DomainFactories;
using Entities;

namespace Mappers
{
    public class GoodsMapper
    {
        public GoodsEntity ToEntity(GoodsModel goods) => new GoodsEntity
        {
                Id = goods.Id,
                Price = goods.Price,
                Name = goods.Name
        };

        public GoodsModel ToModel(GoodsEntity goods)
        { 
	        GoodsFactory factory = new GoodsFactory();
	        
	        GoodsModel convertedGoods = factory.GetGoods(goods.GoodsType.Type);
	            convertedGoods.Id = goods.Id;
                 convertedGoods.Name = goods.Name;
                 convertedGoods.Price = goods.Price;
             
             return convertedGoods;
        }
    }
}