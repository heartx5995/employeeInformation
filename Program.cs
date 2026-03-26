using System;
using System.Collections.Generic;

namespace employeeInformation
{
    internal class Program
    {
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

    }
}