using Lab1Components.DAL.Entities;
using System;

namespace Lab1Components.Model.ModelEntities
{
    public class ElectronicsModel : GoodsModel
    {
        public override GoodsType Type
        {
            get => GoodsType.Electronics;
        }

        public override TimeSpan ProcessTime
        {
            get => new TimeSpan(1, 0, 0);
        }
    }
}