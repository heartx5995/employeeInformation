using System;
using System.Collections.Generic;
using System.Text;

namespace employeeModels
{
    public class Employee
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public char Gender { get; set; }
        public string Birthdate { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }
    }
}