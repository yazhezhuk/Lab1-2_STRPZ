using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
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
        private UnitOfWork Context { get; }

        public StaffService(UnitOfWork context)
        {
            Context = context;
        }

        public EmployeeModel GetLeastBusyEmployee(Speciality spec)
        {
            var leastBusy = GetAll(employee => employee.Speciality == spec)
                .Aggregate((min, x) =>
                    min.Orders.Count(order => order.Completed == false) > x.Orders.Count ? x : min);

            return leastBusy;
        }

        public List<EmployeeModel> GetAll(Predicate<EmployeeEntity> criteria)
        { 
            var employees = Context.Employees
                .GetAll(criteria)
                .Select(EmployeeMapper.ToModel)
                .ToList();
            employees.ForEach(employee => employee.Orders = GetEmployeeOrders(employee.Id));

            return employees;
        }

        public void Add(EmployeeModel item)
        {
            Context.Employees
                .Add(item.ToEntity());
        }

        public EmployeeModel Get(int id)
        {
            var employeeModel = Context.Employees
                .GetById(id)
                .ToModel();
            employeeModel.Orders = GetEmployeeOrders(id);

            return employeeModel;
        }

        public List<OrderModel> GetEmployeeOrders(int id)
        {
            return Context.Employees
                .GetEmployeeOrders(id)
                .Select(order => order.ToModel())
                .ToList();
        }

        public void Delete(EmployeeModel item)
        {
            Context.Employees.Delete(item.ToEntity().Id);
        }

        public void Update(EmployeeModel employee)
        {
            var employeeEntity = employee.ToEntity();
            Context.Employees.Delete(employeeEntity.Id);
            Context.Employees.Add(employeeEntity);
        }

        public List<EmployeeModel> GetAll()
        {
            return Context.Employees.GetAll()
                .Select(EmployeeMapper.ToModel)
                .ToList();
        }
    }
}