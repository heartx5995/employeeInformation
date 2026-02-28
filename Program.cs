using System;
using System.Collections.Generic;

namespace employeeInformation
{
    internal class Program
    {
        //emp variables; id, name, sex, age/birthdate, phone number, email, address, company position, salary.
        static List<string> empID = new List<string>(); //id = 5 char length; 0-9, A-Z, a-z; eg Az14Q.
        static List<string> empName = new List<string>();
        static List<char> empGender = new List<char>();
        static List<string> empBirthdate = new List<string>(); //birthdate = dd/mm/yyyy
        static List<long> empPhone = new List<long>(); //phone - (CTRYnum)#############
        static List<string> empEmail = new List<string>();
        static List<string> empAddress = new List<string>();
        static List<string> empPosition = new List<string>();
        static List<float> empSalary = new List<float>();
        static void Main(string[] args)
        {
            int select = 0;

            while (select != 5)
            {
                Console.WriteLine("EMPLOYEE MANAGEMENT SYSTEM");
                Console.WriteLine("\nSELECT OPTION");
                Console.WriteLine("1 - ADD | 2 - VIEW ALL | 3 - UPDATE | 4 - DELETE | 5 - EXIT SYSTEM.");
                select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        addEmp();
                        break;
                    case 2:
                        dispEmp();
                        break;
                    case 3:
                        updateEmp();
                        break;
                    case 4:
                        delEmp();
                        break;
                    case 5:
                        Console.WriteLine("Exiting system...");
                        break;
                    default:
                        Console.WriteLine("Input not recognized. Please see options list.");
                        break;
                }
            }

        }

        static void addEmp()
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
        }
        static void dispEmp()
        {

        }
        static void updateEmp()
        {

        }
        static void delEmp()
        {

        }
    }
}
