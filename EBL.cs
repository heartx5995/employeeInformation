using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;

namespace employeeInformation
{
    public class EBL
    {
        static EDL empDL = new EDL();

        public void addEmp()
        {
            Console.WriteLine("\nADD EMPLOYEE");

            Console.Write("ID: "); string id = Console.ReadLine();
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Gender (F/M): "); char gender = char.Parse(Console.ReadLine());
            Console.Write("Birthdate (dd/mm/yyyy): "); string birthdate = Console.ReadLine();
            Console.Write("Phone no.: "); long phone = long.Parse(Console.ReadLine());
            Console.Write("Email: "); string email = Console.ReadLine();
            Console.Write("Address: "); string address = Console.ReadLine();
            Console.Write("Company Position: "); string position = Console.ReadLine();
            Console.Write("Salary: PHP "); float salary = float.Parse(Console.ReadLine());

            Employee emp = new Employee();

            emp.ID = id;
            emp.Name = name;
            emp.Gender = gender;
            emp.Birthdate = birthdate;
            emp.Phone = phone;
            emp.Email = email;
            emp.Address = address;
            emp.Position = position;
            emp.Salary = salary;

            empDL.employees.Add(emp);
        }
        public void dispEmp()
        {
            Console.WriteLine("\nEMPLOYEE LIST");

            int showBy = 0;

            Console.WriteLine("1 = SHOW ID LIST || 2 = SHOW BY ID (TYPE IN EMPLOYEE ID)");
            Console.Write("Enter: ");
            showBy = int.Parse(Console.ReadLine());

            if (showBy == 1)
            {
                Console.WriteLine("\nEMPLOYEE IDS:");

                for (int i = 0; i < empDL.employees.Count; i++)
                {
                    Console.WriteLine(empDL.employees[i].ID);
                }
            }

            else if (showBy == 2)
            {
                Console.Write("\nEnter Employee ID: ");
                string searchID = Console.ReadLine();

                Employee e = empDL.employees.FirstOrDefault(emp => emp.ID == searchID);

                if (e != null)
                {
                    Console.WriteLine("\nEMPLOYEE DETAILS");
                    Console.WriteLine($"ID: {e.ID}");
                    Console.WriteLine($"NAME: {e.Name}");
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

            int index = empDL.findIndex(searchID);

            Employee e = empDL.employees.FirstOrDefault(emp => emp.ID == searchID);

            if (e != null)
            {
                Console.WriteLine("\nENTER NEW INFORMATION");

                Console.Write("Name: "); e.Name = Console.ReadLine();
                Console.Write("Gender (F/M): "); e.Gender = char.Parse(Console.ReadLine());
                Console.Write("Birthdate (dd/mm/yyyy): "); e.Birthdate = Console.ReadLine();
                Console.Write("Phone no.: "); e.Phone = long.Parse(Console.ReadLine());
                Console.Write("Email: "); e.Email = Console.ReadLine();
                Console.Write("Address: "); e.Address = Console.ReadLine();
                Console.Write("Company Position: "); e.Position = Console.ReadLine();
                Console.Write("Salary: PHP "); e.Salary = float.Parse(Console.ReadLine());

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

            Employee e = empDL.employees.FirstOrDefault(emp => emp.ID == searchID);

            if (e != null)
            {
                empDL.employees.Remove(e);
                Console.WriteLine("Employee deleted.");
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
            }
        }

    }
}
