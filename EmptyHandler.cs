namespace Lab1Components
{
    public class EmptyHandler:AbstractChainHandler
    {
        public override Order ProcessOrder(Order order)
        {
            return order;
        }
    }
}