namespace Lab1Components
{
    public class Driver : Employee
    {
        public Driver(string name) : base(name) { }

        public override void ProcessOrder(Order order)
        {
            LoadHours += order.Warehouse.Distance / 70 * 2;
            order.EstimateTime += LoadHours;

            System.Console.WriteLine(
                $"Driver {Name} will deliver your order, that will take {order.Warehouse.Distance/70} hours");
        }
    }
}