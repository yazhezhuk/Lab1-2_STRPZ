using Domain.EmployeesDomain;
using DomainFactories;
using Entities;

namespace Mappers
{
    public class EmployeeMapper
    {
        public EmployeeEntity ToEntity(EmployeeModel employee)
        {
            return new EmployeeEntity
            {
                Id = employee.Id,
                Age = employee.Age,
                Firstname = employee.Firstname,
                Lastname = employee.Lastname,
                Speciality = employee.Speciality
            };
        }

        public EmployeeModel ToModel(EmployeeEntity employee)
        {
            var factory = new EmployeeFactory();
            var convertedEmployee = factory.GetEmployee(employee.Speciality);
            convertedEmployee.Id = employee.Id;
            convertedEmployee.Age = employee.Age;
            convertedEmployee.Firstname = employee.Firstname;
            convertedEmployee.Lastname = employee.Lastname;

            return convertedEmployee;
        }
    }
}