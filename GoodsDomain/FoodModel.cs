using Lab1Components.DAL.Entities;
using System;

namespace Lab1Components.Model.ModelEntities
{
    public class FoodModel : GoodsModel
    {
        public override GoodsType Type
        {
            get => GoodsType.Food;
        }

        public override TimeSpan ProcessTime
        {
            get => new TimeSpan(0, 20, 0);
        }
    }
}