using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Lab1Components
{
    public class EmployeeHandler : AbstractChainHandler
    {

        public EmployeeHandler(Employee employee)
        {
            ProcessingInstance = employee;
        }

        public override Order ProcessOrder(Order order)
        {
            ProcessingInstance.ProcessOrder(order);
            return NextHandler.ProcessOrder(order);
        }
    }
}