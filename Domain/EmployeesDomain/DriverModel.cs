using System;
using Domain.OrderDomain;
using Types;

namespace Domain.EmployeesDomain
{
    public class DriverModel : EmployeeModel
    {
        public const int AverageSpeed = 70;

        public override Speciality Speciality
        {
            get => Speciality.Driver;
        }

        public TimeSpan CalculateDeliveryTime(OrderModel order)
        {
            double deliveryTime = (order.RelativeDistance / AverageSpeed) * 2;

            var deliveryDays = (int)Math.Truncate(Math.Truncate(deliveryTime) / 24);

            deliveryTime -= deliveryDays * 24;
            var deliveryHours = (int)Math.Truncate(deliveryTime);

            return new TimeSpan(deliveryDays, deliveryHours, 0, 0);
        }

        public override void ProcessOrder(OrderModel order)
        {
            order.DriverId = Id;

            var deliveryTime = CalculateDeliveryTime(order);
            order.EstimateProcessTime += this.LoadedHours;
            order.EstimateProcessTime += deliveryTime;
        }

    }
}