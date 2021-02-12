using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;

namespace Lab1Components
{
    public abstract class AbstractChainHandler
    {
        public Employee ProcessingInstance { get; set; }
        protected AbstractChainHandler NextHandler = new EmptyHandler();

        public AbstractChainHandler SetNextHandler(AbstractChainHandler handler)
        {
            NextHandler = handler;
            return handler;
        }

        public abstract Order ProcessOrder(Order order);
    }
}