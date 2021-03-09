using System.Collections.Generic;
using Domain.EmployeesDomain;
using Domain.OrderDomain;
using Types;

namespace Services.Abstractions
{
    public interface IStaffService : IService<EmployeeModel>
    {
        EmployeeModel GetLeastBusyEmployee(Speciality spec);
    }
}