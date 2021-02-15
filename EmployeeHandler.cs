namespace Lab1Components
{
    public class EmployeeHandler : ChainHandler
    {
        public EmployeeHandler(Employee employee)
        {
            ProcessingInstance = employee;
        }

        public override Order ProcessOrder(Order order)
        {
            order.ProcessingEmployees.Add(ProcessingInstance);
            ProcessingInstance.ProcessOrder(order);
            return NextHandler != null 
                ? NextHandler.ProcessOrder(order) 
                : order;
        }
    }
}