using System;
using System.Collections.Generic;
using DAL;
using Domain.OrderDomain;
using Domain.WarehouseDomain;
using Entities;
using Mappers;
using Types;
using System.Linq;
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

        public OrderService(IUnitOfWork context)
        {
            UnitOfWork = context;
            OrderMapper = new OrderMapper();
            GoodsMapper = new GoodsMapper();
        }

        public void ProcessOrder(OrderModel order)
        {
            var staffService = new StaffService(UnitOfWork);

            var leastBusyManager = staffService.GetLeastBusyEmployee(Speciality.Manager);
            var leastBusyDriver = staffService.GetLeastBusyEmployee(Speciality.Driver);

            ChainHandler handlingPipeline = new EmployeeHandler(leastBusyManager);
            handlingPipeline.SetNextHandler(new EmployeeHandler(leastBusyDriver));
            handlingPipeline.ProcessOrder(order);

            staffService.Update(leastBusyDriver);
            staffService.Update(leastBusyManager);
        }

        public OrderModel MakeOrder(List<GoodsModel> selectedGoods,
                                    WarehouseModel selectedWarehouse)
        {
            var order = new OrderModel
            {
                Goods = selectedGoods,
                WarehouseId = selectedWarehouse.Id,
                RelativeDistance = selectedWarehouse.Distance,
                TimeOfCreation = DateTime.Now,
                Completed = false
            };
            return order;
        }
        
        public void Add(OrderModel order)
        {
            var orderGoods = order.Goods;
            var orderEntity = OrderMapper.ToEntity(order);
            orderGoods.ForEach(goods => UnitOfWork.OrderInfos.AddOrUpdate(
                    new OrderItemEntity
                    {
                        GoodsId = goods.Id,
                        OrderId = orderEntity.Id
                    }));

            UnitOfWork.Orders.AddOrUpdate(orderEntity);
        }

        public OrderModel Get(int id)
        {
            IService<WarehouseModel> warehouseService = new WarehouseService(UnitOfWork);

            var orderDbEntity = UnitOfWork.Orders.GetById(id);
            var orderModel = OrderMapper.ToModel(orderDbEntity);
            orderModel.Goods = orderDbEntity.Goods
                .Select(goods => GoodsMapper.ToModel(goods))
                .ToList();

            return orderModel;
        }

        public void Delete(OrderModel item)
        {
            UnitOfWork.Orders.Delete(OrderMapper.ToEntity(item).Id);
        }

        public List<OrderModel> GetAll()
        {
            return UnitOfWork.Orders
                .GetAll()
                .Select(OrderMapper.ToModel)
                .ToList();
        }
    }
}