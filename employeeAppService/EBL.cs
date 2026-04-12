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

        public bool isFieldEmpty(string input)//PREEMPTIVE CHECK FOR STRING FIELDS FILLED
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public bool isIdValid(string id)//CHECK ID LENGTH AND ALPHANUMERIC CONSTRAINTS COMPLIANCE
        {
            if (isFieldEmpty(id)) return false;
            if (id.Length != 8) return false;

            foreach (char c in id)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool isGenderValid(char gender)//GENDER INPUT VALIDITY
        {
            return gender == 'F' || gender == 'M' || gender == 'O';
        }

        // PHONE VALIDATION - Complete validation
        public bool isPhoneValid(string phone)//CONTACT NUMBER INPUT VALIDITY
        {
            return !isFieldEmpty(phone) && !phone.Contains(" ") && phone.All(char.IsDigit) && phone.Length >= 10;
        }

        public bool isSalaryValid(float salary)//PREEMPTIVE CHECK FOR SALARY VALIDITY (SAMPLE DESIGNATED MONTHLY MINIMUM)
        {
            return salary >= 10000;
        }

        public bool isEmailValid(string email)//EMAIL FORMAT VALIDITY
        {
            if (isFieldEmpty(email)) return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool isBirthdateValid(string birthdate)//BIRTHDATE FORMAT VALIDITY (dd/mm/yyyy)
        {
            return DateTime.TryParseExact(birthdate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _);
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