using Domain.EmployeesDomain;
using Domain.OrderDomain;
namespace Services.ChainHandlers
{
    public class EmployeeHandler : ChainHandler
    {
        public EmployeeHandler(EmployeeModel employee)
        {
            ProcessingInstance = employee;
        }

        public override OrderModel ProcessOrder(OrderModel order)
        {
            ProcessingInstance.ProcessOrder(order);
            return NextHandler != null
                ? NextHandler.ProcessOrder(order)
                : order;
        }
    }
}