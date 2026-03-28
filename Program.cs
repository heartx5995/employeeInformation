using System;
using System.Collections.Generic;

namespace employeeInformation
{
    internal class Program
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
                inputForSelect.ToLower();

                switch (inputForSelect)
                {
                    case "1":
                        empBL.addEmp();
                        break;
                    case "2":
                        empBL.dispEmp();
                        break;
                    case "3":
                        empBL.updateEmp();
                        break;
                    case "4":
                        empBL.delEmp();
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

    }
}
