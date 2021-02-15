namespace Lab1Components
{
    public abstract class ChainHandler
    {
        public Employee ProcessingInstance { get; set; }
        protected ChainHandler NextHandler { get; set; }

        public ChainHandler SetNextHandler(ChainHandler handler)
        {
            NextHandler = handler;
            return handler;
        }

        public abstract Order ProcessOrder(Order order);
    }
}