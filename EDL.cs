using System;
using System.Collections.Generic;
using System.Text;

namespace employeeInformation
{
    //emp variables; id, firstname, lastname, middlename, suffix, gender, age/birthdate, phone number, email, address, company position, salary.
    public class Employee
    {
        public string ID;
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public string Suffix;
        public char Gender;
        public string Birthdate;
        public long Phone;
        public string Email;
        public string Address;
        public string Position;
        public float Salary;
    }
    public class EDL
    {
        public List<Employee> employees = new List<Employee>();

        public int findIndex(string id)
        {
            return employees.FindIndex(e => e.ID == id);
        }
    }
}
