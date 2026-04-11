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
            string input;
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
                              "\nh - HELP" +
                              "\n\nSELECT: ");

                input = Console.ReadLine();
                inputForSelect = input.ToLower();

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

                    case "h":
                        seeHelp();
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

            if (empBL.isFieldEmpty(id))
            {
                Console.WriteLine("Error: ID cannot be empty. Hire cancelled.");
                return;
            }

            if (empBL.EmployeeExists(id))
            {
                Console.WriteLine("Error: Employee ID already exists. Hire cancelled.");
                return;
            }

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            if (empBL.isFieldEmpty(firstName))
            {
                Console.WriteLine("Error: First Name cannot be empty. Hire cancelled.");
                return;
            }

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            if (empBL.isFieldEmpty(lastName))
            {
                Console.WriteLine("Error: Last Name cannot be empty. Hire cancelled.");
                return;
            }

            Console.Write("Middle Name: ");
            string middleName = Console.ReadLine();

            Console.Write("Suffix (Jr., Sr., III, etc. - If applicable): ");
            string suffix = Console.ReadLine();

            Console.Write("Gender (F/M/Other (O)): ");
            char g = char.Parse(Console.ReadLine());
            char gender = char.ToUpper(g);
            if (!empBL.isGenderValid(gender))
            {
                Console.WriteLine("Error: Gender must be F, M or O. Hire cancelled.");
                return;
            }

            Console.Write("Birthdate (dd/mm/yyyy): ");
            string birthdate = Console.ReadLine();
            if (!empBL.isBirthdateValid(birthdate))
            {
                Console.WriteLine("Error: Invalid birthdate format. Use dd/mm/yyyy. Hire cancelled.");
                return;
            }

            Console.Write("Phone no.: ");
            long phone = long.Parse(Console.ReadLine());
            if (!empBL.isPhoneValid(phone))
            {
                Console.WriteLine("Error: Phone number must be at least 10 digits. Hire cancelled.");
                return;
            }

            Console.Write("Email: ");
            string email = Console.ReadLine();
            if (empBL.isFieldEmpty(email))
            {
                Console.WriteLine("Error: Email cannot be empty. Hire cancelled.");
                return;
            }
            if (!empBL.isEmailValid(email))
            {
                Console.WriteLine("Error: Invalid email format. Hire cancelled.");
                return;
            }

            Console.Write("Address: ");
            string address = Console.ReadLine();
            if (empBL.isFieldEmpty(address))
            {
                Console.WriteLine("Error: Address cannot be empty. Hire cancelled.");
                return;
            }

            Console.Write("Company Position: ");
            string position = Console.ReadLine();
            if (empBL.isFieldEmpty(position))
            {
                Console.WriteLine("Error: Position cannot be empty. Hire cancelled.");
                return;
            }

            Console.Write("Salary: PHP ");
            float salary = float.Parse(Console.ReadLine());

            if (!empBL.isSalaryValid(salary))
            {
                Console.WriteLine("Error: Salary must be at least PHP 5,000. Hire cancelled.");
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
            Console.WriteLine($"ID: {empToUpdate.ID} (CANNOT BE CHANGED)\n");
            Console.WriteLine($"(1) FIRST NAME: {empToUpdate.FirstName}");
            Console.WriteLine($"(2) LAST NAME: {empToUpdate.LastName}");
            Console.WriteLine($"(3) MIDDLE NAME: {empToUpdate.MiddleName}");
            Console.WriteLine($"(4) SUFFIX: {empToUpdate.Suffix}");
            Console.WriteLine($"(5) GENDER: {empToUpdate.Gender}");
            Console.WriteLine($"(6) BIRTHDATE: {empToUpdate.Birthdate}");
            Console.WriteLine($"(7) PHONE: {empToUpdate.Phone}");
            Console.WriteLine($"(8) EMAIL: {empToUpdate.Email}");
            Console.WriteLine($"(9) ADDRESS: {empToUpdate.Address}");
            Console.WriteLine($"(10) POSITION: {empToUpdate.Position}");
            Console.WriteLine($"(11) SALARY: PHP {empToUpdate.Salary}");

            Console.WriteLine("\nUPDATE OPTIONS:");
            Console.WriteLine("Enter 1-11 to update a specific field");
            Console.WriteLine("A - UPDATE ALL FIELDS (EXCLUDING ID)");
            Console.WriteLine("ANY OTHER KEY - EXIT TO MAIN MENU");
            Console.Write("SELECT: ");

            string updateChoice = Console.ReadLine().ToUpper();

            if (updateChoice == "A") //ALL FIELDS
            {
                Console.WriteLine("\nENTER NEW INFORMATION");

                Console.Write($"First Name ({empToUpdate.FirstName}): ");
                string newFirstName = Console.ReadLine();
                if (empBL.isFieldEmpty(newFirstName))
                {
                    Console.WriteLine("Error: First Name cannot be empty. Update cancelled.");
                    return;
                }
                empToUpdate.FirstName = newFirstName;

                Console.Write($"Last Name ({empToUpdate.LastName}): ");
                string newLastName = Console.ReadLine();
                if (empBL.isFieldEmpty(newLastName))
                {
                    Console.WriteLine("Error: Last Name cannot be empty. Update cancelled.");
                    return;
                }
                empToUpdate.LastName = newLastName;

                Console.Write($"Middle Name ({empToUpdate.MiddleName}): ");
                empToUpdate.MiddleName = Console.ReadLine();

                Console.Write($"Suffix ({empToUpdate.Suffix}): ");
                empToUpdate.Suffix = Console.ReadLine();

                Console.Write($"Gender ({empToUpdate.Gender}): ");
                char g = char.Parse(Console.ReadLine());
                char gender = char.ToUpper(g);
                if (!empBL.isGenderValid(gender))
                {
                    Console.WriteLine("Error: Gender must be F, M or O. Update cancelled.");
                    return;
                }
                empToUpdate.Gender = gender;

                Console.Write($"Birthdate ({empToUpdate.Birthdate}): ");
                string newBirthdate = Console.ReadLine();
                if (!empBL.isBirthdateValid(newBirthdate))
                {
                    Console.WriteLine("Error: Invalid birthdate format. Use dd/mm/yyyy. Update cancelled.");
                    return;
                }
                empToUpdate.Birthdate = newBirthdate;

                Console.Write($"Phone ({empToUpdate.Phone}): ");
                long newPhone = long.Parse(Console.ReadLine());
                if (!empBL.isPhoneValid(newPhone))
                {
                    Console.WriteLine("Error: Phone number must be at least 10 digits. Update cancelled.");
                    return;
                }
                empToUpdate.Phone = newPhone;

                Console.Write($"Email ({empToUpdate.Email}): ");
                string newEmail = Console.ReadLine();
                if (empBL.isFieldEmpty(newEmail))
                {
                    Console.WriteLine("Error: Email cannot be empty. Update cancelled.");
                    return;
                }
                if (!empBL.isEmailValid(newEmail))
                {
                    Console.WriteLine("Error: Invalid email format. Update cancelled.");
                    return;
                }
                empToUpdate.Email = newEmail;

                Console.Write($"Address ({empToUpdate.Address}): ");
                string newAddress = Console.ReadLine();
                if (empBL.isFieldEmpty(newAddress))
                {
                    Console.WriteLine("Error: Address cannot be empty. Update cancelled.");
                    return;
                }
                empToUpdate.Address = newAddress;

                Console.Write($"Position ({empToUpdate.Position}): ");
                string newPosition = Console.ReadLine();
                if (empBL.isFieldEmpty(newPosition))
                {
                    Console.WriteLine("Error: Position cannot be empty. Update cancelled.");
                    return;
                }
                empToUpdate.Position = newPosition;

                Console.Write($"Salary ({empToUpdate.Salary}): ");
                float newSalary = float.Parse(Console.ReadLine());
                if (!empBL.isSalaryValid(newSalary))
                {
                    Console.WriteLine("Error: Salary must be at least PHP 5,000. Update cancelled.");
                    return;
                }
                empToUpdate.Salary = newSalary;

                empBL.updateEmp(empToUpdate);
                Console.WriteLine("Employee information successfully updated.");
            }
            else if (updateChoice == "1" || updateChoice == "2" || updateChoice == "3" ||
                     updateChoice == "4" || updateChoice == "5" || updateChoice == "6" ||
                     updateChoice == "7" || updateChoice == "8" || updateChoice == "9" ||
                     updateChoice == "10" || updateChoice == "11")
            {
                switch (updateChoice)
                {
                    case "1":
                        Console.Write($"Enter new First Name ({empToUpdate.FirstName}): ");
                        string newFirstName = Console.ReadLine();
                        if (empBL.isFieldEmpty(newFirstName))
                        {
                            Console.WriteLine("Error: First Name cannot be empty. Update cancelled.");
                            return;
                        }
                        empToUpdate.FirstName = newFirstName;
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("First Name successfully updated.");
                        break;
                    case "2":
                        Console.Write($"Enter new Last Name ({empToUpdate.LastName}): ");
                        string newLastName = Console.ReadLine();
                        if (empBL.isFieldEmpty(newLastName))
                        {
                            Console.WriteLine("Error: Last Name cannot be empty. Update cancelled.");
                            return;
                        }
                        empToUpdate.LastName = newLastName;
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Last Name successfully updated.");
                        break;
                    case "3":
                        Console.Write($"Enter new Middle Name ({empToUpdate.MiddleName}): ");
                        empToUpdate.MiddleName = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Middle Name successfully updated.");
                        break;
                    case "4":
                        Console.Write($"Enter new Suffix ({empToUpdate.Suffix}): ");
                        empToUpdate.Suffix = Console.ReadLine();
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Suffix successfully updated.");
                        break;
                    case "5":
                        Console.Write($"Enter new Gender ({empToUpdate.Gender}): ");
                        char g = char.Parse(Console.ReadLine());
                        char gender = char.ToUpper(g);
                        if (!empBL.isGenderValid(gender))
                        {
                            Console.WriteLine("Error: Gender must be F, M or O. Update cancelled.");
                            return;
                        }
                        empToUpdate.Gender = gender;
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Gender successfully updated.");
                        break;
                    case "6":
                        Console.Write($"Enter new Birthdate ({empToUpdate.Birthdate}): ");
                        string newBirthdate = Console.ReadLine();
                        if (!empBL.isBirthdateValid(newBirthdate))
                        {
                            Console.WriteLine("Error: Invalid birthdate format. Use dd/mm/yyyy. Update cancelled.");
                            return;
                        }
                        empToUpdate.Birthdate = newBirthdate;
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Birthdate successfully updated.");
                        break;
                    case "7":
                        Console.Write($"Enter new Phone ({empToUpdate.Phone}): ");
                        long newPhone = long.Parse(Console.ReadLine());
                        if (!empBL.isPhoneValid(newPhone))
                        {
                            Console.WriteLine("Error: Phone number must be at least 10 digits. Update cancelled.");
                            return;
                        }
                        empToUpdate.Phone = newPhone;
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Phone successfully updated.");
                        break;
                    case "8":
                        Console.Write($"Enter new Email ({empToUpdate.Email}): ");
                        string newEmail = Console.ReadLine();
                        if (empBL.isFieldEmpty(newEmail))
                        {
                            Console.WriteLine("Error: Email cannot be empty. Update cancelled.");
                            return;
                        }
                        if (!empBL.isEmailValid(newEmail))
                        {
                            Console.WriteLine("Error: Invalid email format. Update cancelled.");
                            return;
                        }
                        empToUpdate.Email = newEmail;
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Email successfully updated.");
                        break;
                    case "9":
                        Console.Write($"Enter new Address ({empToUpdate.Address}): ");
                        string newAddress = Console.ReadLine();
                        if (empBL.isFieldEmpty(newAddress))
                        {
                            Console.WriteLine("Error: Address cannot be empty. Update cancelled.");
                            return;
                        }
                        empToUpdate.Address = newAddress;
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Address successfully updated.");
                        break;
                    case "10":
                        Console.Write($"Enter new Position ({empToUpdate.Position}): ");
                        string newPosition = Console.ReadLine();
                        if (empBL.isFieldEmpty(newPosition))
                        {
                            Console.WriteLine("Error: Position cannot be empty. Update cancelled.");
                            return;
                        }
                        empToUpdate.Position = newPosition;
                        empBL.updateEmp(empToUpdate);
                        Console.WriteLine("Position successfully updated.");
                        break;
                    case "11":
                        Console.Write($"Enter new Salary ({empToUpdate.Salary}): ");
                        float newSalary = float.Parse(Console.ReadLine());
                        if (!empBL.isSalaryValid(newSalary))
                        {
                            Console.WriteLine("Error: Salary must be at least PHP 5,000. Update cancelled.");
                            return;
                        }
                        empToUpdate.Salary = newSalary;
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

        static void seeHelp()
        {
            Console.WriteLine("\nHELP - EMPLOYEE MANAGEMENT SYSTEM");
            Console.WriteLine("This is a tool designed to help with employee management.");
            Console.WriteLine("1 - HIRE EMPLOYEES: Add new employees to the system by providing their details.");
            Console.WriteLine("2 - VIEW EMPLOYEES: View a list of employee IDs or details of a specific employee by ID.");
            Console.WriteLine("                    (1) View all employee IDs");
            Console.WriteLine("                    (2) View details of a specific employee by ID");
            Console.WriteLine("                    USE ANY OTHER KEY TO RETURN.");
            Console.WriteLine("3 - UPDATE EMPLOYEES: Update the information of an existing employee by ID.");
            Console.WriteLine("                    (1-11) Update a specific field.");
            Console.WriteLine("                    (A) Update all fields sequentially.");
            Console.WriteLine("                    USE ANY OTHER KEY TO RETURN.");
            Console.WriteLine("4 - TERMINATE EMPLOYEES: Remove an employee from the system by ID.");
            Console.WriteLine("                    (y/n) Confirmation of employee termination command.");
            Console.WriteLine("5 - EXIT SYSTEM: Exit the application.");
            Console.WriteLine("h - HELP: View this list.");
        }
    }
}