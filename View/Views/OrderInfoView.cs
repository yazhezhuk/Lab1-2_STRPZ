using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Domain.GoodsDomain;
using Domain.WarehouseDomain;
using View.Abstractions;
using View.Abstractions.ViewAbstractions;

namespace View.Views
{
    public partial class OrderInfoView : UserControl, IOrderInfoUserControl
    {
        private IMainView ParentView { get; set; }

        public OrderInfoView(IMainView parentView)
        {
            InitializeComponent();
            ParentView = parentView;
            Show();
        }


        public void UpdateChanges()
        {
            Refresh();
        }

        public WarehouseModel GetSelectedWarehouse()
        {
            return ParentView.SelectedWarehouse;
        }

        public List<GoodsModel> GetSelectedGoods()
        {
            return ParentView.SelectedGoods;
        }

        public void ShowAllGoods(List<GoodsModel> goods)
        {
            var formattedGoods = goods
                .Select(item =>
                    "Name: " + item.Name +
                    "Price: " + item.Price +
                    "Type: " + item.Type)
                .ToArray();
            selectedGoodsLbx.Items.AddRange(formattedGoods);
        }

        public void ShowWarehouse(WarehouseModel warehouse)
        {
            selectedWarehouseTbx.Lines[0] += $"Name: {warehouse.Name}";
            selectedWarehouseTbx.Lines[1] += $"Distance: {warehouse.Distance}";
        }
    }
}