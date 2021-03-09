using Domain.EmployeesDomain;
using Domain.OrderDomain;

namespace Services.ChainHandlers
{
    public abstract class ChainHandler
    {
        public EmployeeModel ProcessingInstance { get; set; }
        protected ChainHandler NextHandler { get; set; }

        public ChainHandler SetNextHandler(ChainHandler handler)
        {
            NextHandler = handler;
            return handler;
        }

        public abstract OrderModel ProcessOrder(OrderModel order);
    }
}