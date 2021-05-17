using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.UnitOfWork;
using Domain.EmployeesDomain;
using Domain.OrderDomain;
using Entities;
using Mappers;
using Services.Abstractions;
using Types;

namespace Services.Services
{
    public class StaffService : IStaffService
    {
        private IUnitOfWork UnitOfWork { get; }
        private EmployeeMapper EmployeeMapper { get; }
        private OrderMapper OrderMapper  { get; }


        public StaffService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            EmployeeMapper = new EmployeeMapper();
            OrderMapper = new OrderMapper();
        }

        public EmployeeModel GetLeastBusyEmployee(Speciality spec)
        {
            EmployeeModel leastBusy = GetAll(employee => employee.EmployeeSpeciality.Speciality == spec)
                .Aggregate((min, x) => min.LoadedHours > x.LoadedHours ? x : min);

            return leastBusy;
        }

        public List<EmployeeModel> GetAll(Predicate<EmployeeEntity> criteria)
        {
            var employees = UnitOfWork.Employees
                .GetAll()
                .Where(criteria.Invoke)
                .Select(EmployeeMapper.ToModel)
                .ToList();

            return employees;
        }

        public void Add(EmployeeModel item)
        {
            UnitOfWork.Employees
                .AddOrUpdate(EmployeeMapper.ToEntity(item));
        }

        public EmployeeModel Get(int id)
        {
            EmployeeModel employeeModel = EmployeeMapper.ToModel(UnitOfWork.Employees
                .GetById(id));

            return employeeModel;
        }

        public void Delete(EmployeeModel item)
        {
            UnitOfWork.Employees.Delete(EmployeeMapper.ToEntity(item));
        }

        public void Update(EmployeeModel employee)
        {
            UnitOfWork.Employees.Update(EmployeeMapper.ToEntity(employee));
        }

        public List<EmployeeModel> GetAll()
        {
            return UnitOfWork.Employees.GetAll()
                .Select(EmployeeMapper.ToModel)
                .ToList();
        }
    }
}