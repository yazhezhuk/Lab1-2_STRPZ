using System;
using System.Collections;
using System.Collections.Generic;
using DAL;
using Domain.OrderDomain;
using Domain.WarehouseDomain;
using Entities;
using Mappers;
using Types;
using System.Linq;
using DAL.UnitOfWork;
using Domain.EmployeesDomain;
using Domain.GoodsDomain;
using Services.Abstractions;
using Services.ChainHandlers;

namespace Services.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork UnitOfWork { get; }
        private OrderMapper OrderMapper { get; }
        private GoodsMapper GoodsMapper { get; }

        //TODO *use service DI`s*
        public OrderService( IUnitOfWork context )//IServiceProvider serviceProvider ) 
        {
            UnitOfWork = context;
            GoodsMapper = new GoodsMapper();
            OrderMapper = new OrderMapper();
        }

        public void ProcessOrder(OrderModel order)
        {
	        StaffService staffService = new StaffService(UnitOfWork);
	        OrderService orderService = new OrderService(UnitOfWork);

	        
            ChainHandler chainHandler;

            EmployeeModel leastBusyManager = staffService.GetLeastBusyEmployee(Speciality.Manager);
            chainHandler = new EmployeeHandler(leastBusyManager);
            
            EmployeeModel leastBusyDriver = staffService.GetLeastBusyEmployee(Speciality.Driver);
            chainHandler.SetNextHandler(new EmployeeHandler(leastBusyDriver));
            
            chainHandler.ProcessOrder(order);

            Add(order);
            
            staffService.Update(leastBusyDriver);
            staffService.Update(leastBusyManager);
        }

        public OrderModel MakeOrder()
        {
            OrderModel order = new OrderModel
            {
	            OrderItems = new List<OrderItemModel>(),
	            TimeOfCreation = DateTime.Now,
	            Completed = false
            };
            return order;
        }

        public OrderModel? GetPendingOrder()
        {
	        var selectedOrder = UnitOfWork.Orders
			        .GetAll()
			        .FindAll(order => !order.Completed)
			        .LastOrDefault() ?? null;
	        return selectedOrder != null 
		        ? OrderMapper.ToModel(selectedOrder) 
		        : null;
        }
        
        public void Add(OrderModel order)
        {
	        UnitOfWork.Orders.Add(OrderMapper.ToEntity(order));
	        
	        order.OrderItems.ForEach(goods => 
	             UnitOfWork.OrderInfos.Add(new OrderItemEntity 
	             {
		             GoodsId = goods.Goods.Id,
		             Quantity = goods.Quantity,
		             OrderId = UnitOfWork.Orders.GetAll().Last().Id
	             }));
             UnitOfWork.CommitChanges();
        }

        public void Update(OrderModel order)
        {
	        UnitOfWork.Orders.Update(OrderMapper.ToEntity(order));
	        order.OrderItems.ForEach(item => 
		        UnitOfWork.OrderInfos.Update(new OrderItemEntity
		        {
			          Id = item.Id,
				GoodsId = item.Goods.Id,
				OrderId = order.Id,
				Quantity = item.Quantity
		        }));
	        UnitOfWork.CommitChanges();
        }
        
        public OrderModel Get(int id)
        { 
	        var orderDbEntity = UnitOfWork.Orders.GetById(id);
            var orderModel = OrderMapper.ToModel(orderDbEntity);

            return orderModel;
        }

        public void Delete(OrderModel item)
        {
            UnitOfWork.Orders.Delete(OrderMapper.ToEntity(item));
            UnitOfWork.CommitChanges();
        }

        public List<OrderModel> GetAll()
        {
            return UnitOfWork.Orders
                .GetAll()
                .Select(OrderMapper.ToModel)
                .ToList();
        }

        public void Clear()
        {
        }
    }
}