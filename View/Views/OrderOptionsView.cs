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
    public class OrderOptionsMenuView : UserControl, IOrderOptionsMenuView
    {
        private Label goodsLbl;
        private CheckedListBox goodsClb;
        private Button processOrderBtn;
        private Label warehousesLbl;
        private CheckedListBox warehousesClb;
        private Button refreshBtn;
        private Button addGoodsBtn;
        private Button warehouseSelectionBtn;
        private MainMenuView ParentView { get; set; }

        public event EventHandler DataChanged;

        public OrderOptionsMenuView(MainMenuView parentView)
        {
            InitializeComponent();
            ParentView = parentView;
        }

        public void UpdateChanges()
        {
            Refresh();
        }

        public void ShowAllWarehouses(List<WarehouseModel> warehouse)
        {
            warehousesClb.DataSource = warehouse;
        }

        public void ShowAllGoods(List<GoodsModel> goods)
        {
            goodsClb.DataSource = goods;
        }

        public void SetSelectedGoods(List<GoodsModel> goods)
        {
            ParentView.SelectedGoods.AddRange(goods);
        }

        public void SetSelectedWarehouse(WarehouseModel warehouse)
        {
            ParentView.SelectedWarehouse = warehouse;
        }

        private void RefreshBtnClick(object sender, EventArgs args)
        {
            DataChanged.Invoke(this, new EventArgs());
        }

        private void AddGoodsBtnClick(object sender, EventArgs args)
        {
            var selectedGoods = new List<GoodsModel>(goodsClb.SelectedItems.Cast<GoodsModel>());
            SetSelectedGoods(selectedGoods);
        }

        private void AddWarehouseBtnClick(object sender, EventArgs args)
        {
            var selectedWarehouse = goodsClb.SelectedItem as WarehouseModel;
            SetSelectedWarehouse(selectedWarehouse);
        }

        private void InitializeComponent()
        {
            goodsLbl = new Label();
            goodsClb = new CheckedListBox();
            processOrderBtn = new Button();
            warehousesLbl = new Label();
            warehousesClb = new CheckedListBox();
            refreshBtn = new Button();
            addGoodsBtn = new Button();
            warehouseSelectionBtn = new Button();
            SuspendLayout();
            // 
            // goodsLbl
            // 
            goodsLbl.AutoSize = true;
            goodsLbl.Location = new System.Drawing.Point(13, 28);
            goodsLbl.Margin = new Padding(4, 0, 4, 0);
            goodsLbl.Name = "goodsLbl";
            goodsLbl.Size = new System.Drawing.Size(59, 13);
            goodsLbl.TabIndex = 12;
            goodsLbl.Text = "Our goods:";
            // 
            // goodsClb
            // 
            goodsClb.FormattingEnabled = true;
            goodsClb.Location = new System.Drawing.Point(16, 44);
            goodsClb.Name = "goodsClb";
            goodsClb.Size = new System.Drawing.Size(120, 79);
            goodsClb.TabIndex = 16;
            // 
            // processOrderBtn
            // 
            processOrderBtn.Location = new System.Drawing.Point(135, 341);
            processOrderBtn.Name = "processOrderBtn";
            processOrderBtn.Size = new System.Drawing.Size(103, 23);
            processOrderBtn.TabIndex = 17;
            processOrderBtn.Text = "Make order";
            processOrderBtn.UseVisualStyleBackColor = true;
            // 
            // warehousesLbl
            // 
            warehousesLbl.AutoSize = true;
            warehousesLbl.Location = new System.Drawing.Point(13, 172);
            warehousesLbl.Margin = new Padding(4, 0, 4, 0);
            warehousesLbl.Name = "warehousesLbl";
            warehousesLbl.Size = new System.Drawing.Size(139, 13);
            warehousesLbl.TabIndex = 14;
            warehousesLbl.Text = "Choose one of warehouses:";
            // 
            // warehousesClb
            // 
            warehousesClb.FormattingEnabled = true;
            warehousesClb.Location = new System.Drawing.Point(16, 188);
            warehousesClb.Name = "warehousesClb";
            warehousesClb.Size = new System.Drawing.Size(120, 79);
            warehousesClb.TabIndex = 15;
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new System.Drawing.Point(52, 450);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new System.Drawing.Size(75, 23);
            refreshBtn.TabIndex = 18;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            // 
            // addGoodsBtn
            // 
            addGoodsBtn.Location = new System.Drawing.Point(179, 44);
            addGoodsBtn.Margin = new Padding(4);
            addGoodsBtn.Name = "addGoodsBtn";
            addGoodsBtn.Size = new System.Drawing.Size(171, 34);
            addGoodsBtn.TabIndex = 13;
            addGoodsBtn.Text = "Add selected to order";
            addGoodsBtn.UseVisualStyleBackColor = true;
            // 
            // warehouseSelectionBtn
            // 
            warehouseSelectionBtn.Location = new System.Drawing.Point(179, 188);
            warehouseSelectionBtn.Margin = new Padding(4);
            warehouseSelectionBtn.Name = "warehouseSelectionBtn";
            warehouseSelectionBtn.Size = new System.Drawing.Size(171, 34);
            warehouseSelectionBtn.TabIndex = 19;
            warehouseSelectionBtn.Text = "Set order warehouse";
            warehouseSelectionBtn.UseVisualStyleBackColor = true;
            // 
            // orderOptionsMenuView
            // 
            Controls.Add(warehouseSelectionBtn);
            Controls.Add(goodsLbl);
            Controls.Add(goodsClb);
            Controls.Add(processOrderBtn);
            Controls.Add(warehousesLbl);
            Controls.Add(warehousesClb);
            Controls.Add(refreshBtn);
            Controls.Add(addGoodsBtn);
            Name = "orderOptionsMenuView";
            Size = new System.Drawing.Size(770, 394);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}