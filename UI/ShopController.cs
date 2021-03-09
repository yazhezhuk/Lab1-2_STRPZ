using System;
using System.Collections.Generic;
using DAL;
using Domain.EmployeesDomain;
using Domain.GoodsDomain;
using Domain.OrderDomain;
using Domain.WarehouseDomain;
using Services.Abstractions;
using Services.Services;


namespace UI
{
    public class ShopController : IController
    {
        public ShopConsoleView View { get; set; }
        private UnitOfWork Context { get; set; }
        private IService<GoodsModel> GoodsService { get; set; }
        private IService<WarehouseModel> WarehouseService { get; set; }
        private IService<EmployeeModel> StaffService { get; set; }
        private IService<OrderModel> OrderService { get; set; }

        public ShopController(ShopConsoleView view)
        {
            Context = new UnitOfWork();
            GoodsService = new GoodsService(Context);
            WarehouseService = new WarehouseService(Context);
            StaffService = new StaffService(Context);
            OrderService = new OrderService(Context);

            View = view;
        }

        public void ProcessOrder()
        {
            var order = new OrderModel
            {
                Goods = View.SelectedGoods,
                WarehouseId = View.SelectedWarehouse.Id,
                RelativeDistance = View.SelectedWarehouse.Distance,
                TimeOfCreation = DateTime.Now,
                Completed = false,
            };

            OrderService.Add(order);
            View.DisplayOrder(order);
        }

        public void SelectGoods(int selectionIndex)
        {
            var selectedGoods = GoodsService.Get(selectionIndex);
            View.SelectedGoods.Add(selectedGoods);
        }

        public void SelectWarehouse(int selectionIndex)
        {
            var selectedWarehouse = WarehouseService.Get(selectionIndex);
            View.SelectedWarehouse = selectedWarehouse;
        }

        public List<GoodsModel> GetAllGoods()
        {
            return GoodsService.GetAll();
        }

        public List<WarehouseModel> GetAllWarehouses()
        {
            return WarehouseService.GetAll();
        }
    }
}