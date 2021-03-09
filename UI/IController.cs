using System.Collections.Generic;
using Domain.GoodsDomain;

namespace UI
{
    public interface IController
    {
        void ProcessOrder();

        void SelectGoods(int selectedIndex);

        void SelectWarehouse(int selectedIndex);

        List<GoodsModel> GetAllGoods();
    }
}