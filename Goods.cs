using System;

namespace Lab1Components
{
    public enum GoodsType 
    {
        Food,
        Electronics,
        Furniture
    }
    public class Goods : ISaveableEntity
    {
        public int Id { get; set; }

        public GoodsType Type { get; set; }
        public int Price { get; set; }

        public Goods(GoodsType type, int price)
        {
            Type = type;
            Price = price;
        }

        public double ProcessTime
        {
            get
            {
                switch (Type)
                {
                    case GoodsType.Food:
                        return 0.1;
                    case GoodsType.Electronics:
                        return 0.2;
                    case GoodsType.Furniture:
                        return 0.5;
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }
        }
    }
}