namespace employeeInformation
{
    internal class Program
    {
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
                        //system exit command.
                        break;
                    default:
                        Console.WriteLine("Input not recognized. Please see options list.");
                        break;
                }
            }

        }

        static void addEmp()
        {

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
