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

        public void dispIDList()
        {
            Console.WriteLine("\nEMPLOYEE IDS:");

            List<Employee> employees = dataService.GetAll();

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].ID);
            }
        }

        public void dispSpecificEmployee()
        {
            Console.Write("\nEnter Employee ID: ");
            string searchID = Console.ReadLine();

            Employee e = dataService.GetById(searchID);

            if (e != null)
            {
		        Console.WriteLine("\nEMPLOYEE DETAILS");
                Console.WriteLine($"ID: {e.ID}");
                Console.WriteLine($"FIRST NAME: {e.FirstName}");
                Console.WriteLine($"LAST NAME: {e.LastName}");
                Console.WriteLine($"MIDDLE NAME: {e.MiddleName}");
                Console.WriteLine($"SUFFIX: {e.Suffix}");
                Console.WriteLine($"GENDER: {e.Gender}");
                Console.WriteLine($"BIRTHDATE: {e.Birthdate}");
                Console.WriteLine($"PHONE NO.: {e.Phone}");
                Console.WriteLine($"EMAIL: {e.Email}");
                Console.WriteLine($"ADDRESS: {e.Address}");
                Console.WriteLine($"POSITION: {e.Position}");
                Console.WriteLine($"SALARY: {e.Salary}");
            }
            else
            {
                Console.WriteLine("Employee ID not found. Refer to full ID list in VIEW EMPLOYEES by typing in '1'");
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
                    Console.WriteLine("Employee ID not found.");
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
                    Console.WriteLine("Employee ID not found. Refer to full ID list in VIEW EMPLOYEES");
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