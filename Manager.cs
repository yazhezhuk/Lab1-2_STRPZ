namespace Lab1Components
{
    public class Manager : Employee
    {
        public Manager(int id, string name, int age) : base(id, name, age) { }

        public override void ProcessOrder(Order order)
        { 
            this.LoadedHours += order.Goods.ProcessTime;
            order.EstimateDeliveryTime += this.LoadedHours;
        }
    }
}