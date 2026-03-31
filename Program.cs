using System;
using System.Collections.Generic;
using employeeAppService;

namespace employeeInformation
{
    public class Program
    {
        static EBL empBL = new EBL();

        static void Main(string[] args)
        {
            string inputForSelect = "";

            while (inputForSelect != "5")
            {
                Console.WriteLine("\n===============================");
                Console.WriteLine("EMPLOYEE MANAGEMENT SYSTEM");
                Console.WriteLine("===============================");
                Console.WriteLine("\nSELECT DESIRED ACTION\n");
                Console.Write("1 - HIRE EMPLOYEES" +
                              "\n2 - VIEW EMPLOYEES" +
                              "\n3 - UPDATE EMPLOYEES" +
                              "\n4 - TERMINATE EMPLOYEES" +
                              "\n5 - EXIT SYSTEM" +
                              "\n\nSELECT: ");

                inputForSelect = Console.ReadLine();

                switch (inputForSelect)
                {
                    //HIRE EMPLOYEES
                    case "1":
                        Console.WriteLine("\nHIRE EMPLOYEE");

                        Console.Write("ID: "); string id = Console.ReadLine();

                        if (empBL.EmployeeExists(id))
                        {
                            Console.WriteLine("Error: Employee ID already exists. Hire cancelled.");
                            break;
                        }

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


                        bool hired = empBL.addEmp(id, firstName, lastName, middleName, suffix,
                                     gender, birthdate, phone, email, address, position, salary);
                        if(hired)
                        {
                            Console.WriteLine("Employee added.");
                        }
                        else
                        {
                            Console.WriteLine("Employee not added. Please check inputs for potential abnormalities and try again.");
                        }
                        
                        break;

                    //VIEW EMPLOYEES
                    case "2":
                        while (true)
                        {
                            Console.WriteLine("\nVIEW EMPLOYEES");

                            string showBy;

                            Console.WriteLine("1 = SHOW ID LIST" +
                                              "\n2 = SHOW BY ID (TYPE IN EMPLOYEE ID)" +
                                              "\npress any other key to head back to menu.");
                            Console.Write("Enter: ");
                            showBy = Console.ReadLine();
                            if(showBy == "1")
                            {
                                empBL.dispIDList();
                            }
                            else if(showBy == "2")
                            {
                                empBL.dispSpecificEmployee();
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;

                    //UPDATE EMPLOYEES
                    case "3":
                        Console.WriteLine("\nUPDATE EMPLOYEES");

                        Console.Write("Enter Employee ID: ");
                        string searchID = Console.ReadLine();

                        Console.Write("First Name: "); firstName = Console.ReadLine();
                        Console.Write("Last Name: "); lastName = Console.ReadLine();
                        Console.Write("Middle Name: "); middleName = Console.ReadLine();
                        Console.Write("Suffix: "); suffix = Console.ReadLine();
                        Console.Write("Gender (F/M): "); gender = char.Parse(Console.ReadLine());
                        Console.Write("Birthdate: "); birthdate = Console.ReadLine();
                        Console.Write("Phone no.: "); phone = long.Parse(Console.ReadLine());
                        Console.Write("Email: "); email = Console.ReadLine();
                        Console.Write("Address: "); address = Console.ReadLine();
                        Console.Write("Position: "); position = Console.ReadLine();
                        Console.Write("Salary: PHP "); salary = float.Parse(Console.ReadLine());

                        bool updated = empBL.updateEmp(searchID, firstName, lastName, middleName, suffix,
                                       gender, birthdate, phone, email, address, position, salary);

                        if (updated)
                        {
                            Console.WriteLine("Employee information successfully updated.");
                        }
                        else
                        {
                            Console.WriteLine("Employee not updated. ID may not exist.");
                        }
                        break;

                    //TERMINATE EMPLOYEES
                    case "4":
                        Console.WriteLine("\nTERMINATE EMPLOYEES");

                        Console.Write("Enter Employee ID: ");
                        searchID = Console.ReadLine();

                        if (!empBL.EmployeeExists(searchID))
                        {
                            Console.WriteLine("Employee ID not found.");
                            break;
                        }

                        Console.Write($"Are you sure you want to terminate employee {searchID}? (Y/N): ");
                        string confirmation = Console.ReadLine();

                        if (confirmation.ToUpper() == "Y")
                        {
                            bool terminated = empBL.deleteEmp(searchID);

                            if (terminated)
                            {
                                Console.WriteLine("Employee information successfully terminated.");
                            }
                            else
                            {
                                Console.WriteLine("Employee not terminated. An error occurred.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Termination cancelled.");
                        }
                        break;

                    //SYSTEM EXIT
                    case "5":
                        Console.WriteLine("Exiting system...");
                        break;

                    default:
                        Console.WriteLine("Input may not have been a number or out of bounds. Please see options list and try again.");
                        break;
                }
            }

        }

    }
}
