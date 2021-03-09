using System;
using Types;

namespace Domain.GoodsDomain
{
    public class FurnitureModel : GoodsModel
    {
        public override GoodsType Type
        {
            get => GoodsType.Furniture;
        }

        public override TimeSpan ProcessTime
        {
            get => new TimeSpan(0, 30, 0);
        }
    }
}