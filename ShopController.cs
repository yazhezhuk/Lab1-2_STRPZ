using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Lab1Components
{
    public class ShopController
    {
        private ShopConsoleView View { get; set; }
        private ShopModel ShopModel { get; set; }

        public ShopController(ShopModel model,ShopConsoleView view)
        {
            View = view;
            ShopModel = model;
        }

        public List<Goods> GetAllGoods() => ShopModel.Context.Goods.GetAll();

        public List<Warehouse> GetAllWarehouses() => ShopModel.Context.Warehouses.GetAll();

        public void ProcessOrder()
        {
            if (GetSelectedWarehouse() == null || !GetSelectedGoods().Any())
                return;
            var order = ShopModel.FormOrder();
            ShopModel.ProcessOrder(order);

            View.DisplayOrder(order);
        }

        public void SelectGoods(int selectedIndex)
        {
            if (GetAllGoods().Count >= selectedIndex)
            {
                var item = GetAllGoods()[selectedIndex];
                ShopModel.SelectGoods(item);
                NotifyAboutSuccess();
                return;
            }
            NotifyAboutError();
        }

        public void SelectWarehouse(int selectedIndex)
        {
            if (GetAllWarehouses().Count >= selectedIndex)
            {
                ShopModel.SelectWarehouse(GetAllWarehouses()[selectedIndex]);
                NotifyAboutSuccess();
                return;
            }
            NotifyAboutError();
        }

        public Warehouse GetSelectedWarehouse()
        {
            return GetAllWarehouses()
              .Find(warehouse => warehouse.Selected == true);
        }

        public List<Goods> GetSelectedGoods()
        {
            return ShopModel.GetSelectedGoods();
        }

        public void NotifyAboutSuccess()
        {
            View.OperationSuccessful();
        }

        public void NotifyAboutError()
        {
            View.OperationFailed();
        }
    }
}