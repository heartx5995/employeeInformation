using System;
using System.Collections.Generic;
using System.Text;

namespace employeeInformation
{
    public class EDL
    {
        //emp variables; id, name, sex, age/birthdate, phone number, email, address, company position, salary.
        public List<string> empID = new List<string>();
        public List<string> empName = new List<string>();
        public List<char> empGender = new List<char>();
        public List<string> empBirthdate = new List<string>();
        public List<long> empPhone = new List<long>();
        public List<string> empEmail = new List<string>();
        public List<string> empAddress = new List<string>();
        public List<string> empPosition = new List<string>();
        public List<float> empSalary = new List<float>();

        public int findIndex(string id)
        {
            return empID.IndexOf(id);
        }
    }
}
