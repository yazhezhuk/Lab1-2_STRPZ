namespace Lab1Components
{
    public class Driver : Employee
    {
        public const int Speed = 70;
        public Driver(string name) : base(name) { }

        public override void ProcessOrder(Order order)
        {
            LoadHours += order.Warehouse.Distance / Speed * 2;
            order.EstimateTime += LoadHours / 2;

            System.Console.WriteLine($"Driver {Name} will deliver your order," +
                                     $" that may take {order.Warehouse.Distance/Speed} hours");
        }
    }
}