using System;
using System.Collections.Generic;
using System.Linq;
using employeeModels;
using employeeDataService;

namespace employeeAppService
{
    public class EBL
    {
        static IDataService dataService;

        public EBL()
        {
            dataService = new empDbData();
        }

        public bool EmployeeExists(string id)//PREEMPTIVE ID CHECK FOR EXISTENCE
        {
            try
            {
                Employee emp = dataService.GetById(id);
                return emp != null;
            }
            catch
            {
                return false;
            }
        }

        public bool payValidity(float salary)
        {
            try
            {
                if(salary>=5000)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool addEmp(string id, string firstName, string lastName, string middleName, string suffix,
                           char gender, string birthdate, long phone, string email, string address, string position, float salary)
        {
            try
            {
                Employee emp = new Employee();

                emp.ID = id;
                emp.FirstName = firstName;
                emp.LastName = lastName;
                emp.MiddleName = middleName;
                emp.Suffix = suffix;
                emp.Gender = gender;
                emp.Birthdate = birthdate;
                emp.Phone = phone;
                emp.Email = email;
                emp.Address = address;
                emp.Position = position;
                emp.Salary = salary;

                dataService.Add(emp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return dataService.GetAll();
        }

        public Employee GetEmployeeById(string id)
        {
            return dataService.GetById(id);
        }

        public bool updateEmp(Employee emp)
        {
            try
            {
                dataService.Update(emp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateEmp(string searchID, string firstName, string lastName, string middleName, string suffix,
                              char gender, string birthdate, long phone, string email, string address, string position, float salary)
        {
            try
            {
                Employee e = dataService.GetById(searchID);

                if (e != null)
                {
                    e.FirstName = firstName;
                    e.LastName = lastName;
                    e.MiddleName = middleName;
                    e.Suffix = suffix;
                    e.Gender = gender;
                    e.Birthdate = birthdate;
                    e.Phone = phone;
                    e.Email = email;
                    e.Address = address;
                    e.Position = position;
                    e.Salary = salary;

                    dataService.Update(e);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool deleteEmp(string searchID)
        {
            try
            {
                Employee e = dataService.GetById(searchID);

                if (e != null)
                {
                    dataService.Delete(searchID);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public IDataService GetDataService()
        {
            return dataService;
        }
    }
}