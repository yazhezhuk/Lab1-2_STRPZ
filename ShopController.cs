using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab1Components
{
    public class ShopController
    {
        private ShopUserInterface View { get; set; }
        private DataRepository DataRepository { get; set; }

        public ShopController(DataRepository repository)
        {
            View = new ShopUserInterface(this);
            DataRepository = repository;
        }

        public void InitShop()
        {
            View.State = new MainMenuState(View);
            View.Start("Vitalich");
        }

        public List<Goods> GetAllGoods() => DataRepository.Goods.GetAll();

        public List<Warehouse> GetAllWarehouses() => DataRepository.Warehouses.GetAll();

        public List<Manager> GetAllManagers() => DataRepository.Managers.GetAll();

        public List<Driver> GetAllDrivers() => DataRepository.Drivers.GetAll();

        public List<Order> GetAllOrders() => DataRepository.Orders.GetAll();
        public void SelectGoods(int selectedIndex)
        {
            if (GetAllGoods().Count >= selectedIndex)
            {
                var item = GetAllGoods()[selectedIndex];
                item.Selected = true;
                NotifyAboutSuccess();
                return;
            }
            NotifyAboutError();
        }
        
        public void GetOrderInfo()
        {
            var selectedGoods = GetSelectedGoods();
            var selectedWarehouse = GetSelectedWarehouse();
            if (selectedWarehouse == null || selectedGoods == null)
                return;

            selectedGoods.ForEach(View.DisplayGoods);
            View.DisplayWarehouse(selectedWarehouse);
        }

        public void ProcessOrder()
        { 
            var selectedGoods = GetSelectedGoods();
            var selectedWarehouse = GetSelectedWarehouse();
            if (selectedWarehouse == null || selectedGoods == null)
                return;

            var lastOrder = GetAllOrders()?.LastOrDefault();
            var order = new Order(lastOrder?.Id ?? 0 ,selectedGoods,selectedWarehouse);

            var leastBusyManager = FindLeastBusyEmployee(
                new List<Employee>(GetAllManagers()));
            var leastBusyDriver = FindLeastBusyEmployee(
                new List<Employee>(GetAllDrivers()));

            ChainHandler chain = new EmployeeHandler(leastBusyManager);
            chain.SetNextHandler(new EmployeeHandler(leastBusyDriver));

            var processedOrder = chain.ProcessOrder(order);
            
            DataRepository.Orders.Insert(processedOrder);
            View.DisplayOrder(processedOrder);
            
            UnselectAll(new List<ISelectable>(GetAllGoods()));
            UnselectAll(new List<ISelectable>(GetAllWarehouses()));
        }


        public Employee FindLeastBusyEmployee(List<Employee> employees)
        {
            return employees.Aggregate((min,x) => 
                min.LoadedHours > x.LoadedHours 
                    ? x : min);
        }

        public void UnselectAll(List<ISelectable> items)
        {
            items.ForEach(item => item.Selected = false);
        }

        public void UnselectGoods(int selectedIndex)
        {
            if (GetAllGoods().Count >= selectedIndex)
            {
                var item = GetAllGoods()[selectedIndex];
                item.Selected = false;
                NotifyAboutSuccess();
                return;
            }
            NotifyAboutError();
        }

        public void SelectWarehouse(int selectedIndex)
        {
            if (GetAllWarehouses().Count >= selectedIndex)
            {
                var item = GetAllWarehouses()[selectedIndex];

                item.Selected = true;
                NotifyAboutSuccess();
                return;
            }
            NotifyAboutError();
        }

        public void UnselectWarehouse(int selectedIndex)
        {
            if (GetAllWarehouses().Count >= selectedIndex)
            {
                var item = GetAllWarehouses()[selectedIndex];
                item.Selected = false;
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
            return GetAllGoods()
            .FindAll(goods => goods.Selected == true);
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