using System;
using System.Collections.Generic;

namespace employeeInformation
{
    internal class Program
    {
        /*//emp variables; id, name, sex, age/birthdate, phone number, email, address, company position, salary.
        static List<string> empID = new List<string>();
        static List<string> empName = new List<string>();
        static List<char> empGender = new List<char>();
        static List<string> empBirthdate = new List<string>();
        static List<long> empPhone = new List<long>();
        static List<string> empEmail = new List<string>();
        static List<string> empAddress = new List<string>();
        static List<string> empPosition = new List<string>();
        static List<float> empSalary = new List<float>();
        */

        static EBL empBL = new EBL();

        static void Main(string[] args)
        {
            int select = 0;

            while (select != 5)
            {
                Console.WriteLine("EMPLOYEE MANAGEMENT SYSTEM");
                Console.WriteLine("\nSELECT OPTION");
                Console.Write("1 - ADD | 2 - VIEW ALL | 3 - UPDATE | 4 - DELETE | 5 - EXIT SYSTEM. SELECT: ");
                select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        empBL.addEmp();
                        break;
                    case 2:
                        empBL.dispEmp();
                        break;
                    case 3:
                        empBL.updateEmp();
                        break;
                    case 4:
                        empBL.delEmp();
                        break;
                    case 5:
                        Console.WriteLine("Exiting system...");
                        return;
                        break;
                    default:
                        Console.WriteLine("Input not recognized. Please see options list.");
                        break;
                }
            }

        }

        /*static void addEmp()
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

            empID.Add(id);
            empName.Add(name);
            empGender.Add(gender);
            empBirthdate.Add(birthdate);
            empPhone.Add(phone);
            empEmail.Add(email);
            empAddress.Add(address);
            empPosition.Add(position);
            empSalary.Add(salary);
        }
        static void dispEmp()
        {
            Console.WriteLine("\nEMPLOYEE LIST");

            int showBy = 0;

            Console.WriteLine("1 = SHOW ID LIST || 2 = SHOW BY ID (TYPE IN EMPLOYEE ID)");
            Console.Write("Enter: ");
            showBy = int.Parse(Console.ReadLine());

            if (showBy == 1)
            {
                Console.WriteLine("\nEMPLOYEE IDS:");

                for (int i = 0; i < empID.Count; i++)
                {
                    Console.WriteLine(empID[i]);
                }
            }

            else if (showBy == 2)
            {
                Console.Write("\nEnter Employee ID: ");
                string searchID = Console.ReadLine();

                int index = empID.IndexOf(searchID);

                if (index != -1)
                {
                    Console.WriteLine("\nEMPLOYEE DETAILS");
                    Console.WriteLine($"ID: {empID[index]}");
                    Console.WriteLine($"NAME: {empName[index]}");
                    Console.WriteLine($"GENDER: {empGender[index]}");
                    Console.WriteLine($"BIRTHDATE: {empBirthdate[index]}");
                    Console.WriteLine($"PHONE NO.: {empPhone[index]}");
                    Console.WriteLine($"EMAIL: {empEmail[index]}");
                    Console.WriteLine($"ADDRESS: {empAddress[index]}");
                    Console.WriteLine($"POSITION: {empPosition[index]}");
                    Console.WriteLine($"SALARY: {empSalary[index]}");
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
        static void updateEmp()
        {
            Console.WriteLine("\nUPDATE EMPLOYEE");

            Console.Write("Enter Employee ID: ");
            string searchID = Console.ReadLine();

            int index = empID.IndexOf(searchID);

            if (index != -1)
            {
                Console.WriteLine("\nENTER NEW INFORMATION");

                Console.Write("Name: "); empName[index] = Console.ReadLine();
                Console.Write("Gender (F/M): "); empGender[index] = char.Parse(Console.ReadLine());
                Console.Write("Birthdate (dd/mm/yyyy): "); empBirthdate[index] = Console.ReadLine();
                Console.Write("Phone no.: "); empPhone[index] = long.Parse(Console.ReadLine());
                Console.Write("Email: "); empEmail[index] = Console.ReadLine();
                Console.Write("Address: "); empAddress[index] = Console.ReadLine();
                Console.Write("Company Position: "); empPosition[index] = Console.ReadLine();
                Console.Write("Salary: PHP "); empSalary[index] = float.Parse(Console.ReadLine());

                Console.WriteLine("Employee information updated.");
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
            }
        }
        static void delEmp()
        {
            Console.WriteLine("\nDELETE EMPLOYEE");

            Console.Write("Enter Employee ID: ");
            string searchID = Console.ReadLine();

            int index = empID.IndexOf(searchID);

            if (index != -1)
            {
                empID.RemoveAt(index);
                empName.RemoveAt(index);
                empGender.RemoveAt(index);
                empBirthdate.RemoveAt(index);
                empPhone.RemoveAt(index);
                empEmail.RemoveAt(index);
                empAddress.RemoveAt(index);
                empPosition.RemoveAt(index);
                empSalary.RemoveAt(index);

                Console.WriteLine("Employee deleted.");
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
            }
        }*/
    }
}
