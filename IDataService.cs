using System;
using System.Collections.Generic;

namespace employeeInformation
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