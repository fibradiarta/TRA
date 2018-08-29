using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_TRA_Codefirst.Controller;

namespace Bootcamp18_TRA_Codefirst
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("=======MENU=======");
                Console.WriteLine("1. User");
                Console.WriteLine("2. Role");
                Console.WriteLine("3. Departments");
                Console.WriteLine("4. Exit");
                Console.WriteLine("==================");
                Console.Write("Pilih Action : ");
                choice = Convert.ToInt32(System.Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UserController callUser = new UserController();
                        callUser.Menu();
                        break;
                    case 2:
                        RoleController callRole = new RoleController();
                        callRole.Menu();
                        break;
                    case 3:
                        DepartmentController callDepartments = new DepartmentController();
                        callDepartments.Menu();
                        break;
                    default:
                        System.Console.Write("Exit Cuy!");
                        System.Console.Read();
                        break;
                }
            } while (choice != 4);
        }
    }
}
