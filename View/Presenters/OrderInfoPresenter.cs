using System;
using System.Windows.Forms;
using Services.Abstractions;
using Services.Services;
using View.Abstractions;
using View.Abstractions.PresentersAbstractions;
using View.Abstractions.ViewAbstractions;

namespace View.Presenters
{
    public class OrderInfoPresenter : IOrderInfoPresenter
    {
        private IOrderService OrderService { get; set; }
        private GoodsService GoodsService { get; set; }
        private WarehouseService WarehouseService { get; set; }

        private IOrderInfoUserControl View { get; set; }

        public OrderInfoPresenter(
            IOrderInfoUserControl view,
            IOrderService orderService,
            GoodsService goodsService,
            WarehouseService warehouseService
        )
        {
            View = view;
            OrderService = orderService;
            GoodsService = goodsService;
            WarehouseService = warehouseService;
        }

        public void GetOrderProcessTimeBtnClicked(object sender, EventArgs args)
        {
        }

        public void LoadData(object sender, EventArgs args)
        {
            View.ShowAllGoods(View.GetSelectedGoods());
            View.ShowWarehouse(View.GetSelectedWarehouse());
            View.UpdateChanges();
        }

        public void SubscribeOnViewEvents()
        {
            throw new NotImplementedException();
        }
    }
}