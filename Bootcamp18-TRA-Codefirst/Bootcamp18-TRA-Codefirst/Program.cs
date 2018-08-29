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
                Console.WriteLine("4. Type");
                Console.WriteLine("5. Category");
                Console.WriteLine("6. Travel");
                Console.WriteLine("7. Hotel Cost");
                Console.WriteLine("8. Transport Cost");
                Console.WriteLine("9. Exit");
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
                    case 4:
                        TypeController callType = new TypeController();
                        callType.Menu();
                        break;
                    case 5:
                        CategoryController callCategory = new CategoryController();
                        callCategory.Menu();
                        break;
                    case 6:
                        TravelController callTravel = new TravelController();
                        callTravel.Menu();
                        break;
                    case 7:
                        HotelCostController callHotelCost = new HotelCostController();
                        callHotelCost.Menu();
                        break;
                    case 8:
                        TransportController callTransprotCost = new TransportController();
                        callTransprotCost.Menu();
                        break;
                    default:
                        System.Console.Write("Exit Cuy!");
                        System.Console.Read();
                        break;
                }
            } while (choice != 9);
        }
    }
}
