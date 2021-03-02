using Lab1Components.DAL.Entities;
using System;

namespace Lab1Components.Model.ModelEntities
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