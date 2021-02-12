namespace Lab1Components
{
    public class Driver : Employee
    {
        public const int AverageSpeed = 70;

        public Driver(int id, string name, int age) : base(id, name, age) { }

        public override void ProcessOrder(Order order)
        {
            this.LoadedHours += (order.Warehouse.Distance / AverageSpeed) * 2 ;
            order.EstimateDeliveryTime += this.LoadedHours;
        }
    }
}