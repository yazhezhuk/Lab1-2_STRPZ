using System;

namespace Lab1Components
{
    public enum GoodsType 
    {
        Food,
        Electronics,
        Furniture
    }
    public class Goods:IPrintable
    {
        public GoodsType Type { get; set; }
        public int Price { get; set; }

        public int ProcessTime
        {
            get
            {
                switch (Type)
                {
                    case GoodsType.Food:
                        return 1;
                    case GoodsType.Electronics:
                        return 2;
                    case GoodsType.Furniture:
                        return 3;
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Type}, Price: {Price}");
        }

    }
}