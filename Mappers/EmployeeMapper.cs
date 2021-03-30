using System.Linq;
using Domain.EmployeesDomain;
using DomainFactories;
using Entities;

namespace Mappers
{
    public class EmployeeMapper
    {
        public EmployeeEntity ToEntity(EmployeeModel employee) => 
            new()
            {
                Id = employee.Id,
                Age = employee.Age,
                Firstname = employee.Firstname,
                Lastname = employee.Lastname,
                Speciality = employee.Speciality
            };

        public EmployeeModel ToModel(EmployeeEntity employee)
        {
            var orderMapper = new OrderMapper();

            var factory = new EmployeeFactory();
            var convertedEmployee = factory.GetEmployee(employee.Speciality);
            convertedEmployee.Id = employee.Id;
            convertedEmployee.Age = employee.Age;
            convertedEmployee.Firstname = employee.Firstname;
            convertedEmployee.Lastname = employee.Lastname;
            convertedEmployee.Orders = employee.Orders
                .Select(orderEntity => orderMapper.ToModel(orderEntity))
                .ToList();

            return convertedEmployee;
        }
    }
}