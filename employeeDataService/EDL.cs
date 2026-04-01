using System;
using System.Collections.Generic;
using System.Text;
using employeeModels;

namespace employeeDataService
{

    public class EDL
    {
        public List<Employee> employees = new List<Employee>();

        public int findIndex(string id)
        {
            return employees.FindIndex(e => e.ID == id);
        }
    }
}