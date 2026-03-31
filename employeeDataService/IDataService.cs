using System;
using System.Collections.Generic;
using employeeModels;

namespace employeeDataService
{
    public interface IDataService
    {
        void Add(Employee emp);
        List<Employee> GetAll();
        Employee GetById(string id);
        void Update(Employee emp);
        void Delete(string id);
        bool TestConnection();
    }
}