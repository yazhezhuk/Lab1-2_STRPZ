using System;
using Types;

namespace Domain.GoodsDomain
{
    public abstract class GoodsModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }

        public abstract GoodsType Type { get; }
        public abstract TimeSpan ProcessTime { get; }
    }
}