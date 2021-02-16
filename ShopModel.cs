using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab1Components
{
    public class ShopModel : ISaveableEntity
    {
        public int Id { get; set; }

        public ApplicationContext Context { get; }

        public ShopModel(ApplicationContext context)
        {
            Context = context;
        }

        public void SelectGoods(Goods goods)
        {
            goods.Selected = true;
        }

        public void SelectWarehouse(Warehouse warehouse)
        {
            warehouse.Selected = true;
        }

        private Employee FindLeastBusyEmployee(List<Employee> employees)
        {
            return employees.Aggregate( (min, x) =>
                min.LoadedHours > x.LoadedHours ? x : min);
        }

        public void UnselectAll(List<ISelectable> items)
        {
            items.ForEach(item => item.Selected = false);
        }

        public List<Goods> GetSelectedGoods()
        {
            return Context.Goods
                .GetAll(goods => goods.Selected);
        }

        public Warehouse GetSelectedWarehouse()
        {
            return Context.Warehouses
                .GetAll(warehouses => warehouses.Selected)
                .FirstOrDefault();
        }

        public Order ProcessOrder(Order order)
        {
            var managers = Context.Managers.GetAll();
            var drivers = Context.Drivers.GetAll();

                var manager = (Manager)FindLeastBusyEmployee(
                new List<Employee>(managers));
            var driver = (Driver)FindLeastBusyEmployee(
                new List<Employee>(drivers));

            UnselectAll(new List<ISelectable>(Context.Goods.GetAll()));
            UnselectAll(new List<ISelectable>(Context.Warehouses.GetAll()));

            return new EmployeeHandler(manager)
                .SetNextHandler(new EmployeeHandler(driver))
                .ProcessOrder(order);
            
        }

        public Order FormOrder()
        {
            var selectedGoods = GetSelectedGoods();
            var selectedWarehouse = GetSelectedWarehouse();
            if (selectedWarehouse == null || selectedGoods == null)
                return null;

            var manager = (Manager)FindLeastBusyEmployee(
                new List<Employee>(Context.Managers.GetAll()));
            var driver = (Driver)FindLeastBusyEmployee(
                new List<Employee>(Context.Drivers.GetAll()));

            var formedOrder = new Order(driver, manager, selectedWarehouse, selectedGoods);
            Context.Order.Insert(formedOrder);
            return formedOrder;

        }
    }
}