using System;
using System.Linq;
using Domain.OrderDomain;
using Types;

namespace Domain.EmployeesDomain
{
    public class ManagerModel : EmployeeModel
    {
        public override Speciality Speciality
        {
            get => Speciality.Manager;
        }

        public TimeSpan CalculateOrderProcessTime(OrderModel order)
        {
            return order.Goods
                        .Select(goods => goods.ProcessTime)
                        .Aggregate((g1, g2) => g1 + g2);
        }

        public int CalculateOrderCost(OrderModel order)
        {
            return order.Goods
                .Select(goods => goods.Price)
                .Aggregate((g1, g2) => g1 + g2);
        }

        public override void ProcessOrder(OrderModel order)
        {
            order.ManagerId = Id;

            order.TotalCost = CalculateOrderCost(order);
            order.EstimateProcessTime += this.LoadedHours;
            order.EstimateProcessTime += CalculateOrderProcessTime(order);
        }

    }
}