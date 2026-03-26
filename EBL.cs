using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;

namespace employeeInformation
{
    public class EBL
    {
        static IDataService dataService;

        public void addEmp()
        {
            Console.WriteLine("\nADD EMPLOYEE");

            Console.Write("ID: "); string id = Console.ReadLine();

            Console.Write("First Name: "); string firstName = Console.ReadLine();

            Console.Write("Last Name: "); string lastName = Console.ReadLine();

            Console.Write("Middle Name: "); string middleName = Console.ReadLine();

            Console.Write("Suffix (Jr., Sr., III, etc. - If applicable): "); string suffix = Console.ReadLine();

            Console.Write("Gender (F/M): "); char gender = char.Parse(Console.ReadLine());

            Console.Write("Birthdate (dd/mm/yyyy): "); string birthdate = Console.ReadLine();

            Console.Write("Phone no.: "); long phone = long.Parse(Console.ReadLine());

            Console.Write("Email: "); string email = Console.ReadLine();

            Console.Write("Address: "); string address = Console.ReadLine();

            Console.Write("Company Position: "); string position = Console.ReadLine();

            Console.Write("Salary: PHP "); float salary = float.Parse(Console.ReadLine());

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
            Console.WriteLine("Employee added.");
        }

        public void dispEmp()
        {
            Console.WriteLine("\nEMPLOYEE LIST");

            int showBy = 0;

            Console.WriteLine("1 = SHOW ID LIST || 2 = SHOW BY ID (TYPE IN EMPLOYEE ID)");
            Console.Write("Enter: ");
            showBy = int.Parse(Console.ReadLine());

            List<Employee> employees = dataService.GetAll();

            if (showBy == 1)
            {
                Console.WriteLine("\nEMPLOYEE IDS:");

                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine(employees[i].ID);
                }
            }

            else if (showBy == 2)
            {
                Console.Write("\nEnter Employee ID: ");
                string searchID = Console.ReadLine();

                Employee e = dataService.GetById(searchID);

                if (e != null)
                {
                    Console.WriteLine("\nEMPLOYEE DETAILS");
                    Console.WriteLine($"ID: {e.ID}");
                    Console.WriteLine($"FIRSTNAME: {e.FirstName}");
                    Console.WriteLine($"LASTNAME: {e.LastName}");
                    Console.WriteLine($"MIDDLENAME: {e.MiddleName}");
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
                    Console.WriteLine("Employee ID not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }

        public void updateEmp()
        {
            Console.WriteLine("\nUPDATE EMPLOYEE");

            Console.Write("Enter Employee ID: ");
            string searchID = Console.ReadLine();

            Employee e = dataService.GetById(searchID);

            if (e != null)
            {
                Console.WriteLine("\nENTER NEW INFORMATION");

                //NAME
                Console.Write($"First Name ({e.FirstName}): ");   /*/////////////*/ string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input)) e.FirstName = input;

                Console.Write($"Last Name ({e.LastName}): ");     /*/////////////*/ input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input)) e.LastName = input;

                Console.Write($"Middle Name ({e.MiddleName}): "); /*/////////////*/ input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input)) e.MiddleName = input;

                Console.Write($"Suffix ({e.Suffix}): ");         /*//////////////*/ input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input)) e.Suffix = input;

                //EV ELSE
                Console.Write("Gender (F/M): ");           e.Gender = char.Parse(Console.ReadLine());
                Console.Write("Birthdate (dd/mm/yyyy): "); e.Birthdate = Console.ReadLine();
                Console.Write("Phone no.: ");              e.Phone = long.Parse(Console.ReadLine());
                Console.Write("Email: ");                  e.Email = Console.ReadLine();
                Console.Write("Address: ");                e.Address = Console.ReadLine();
                Console.Write("Company Position: ");       e.Position = Console.ReadLine();
                Console.Write("Salary: PHP ");             e.Salary = float.Parse(Console.ReadLine());

                dataService.Update(e);
                Console.WriteLine("Employee information updated.");
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
            }
        }

        public void delEmp()
        {
            Console.WriteLine("\nDELETE EMPLOYEE");

            Console.Write("Enter Employee ID: ");
            string searchID = Console.ReadLine();

            Employee e = dataService.GetById(searchID);

            if (e != null)
            {
                dataService.Delete(searchID);
                Console.WriteLine("Employee deleted.");
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
            }
        }
        public IDataService GetDataService()
        {
            return dataService;
        }
    }
 }