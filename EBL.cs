using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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

            empDL.empID.Add(id);
            empDL.empName.Add(name);
            empDL.empGender.Add(gender);
            empDL.empBirthdate.Add(birthdate);
            empDL.empPhone.Add(phone);
            empDL.empEmail.Add(email);
            empDL.empAddress.Add(address);
            empDL.empPosition.Add(position);
            empDL.empSalary.Add(salary);
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

                for (int i = 0; i < empDL.empID.Count; i++)
                {
                    Console.WriteLine(empDL.empID[i]);
                }
            }

            else if (showBy == 2)
            {
                Console.Write("\nEnter Employee ID: ");
                string searchID = Console.ReadLine();

                int index = empDL.empID.IndexOf(searchID);

                if (index != -1)
                {
                    Console.WriteLine("\nEMPLOYEE DETAILS");
                    Console.WriteLine($"ID: {empDL.empID[index]}");
                    Console.WriteLine($"NAME: {empDL.empName[index]}");
                    Console.WriteLine($"GENDER: {empDL.empGender[index]}");
                    Console.WriteLine($"BIRTHDATE: {empDL.empBirthdate[index]}");
                    Console.WriteLine($"PHONE NO.: {empDL.empPhone[index]}");
                    Console.WriteLine($"EMAIL: {empDL.empEmail[index]}");
                    Console.WriteLine($"ADDRESS: {empDL.empAddress[index]}");
                    Console.WriteLine($"POSITION: {empDL.empPosition[index]}");
                    Console.WriteLine($"SALARY: {empDL.empSalary[index]}");
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

            int index = empDL.empID.IndexOf(searchID);

            if (index != -1)
            {
                Console.WriteLine("\nENTER NEW INFORMATION");

                Console.Write("Name: "); empDL.empName[index] = Console.ReadLine();
                Console.Write("Gender (F/M): "); empDL.empGender[index] = char.Parse(Console.ReadLine());
                Console.Write("Birthdate (dd/mm/yyyy): "); empDL.empBirthdate[index] = Console.ReadLine();
                Console.Write("Phone no.: "); empDL.empPhone[index] = long.Parse(Console.ReadLine());
                Console.Write("Email: "); empDL.empEmail[index] = Console.ReadLine();
                Console.Write("Address: "); empDL.empAddress[index] = Console.ReadLine();
                Console.Write("Company Position: "); empDL.empPosition[index] = Console.ReadLine();
                Console.Write("Salary: PHP "); empDL.empSalary[index] = float.Parse(Console.ReadLine());

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

            int index = empDL.empID.IndexOf(searchID);

            if (index != -1)
            {
                empDL.empID.RemoveAt(index);
                empDL.empName.RemoveAt(index);
                empDL.empGender.RemoveAt(index);
                empDL.empBirthdate.RemoveAt(index);
                empDL.empPhone.RemoveAt(index);
                empDL.empEmail.RemoveAt(index);
                empDL.empAddress.RemoveAt(index);
                empDL.empPosition.RemoveAt(index);
                empDL.empSalary.RemoveAt(index);

                Console.WriteLine("Employee deleted.");
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
            }
        }

    }
}
