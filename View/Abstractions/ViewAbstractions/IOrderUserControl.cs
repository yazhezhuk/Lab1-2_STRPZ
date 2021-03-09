using System.Collections.Generic;
using Domain.GoodsDomain;

namespace View.Abstractions.ViewAbstractions
{
    public interface IOrderUserControl
    {
        void UpdateChanges();
        void ShowAllGoods(List<GoodsModel> goods);
    }
}