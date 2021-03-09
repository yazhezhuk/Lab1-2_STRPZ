using System.Collections.Generic;
using Domain.GoodsDomain;
using Domain.WarehouseDomain;

namespace View.Abstractions.ViewAbstractions
{
    public interface IOrderInfoUserControl : IOrderUserControl
    {
        void ShowWarehouse(WarehouseModel warehouse);
        WarehouseModel GetSelectedWarehouse();
        List<GoodsModel> GetSelectedGoods();
    }
}