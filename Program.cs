using employeeAppService;
using employeeModels;
using System;
using System.Collections.Generic;

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
                    case "1":
                        hireEmp();
                        break;

                    case "2":
                        viewEmp();
                        break;

                    case "3":
                        updateEmp();
                        break;

                    case "4":
                        terminateEmp();
                        break;

                    case "5":
                        Console.WriteLine("Exiting system...");
                        break;

                    default:
                        Console.WriteLine("Input may not have been a number or out of bounds. Please see options list and try again.");
                        break;
                }
            }
        }

        static void hireEmp()
        {
            Console.WriteLine("\nHIRE EMPLOYEE");

            Console.Write("ID: ");
            string id = Console.ReadLine();

            if (empBL.EmployeeExists(id))
            {
                Console.WriteLine("Error: Employee ID already exists. Hire cancelled.");
                return;
            }

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Middle Name: ");
            string middleName = Console.ReadLine();
            Console.Write("Suffix (Jr., Sr., III, etc. - If applicable): ");
            string suffix = Console.ReadLine();
            Console.Write("Gender (F/M): ");
            char g = char.Parse(Console.ReadLine());
            char gender = char.ToUpper(g);
            Console.Write("Birthdate (dd/mm/yyyy): ");
            string birthdate = Console.ReadLine();
            Console.Write("Phone no.: ");
            long phone = long.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Company Position: ");
            string position = Console.ReadLine();
            Console.Write("Salary: PHP ");
            float salary = float.Parse(Console.ReadLine());

            bool isValidPay = empBL.payValidity(salary);

            if (!isValidPay)
            {
                Console.WriteLine("Error: Salary must be greater than 0. Update cancelled.");
                return;
            }

            bool hired = empBL.addEmp(id, firstName, lastName, middleName, suffix,
                         gender, birthdate, phone, email, address, position, salary);

            if (hired)
            {
                Console.WriteLine("Employee added.");
            }
            else
            {
                Console.WriteLine("Employee not added. Please check inputs for potential abnormalities and try again.");
            }
        }

        static void viewEmp()
        {
            while (true)
            {
                Console.WriteLine("\nVIEW EMPLOYEES");

                Console.WriteLine("1 = SHOW ID LIST" +
                                  "\n2 = SHOW BY ID (TYPE IN EMPLOYEE ID)" +
                                  "\npress any other key to head back to menu.");
                Console.Write("Enter: ");
                string showBy = Console.ReadLine();

                if (showBy == "1")
                {
                    Console.WriteLine("\nEMPLOYEE IDS:");
                    List<Employee> employees = empBL.GetAllEmployees();

                    for (int i = 0; i < employees.Count; i++)
                    {
                        Console.WriteLine(employees[i].ID);
                    }
                }
                else if (showBy == "2")
                {
                    Console.Write("\nEnter Employee ID: ");
                    string sID = Console.ReadLine();

                    Employee e = empBL.GetEmployeeById(sID);

                    if (e != null)
                    {
                        Console.WriteLine("\nEMPLOYEE DETAILS");
                        Console.WriteLine($"ID: {e.ID}");
                        Console.WriteLine($"FIRST NAME: {e.FirstName}");
                        Console.WriteLine($"LAST NAME: {e.LastName}");
                        Console.WriteLine($"MIDDLE NAME: {e.MiddleName}");
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
                        Console.WriteLine("Employee ID not found. Refer to full ID list in VIEW EMPLOYEES by typing in '1'");
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void updateEmp()
        {
            Console.WriteLine("\nUPDATE EMPLOYEES");

            Console.Write("Enter Employee ID: ");
            string updateID = Console.ReadLine();

            if (!empBL.EmployeeExists(updateID))
            {
                Console.WriteLine("Employee ID not found.");
                return;
            }

            Employee empToUpdate = empBL.GetEmployeeById(updateID);

            Console.WriteLine("\n=== CURRENT EMPLOYEE INFORMATION ===");
            Console.WriteLine($"(1) ID: {empToUpdate.ID}\n");
            Console.WriteLine($"(2) FIRST NAME: {empToUpdate.FirstName}");
            Console.WriteLine($"(3) LAST NAME: {empToUpdate.LastName}");
            Console.WriteLine($"(4) MIDDLE NAME: {empToUpdate.MiddleName}");
            Console.WriteLine($"(5) SUFFIX: {empToUpdate.Suffix}");
            Console.WriteLine($"(6) GENDER: {empToUpdate.Gender}");
            Console.WriteLine($"(7) BIRTHDATE: {empToUpdate.Birthdate}");
            Console.WriteLine($"(8) PHONE: {empToUpdate.Phone}");
            Console.WriteLine($"(9) EMAIL: {empToUpdate.Email}");
            Console.WriteLine($"(10) ADDRESS: {empToUpdate.Address}");
            Console.WriteLine($"(11) POSITION: {empToUpdate.Position}");
            Console.WriteLine($"(12) SALARY: PHP {empToUpdate.Salary}");

            Console.WriteLine("\nUPDATE OPTIONS:");
            Console.WriteLine("Enter 1-12 to update a specific field");
            Console.WriteLine("A - UPDATE ALL FIELDS");
            Console.WriteLine("ANY OTHER KEY - EXIT TO MAIN MENU");
            Console.Write("SELECT: ");

            string updateChoice = Console.ReadLine().ToUpper();

            if (updateChoice == "A") //ALL FIELDS
            {
                Console.WriteLine("\nENTER NEW INFORMATION");
                Console.Write($"First Name ({empToUpdate.FirstName}): "); empToUpdate.FirstName = Console.ReadLine();
                Console.Write($"Last Name ({empToUpdate.LastName}): "); empToUpdate.LastName = Console.ReadLine();
                Console.Write($"Middle Name ({empToUpdate.MiddleName}): "); empToUpdate.MiddleName = Console.ReadLine();
                Console.Write($"Suffix ({empToUpdate.Suffix}): "); empToUpdate.Suffix = Console.ReadLine();

                Console.Write($"Gender ({empToUpdate.Gender}): ");
                char g = char.Parse(Console.ReadLine());
                char gender = char.ToUpper(g);
                empToUpdate.Gender = gender;

                Console.Write($"Birthdate ({empToUpdate.Birthdate}): "); empToUpdate.Birthdate = Console.ReadLine();
                Console.Write($"Phone ({empToUpdate.Phone}): "); empToUpdate.Phone = long.Parse(Console.ReadLine());
                Console.Write($"Email ({empToUpdate.Email}): "); empToUpdate.Email = Console.ReadLine();
                Console.Write($"Address ({empToUpdate.Address}): "); empToUpdate.Address = Console.ReadLine();
                Console.Write($"Position ({empToUpdate.Position}): "); empToUpdate.Position = Console.ReadLine();
                Console.Write($"Salary ({empToUpdate.Salary}): "); empToUpdate.Salary = float.Parse(Console.ReadLine());

                bool isValidPay = empBL.payValidity(empToUpdate.Salary);

                if (!isValidPay)
                {
                    Console.WriteLine("Error: Salary must be greater than 0. Update cancelled.");
                    return;
                }

                empBL.updateEmp(empToUpdate);
                Console.WriteLine("Employee information successfully updated.");
            }
            else if (updateChoice == "1" || updateChoice == "2" || updateChoice == "3" ||
                     updateChoice == "4" || updateChoice == "5" || updateChoice == "6" ||
                     updateChoice == "7" || updateChoice == "8" || updateChoice == "9" ||
                     updateChoice == "10" || updateChoice == "11" || updateChoice == "12")
            {
                switch (updateChoice)
                {
                    case "1":
                        Console.Write($"Enter new ID ({empToUpdate.ID}): ");
                        string newID = Console.ReadLine();
                        if (empBL.EmployeeExists(newID))
                        {
                            Console.WriteLine("Error: ID already exists. Update cancelled.");
                        }
                        else
                        {
                            empToUpdate.ID = newID;
                            empBL.updateEmp(empToUpdate);
                            Console.WriteLine("ID successfully updated.");
                        }
                        break;
                    case "2":
                        Console.Write($"Enter new First Name ({empToUpdate.FirstName}): ");
                        empToUpdate.FirstName = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("First Name successfully updated.");
                        break;
                    case "3":
                        Console.Write($"Enter new Last Name ({empToUpdate.LastName}): ");
                        empToUpdate.LastName = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Last Name successfully updated.");
                        break;
                    case "4":
                        Console.Write($"Enter new Middle Name ({empToUpdate.MiddleName}): ");
                        empToUpdate.MiddleName = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Middle Name successfully updated.");
                        break;
                    case "5":
                        Console.Write($"Enter new Suffix ({empToUpdate.Suffix}): ");
                        empToUpdate.Suffix = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Suffix successfully updated.");
                        break;
                    case "6":
                        Console.Write($"Enter new Gender ({empToUpdate.Gender}): ");
                        char g = char.Parse(Console.ReadLine());
                        char gender = char.ToUpper(g);
                        empToUpdate.Gender = gender;
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Gender successfully updated.");
                        break;
                    case "7":
                        Console.Write($"Enter new Birthdate ({empToUpdate.Birthdate}): ");
                        empToUpdate.Birthdate = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Birthdate successfully updated.");
                        break;
                    case "8":
                        Console.Write($"Enter new Phone ({empToUpdate.Phone}): ");
                        empToUpdate.Phone = long.Parse(Console.ReadLine());
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Phone successfully updated.");
                        break;
                    case "9":
                        Console.Write($"Enter new Email ({empToUpdate.Email}): ");
                        empToUpdate.Email = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Email successfully updated.");
                        break;
                    case "10":
                        Console.Write($"Enter new Address ({empToUpdate.Address}): ");
                        empToUpdate.Address = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Address successfully updated.");
                        break;
                    case "11":
                        Console.Write($"Enter new Position ({empToUpdate.Position}): ");
                        empToUpdate.Position = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Position successfully updated.");
                        break;
                    case "12":
                        Console.Write($"Enter new Salary ({empToUpdate.Salary}): ");
                        empToUpdate.Salary = float.Parse(Console.ReadLine());

                        bool isValidPay = empBL.payValidity(empToUpdate.Salary);
                        
                        if (!isValidPay)
                        {
                            Console.WriteLine("Error: Salary must be greater than 0. Update cancelled.");
                            return;
                        }

                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Salary successfully updated.");
                        break;
                }
            }
            else
            {
                return;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void terminateEmp()
        {
            Console.WriteLine("\nTERMINATE EMPLOYEES");

            Console.Write("Enter Employee ID: ");
            string searchID = Console.ReadLine();

            if (!empBL.EmployeeExists(searchID))
            {
                Console.WriteLine("Employee ID not found. Cannot be terminated.");
                return;
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
        }
    }
}