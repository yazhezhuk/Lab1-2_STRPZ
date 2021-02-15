using System.Linq;

namespace Lab1Components
{
    public class Manager : Employee
    {
        public Manager(int id, string name, int age) : base(id, name, age)
        {
        }

        public override void ProcessOrder(Order proceedingOrder)
        {
            this.LoadedHours += proceedingOrder.Goods
                .Sum(order => order.ProcessTime);
            proceedingOrder.EstimateDeliveryTime += this.LoadedHours;
        }
    }
}