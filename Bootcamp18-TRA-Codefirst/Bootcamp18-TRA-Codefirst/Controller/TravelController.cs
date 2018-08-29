using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_TRA_Codefirst.Models;

namespace Bootcamp18_TRA_Codefirst.Controller
{
    class TravelController
    {
        baseContext context = new baseContext();

        public void Menu()
        {
            int pilihan, input;
            do
            {
                Console.Clear();
                Console.WriteLine("==========================");
                Console.WriteLine("1. Get All");
                Console.WriteLine("2. Get By Id");
                Console.WriteLine("3. Insert");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.WriteLine("==========================");
                Console.Write("Pilih Action : ");
                pilihan = Convert.ToInt32(Console.ReadLine());

                switch (pilihan)
                {
                    case 1:
                        getAll();
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.Write("Masukan ID Travel yang ingin dicari : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        GetById2(input);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Insert();
                        //Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Write("Masukan ID Travel yang ingin di Update : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Update(input);
                        Console.ReadKey(true);
                        break;
                    case 5:
                        Console.Write("Masukan ID Travel yang ingin di Delete : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Delete(input);
                        Console.ReadKey(true);
                        break;
                    default: break;
                }
            } while (pilihan != 6);
        }

        public List<TRAVEL> getAll()
        {
            //var getAll = context.Travels.ToList();

            var getAll = from t in context.Travels.ToList() join u in context.Users.ToList()
                         on t.user_id equals u.user_id 
                         select t;

            Console.WriteLine("----------List Data Request TRA----------\n");
            foreach (TRAVEL travels in getAll)
            {
                Console.WriteLine("Nama User        : " + travels.Users.name);
                Console.WriteLine("Category         : " + travels.category_id);
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id               : " + travels.travel_id);
                Console.WriteLine("Departure Date   : " + travels.departure_date);
                Console.WriteLine("Arrival Date     : " + travels.arrival_date);
                Console.WriteLine("Destination      : " + travels.destination);
                Console.WriteLine("Status           : " + travels.status);
                Console.WriteLine("Total            : " + travels.total);
                Console.WriteLine("-------------------------");
            }

            return getAll.ToList();
        }

        public void Insert()
        {
            string destination, status ;
            DateTime departureDate, arrivalDate;
            int total,categoryId,userId;
            // inputan by user
            Console.Write("Masukkan Departure Date      : ");
            departureDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Arrival Date        : ");
            arrivalDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Destination         : ");
            destination = Console.ReadLine();
            Console.Write("Masukkan Status              : ");
            status = Console.ReadLine();
            Console.Write("Masukkan Total               : ");
            total = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Category            : ");
            categoryId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Id User             : ");
            userId = Convert.ToInt32(Console.ReadLine());
           
            TRAVEL travels = new TRAVEL()
            {
                departure_date = departureDate,
                arrival_date = arrivalDate,
                destination = destination,
                status = status,
                total = total,
                category_id = categoryId,
                user_id = userId

            };
            try
            {
                context.Travels.Add(travels);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public TRAVEL GetById(int input)
        {
            TRAVEL travels = context.Travels.Find(input);
            if (travels == null)
            {
                Console.Write("Id " + input + " Tidak Ada");

            }
            return travels;
        }

        public TRAVEL GetById2(int input)
        {
            TRAVEL travels = context.Travels.Find(input);

            var temp = from t in context.Travels.ToList()
                         join u in context.Users.ToList()
                         on t.user_id equals u.user_id
                         where t.travel_id == input
                         select t;
            
            if (travels == null)
            {
                Console.Write("Id " + input + " Tidak Ada");

            }
            else
            {
                Console.WriteLine("-------------------------\n");
                Console.WriteLine("Nama User        : " + travels.Users.name);
                Console.WriteLine("Category         : " + travels.category_id);
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id               : " + travels.travel_id);
                Console.WriteLine("Departure Date   : " + travels.departure_date);
                Console.WriteLine("Arrival Date     : " + travels.arrival_date);
                Console.WriteLine("Destination      : " + travels.destination);
                Console.WriteLine("Status           : " + travels.status);
                Console.WriteLine("Total            : " + travels.total);
                Console.WriteLine("-------------------------");
            }
            return travels;
        }

        public int Update(int input)
        {
            string destination, status;
            DateTime departureDate, arrivalDate;
            int total, categoryId;

            var temp = from t in context.Travels.ToList()
                          join u in context.Users.ToList()
                          on t.user_id equals u.user_id
                          where t.travel_id == input
                          select t;

            TRAVEL travels = context.Travels.Find(input);
            
            Console.WriteLine("--------Data sebelum di Update--------\n");
            Console.WriteLine("Nama User        : " + travels.Users.name);
            Console.WriteLine("Category         : " + travels.category_id);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Id               : " + travels.travel_id);
            Console.WriteLine("Departure Date   : " + travels.departure_date);
            Console.WriteLine("Arrival Date     : " + travels.arrival_date);
            Console.WriteLine("Destination      : " + travels.destination);
            Console.WriteLine("Status           : " + travels.status);
            Console.WriteLine("Total            : " + travels.total);
            Console.WriteLine("------------------------\n");

            // inputan by user
            Console.Write("Masukkan Departure Date      : ");
            departureDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Arrival Date        : ");
            arrivalDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Destination         : ");
            destination = Console.ReadLine();
            Console.Write("Masukkan Status              : ");
            status = Console.ReadLine();
            Console.Write("Masukkan Total               : ");
            total = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Category            : ");
            categoryId = Convert.ToInt32(Console.ReadLine());
            /*Console.Write("Masukkan Id User             : ");
            userId = Convert.ToInt32(Console.ReadLine());*/

            // proses save ke database


            TRAVEL tRAVEL = context.Travels.Find(input);

            tRAVEL.departure_date = departureDate;
            tRAVEL.arrival_date = arrivalDate;
            tRAVEL.destination = destination;
            tRAVEL.status = status;
            tRAVEL.total = total;
            tRAVEL.category_id = categoryId;


            context.Entry(tRAVEL).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("\n--------Data setelah di Update--------\n");
            Console.WriteLine("Nama User        : " + tRAVEL.Users.name);
            Console.WriteLine("Category         : " + tRAVEL.category_id);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Id               : " + tRAVEL.travel_id);
            Console.WriteLine("Departure Date   : " + tRAVEL.departure_date);
            Console.WriteLine("Arrival Date     : " + tRAVEL.arrival_date);
            Console.WriteLine("Destination      : " + tRAVEL.destination);
            Console.WriteLine("Status           : " + tRAVEL.status);
            Console.WriteLine("Total            : " + tRAVEL.total);
            Console.WriteLine("-------------------------");

            return input;
        }

        public int Delete(int input)
        {
            TRAVEL tRAVEL = context.Travels.Find(input);
            context.Entry(tRAVEL).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("Travel Request dengan ID " + input + " Berhasil terhapus!");
            return input;
        }
    }
}
