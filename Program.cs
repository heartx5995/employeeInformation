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
        static List<long> empPhone = new List<long>(); //phone - will change to (CTRYnum)############# format in later commit.
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
                Console.Write("1 - ADD | 2 - VIEW ALL | 3 - UPDATE | 4 - DELETE | 5 - EXIT SYSTEM. SELECT: ");
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
                        updateEmp(); //IN LATER COMMIT
                        break;
                    case 4:
                        delEmp(); //IN LATER COMMIT
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
            for (int i = 0; i < empID.Count; i++)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"ID: {empID[i]} | NAME: {empName[i]} | GENDER: {empGender[i]} | BIRTHDATE: {empBirthdate[i]}");
                Console.WriteLine($"PHONE: {empPhone[i]} | EMAIL: {empEmail[i]} | ADDRESS: {empAddress[i]}");
                Console.WriteLine($"POSITION: {empPosition[i]} | SALARY: PHP{empSalary[i]}");
            }
        }
        static void updateEmp()
        {

        }
        static void delEmp()
        {

        }
    }
}
