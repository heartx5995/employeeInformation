using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace employeeInformation
{
    public class empJsonData : IDataService
    {
        private List<Employee> employees = new List<Employee>();
        private string jsonFile;

        public empJsonData()
        {
            jsonFile = $"{AppDomain.CurrentDomain.BaseDirectory}/employees.json";
            loadFromFile();
        }

        private void loadFromFile()
        {
            if (File.Exists(jsonFile))
            {
                string jsonContent = File.ReadAllText(jsonFile);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                employees = JsonSerializer.Deserialize<List<Employee>>(jsonContent, options) ?? new List<Employee>();
            }
        }

        private void saveToFile()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonContent = JsonSerializer.Serialize(employees, options);
            File.WriteAllText(jsonFile, jsonContent);
        }

        public void Add(Employee emp)
        {
            loadFromFile();
            employees.Add(emp);
            saveToFile();
        }

        public List<Employee> GetAll()
        {
            loadFromFile();
            return employees;
        }

        public Employee GetById(string id)
        {
            loadFromFile();
            return employees.Find(e => e.ID == id);
        }

        public void Update(Employee emp)
        {
            loadFromFile();
            int index = employees.FindIndex(e => e.ID == emp.ID);
            if (index != -1)
            {
                employees[index] = emp;
                saveToFile();
            }
        }

        public void Delete(string id)
        {
            loadFromFile();
            Employee emp = employees.Find(e => e.ID == id);
            if (emp != null)
            {
                employees.Remove(emp);
                saveToFile();
            }
        }
    }
}