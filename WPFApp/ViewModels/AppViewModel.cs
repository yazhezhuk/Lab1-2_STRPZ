using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DAL;
using DAL.UnitOfWork;
using Domain.GoodsDomain;
using Domain.OrderDomain;
using Domain.WarehouseDomain;
using Services.Abstractions;
using Services.Services;

namespace WPFApp.ViewModels
{
	public class AppViewModel: INotifyPropertyChanged
	{


		private readonly IGoodsService _goodsService;
		private readonly IOrderService _orderService;
		private readonly IWarehouseService _warehouseService;

		
		private OrderModel pendingOrder;
		private GoodsModel selectedGoods;
		private WarehouseModel selectedWarehouse;


		private string goodsQuantity;

		public OrderDataViewModel OrderDataViewModel { get; }

		public ObservableCollection<GoodsModel> Goods { get; set; }
		public ObservableCollection<WarehouseModel> Warehouses { get; set; }

		private ICommand addGoodsCommand;
		private ICommand commitOrderCommand;


		public GoodsModel SelectedGoods
		{
			get => selectedGoods;
			set {
				selectedGoods = value;
				OnPropertyChanged(); 
			}
		}

		public WarehouseModel SelectedWarehouse
		{
			get => selectedWarehouse;
			set {
				selectedWarehouse = value;
				OnPropertyChanged(); 
			}
		}
		
		public string GoodsQuantity
		{
			get => goodsQuantity;
			set
			{
				goodsQuantity = value;
				OnPropertyChanged();
			}
		}

		public ICommand AddGoodsCommand => addGoodsCommand ??= new CommandHandler(
			AddGoodsAction, 
			() => selectedGoods != null && goodsQuantity != string.Empty);
		
		public ICommand CommitOrderCommand => commitOrderCommand ??= new CommandHandler(
			CommitGoodsAction, 
			() =>
				pendingOrder != null 
			       && selectedWarehouse != null 
			       && pendingOrder.OrderItems.Count != 0);

		public void AddGoodsAction()
		{
			pendingOrder ??= _orderService.MakeOrder();
			int.TryParse(GoodsQuantity, out var parsedQuantity);
			
			OrderItemModel orderItem = pendingOrder.OrderItems.Find(item =>
				item.Goods.Id == selectedGoods.Id);
			if (orderItem != null){
				orderItem.Quantity += parsedQuantity;
			}
			else
				pendingOrder.OrderItems.Add(new OrderItemModel
				{
					Goods = selectedGoods,
					Quantity = parsedQuantity
				});
		}

		public void CommitGoodsAction()
		{
			pendingOrder.Warehouse = selectedWarehouse;

			_orderService.ProcessOrder(pendingOrder);

			var services = _orderService.GetAll();
			pendingOrder = null;
			
			OrderDataViewModel.OnOrderListChanged();
		}
		

		public AppViewModel(UnitOfWork unitOfWork)
		{
			_warehouseService = new WarehouseService(unitOfWork);
			_goodsService     = new GoodsService(unitOfWork);
			_orderService     = new OrderService(unitOfWork);
			
			Goods      = new ObservableCollection<GoodsModel>(_goodsService.GetAll());
			Warehouses = new ObservableCollection<WarehouseModel>(_warehouseService.GetAll());

			OrderDataViewModel = new OrderDataViewModel(unitOfWork);
		}
 
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}