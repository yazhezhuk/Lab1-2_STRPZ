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
        private UnitOfWork UnitOfWork { get; }

        public OrderService(UnitOfWork context)
        {
            UnitOfWork = context;
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
            ProcessOrder(order);
            var orderGoods = order.Goods;
            var orderEntity = order.ToEntity();
            orderGoods.ForEach(goods => UnitOfWork.OrderInfos.Add(
                    new OrderItemEntity
                    {
                        Id = InMemoryDataStub.Instance.OrderId,
                        GoodsId = goods.Id,
                        OrderId = orderEntity.Id
                    }));

            UnitOfWork.Order.Add(orderEntity);
        }

        public OrderModel Get(int id)
        {
            IService<WarehouseModel> warehouseService = new WarehouseService(UnitOfWork);

            var orderDbEntity = UnitOfWork.Order.GetById(id);
            var orderModel = orderDbEntity.ToModel();
            orderModel.Goods = orderDbEntity.Goods
                .Select(goods => goods.ToModel())
                .ToList();

            return orderModel;
        }

        public void Delete(OrderModel item)
        {
            UnitOfWork.Order.Delete(item.ToEntity().Id);
        }

        public List<OrderModel> GetAll()
        {
            return UnitOfWork.Order
                .GetAll()
                .Select(OrderMapper.ToModel)
                .ToList();
        }
    }
}