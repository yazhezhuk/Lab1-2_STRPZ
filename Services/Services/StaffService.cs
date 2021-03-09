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
        private EmployeeMapper EmployeeMapper { get; }
        private OrderMapper OrderMapper  { get; }


        public StaffService(UnitOfWork context)
        {
            Context = context;
            EmployeeMapper = new EmployeeMapper();
            OrderMapper = new OrderMapper();
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
                .Add(EmployeeMapper.ToEntity(item));
        }

        public EmployeeModel Get(int id)
        {
            var employeeModel = EmployeeMapper.ToModel(Context.Employees
                .GetById(id));
            employeeModel.Orders = GetEmployeeOrders(id);

            return employeeModel;
        }

        public List<OrderModel> GetEmployeeOrders(int id)
        {
            return Context.Employees
                .GetEmployeeOrders(id)
                .Select(order => OrderMapper.ToModel(order))
                .ToList();
        }

        public void Delete(EmployeeModel item)
        {
            Context.Employees.Delete(EmployeeMapper.ToEntity(item).Id);
        }

        public void Update(EmployeeModel employee)
        {
            var employeeEntity = EmployeeMapper.ToEntity(employee);
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