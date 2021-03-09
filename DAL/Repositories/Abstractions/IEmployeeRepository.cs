using System.Collections.Generic;
using Entities;

namespace DAL.Repositories.Abstractions
{
    public interface IEmployeeRepository : IRepository<EmployeeEntity>
    {
        List<OrderEntity> GetEmployeeOrders(int id);
    }
}