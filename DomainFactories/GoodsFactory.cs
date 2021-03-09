using System;
using Domain.GoodsDomain;
using Types;

namespace DomainFactories
{
    public class GoodsFactory
    {
        public GoodsModel GetGoods(GoodsType type)
        { 
            switch (type)
            {
                case GoodsType.Electronics:
                    return (GoodsModel) new ElectronicsModel();
                case GoodsType.Food:
                    return new FoodModel();
                case GoodsType.Furniture :
                    return new FurnitureModel();
                default:    
                    throw new Exception();
            }
        }
    }
}