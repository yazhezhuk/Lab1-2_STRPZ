using System;
using System.Collections.Generic;
using DAL.Repositories.Abstractions;
using Entities;

namespace DAL.Repositories
{
    public class EmployeesRepository : IEmployeeRepository
    {
        private InMemoryDataStub DataStorage { get; } = InMemoryDataStub.Instance;

        public void Delete(int id)
        {
            var toDelete = DataStorage.EmployeesData
                .Find(employee => employee.Id == id);
            DataStorage.EmployeesData.Remove(toDelete);
        }

        public List<EmployeeEntity> GetAll(Predicate<EmployeeEntity> filter = null)
        {
            return filter != null
                ? DataStorage.EmployeesData.FindAll(filter)
                : DataStorage.EmployeesData;
        }

        public EmployeeEntity GetById(int id)
        {
            return DataStorage.EmployeesData.Find(employee => employee.Id == id);
        }

        public void Add(EmployeeEntity obj)
        {
            DataStorage.EmployeesData.Add(obj);
        }

        public void Update(EmployeeEntity obj)
        {
            throw new NotImplementedException();
        }

        public List<OrderEntity> GetEmployeeOrders(int id)
        {
            return DataStorage.OrdersData
                .FindAll(ord => ord.DriverId == id || ord.ManagerId == id);
        }
    }
}