using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using DAL;
using DAL.UnitOfWork;
using Domain.Annotations;
using Domain.GoodsDomain;
using Domain.OrderDomain;
using Services.Abstractions;
using Services.Services;

namespace WPFApp.ViewModels
{
	public class OrderDataViewModel : INotifyPropertyChanged
	{

		private readonly IGoodsService _goodsService;
		private readonly IOrderService _orderService;

		private OrderModel _selectedOrder;

		private ObservableCollection<OrderModel> _orders;

		public ObservableCollection<OrderModel> Orders
		{
			get => _orders;
			set
			{
				_orders = value;
				OnPropertyChanged();
			}
		}

		
		
		public OrderModel SelectedOrder
		{
			get => _selectedOrder;
			set {
				_selectedOrder = value;
				OnPropertyChanged();
			}
		}
		
		public OrderDataViewModel(UnitOfWork unitOfWork)
		{
			_goodsService = new GoodsService(unitOfWork);
			_orderService = new OrderService(unitOfWork);

			Orders = new ObservableCollection<OrderModel>(_orderService.GetAll());
		}

		public void OnOrderListChanged()
		{
			Orders = new ObservableCollection<OrderModel>(_orderService.GetAll());
		}
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}