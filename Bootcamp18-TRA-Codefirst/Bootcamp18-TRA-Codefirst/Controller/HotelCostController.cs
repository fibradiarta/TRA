using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_TRA_Codefirst.Models;

namespace Bootcamp18_TRA_Codefirst.Controller
{
    class HotelCostController
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
                        Console.Write("Masukan ID Hotel yang ingin dicari : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        GetById2(input);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Insert();
                        //Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Write("Masukan ID Hotel yang ingin di Update : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Update(input);
                        Console.ReadKey(true);
                        break;
                    case 5:
                        Console.Write("Masukan ID Hotel yang ingin di Delete : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        //Delete(input);
                        Console.ReadKey(true);
                        break;
                    default: break;
                }
            } while (pilihan != 6);
        }

        public List<HOTEL_COST> getAll()
        {
            //var getAll = context.Travels.ToList();

            var getAll = from h in context.Hotel_Costs.ToList()
                         join t in context.Travels.ToList()
                         on h.travel_id equals t.travel_id
                         select h;

            Console.WriteLine("----------List Hotel Cost TRA Request----------\n");
            foreach (HOTEL_COST hotel_costs in getAll)
            {
                Console.WriteLine("ID Travel        : " + hotel_costs.travel_id);
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id           : " + hotel_costs.hotel_id);
                Console.WriteLine("Name Hotel   : " + hotel_costs.name);
                Console.WriteLine("Cost Hotel   : " + hotel_costs.cost);
                Console.WriteLine("Attachment   : " + hotel_costs.attachment);
                Console.WriteLine("Date Checkin : " + hotel_costs.date_checkin);
                Console.WriteLine("Date Checkout: " + hotel_costs.date_checkout);
                Console.WriteLine("-------------------------");
            }

            return getAll.ToList();
        }

        public void Insert()
        {
            string nama, attachment;
            DateTime dateCheckin, dateCheckout;
            int harga, travel;
            // inputan by user
            Console.Write("Masukkan Nama Hotel      : ");
            nama = Console.ReadLine();
            Console.Write("Masukkan Cost Hotel      : ");
            harga = Convert.ToInt32(Console.ReadLine());
            Console.Write("Attachment               : ");
            attachment = Console.ReadLine();
            Console.Write("Masukkan Date Checkin    : ");
            dateCheckin = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Date Checkout   : ");
            dateCheckout = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan ID Travel       : ");
            travel = Convert.ToInt32(Console.ReadLine());


            HOTEL_COST hotel_costs = new HOTEL_COST()
            {
                name = nama,
                cost = harga,
                attachment = attachment,
                date_checkin = dateCheckin,
                date_checkout = dateCheckout,
                travel_id = travel
            };
            try
            {
                context.Hotel_Costs.Add(hotel_costs);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public HOTEL_COST GetById(int input)
        {
            HOTEL_COST hotel_costs = context.Hotel_Costs.Find(input);
            if (hotel_costs == null)
            {
                Console.Write("Id " + input + " Tidak Ada");

            }
            return hotel_costs;
        }

        public HOTEL_COST GetById2(int input)
        {
            HOTEL_COST hotel_costs = context.Hotel_Costs.Find(input);

            var temp = from h in context.Hotel_Costs.ToList()
                       join t in context.Travels.ToList()
                       on h.travel_id equals t.travel_id
                       select h;

            if (hotel_costs == null)
            {
                Console.Write("Id " + input + " Tidak Ada");

            }
            else
            {
                Console.WriteLine("\nID Travel        : " + hotel_costs.travel_id);
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id           : " + hotel_costs.hotel_id);
                Console.WriteLine("Name Hotel   : " + hotel_costs.name);
                Console.WriteLine("Cost Hotel   : " + hotel_costs.cost);
                Console.WriteLine("Attachment   : " + hotel_costs.attachment);
                Console.WriteLine("Date Checkin : " + hotel_costs.date_checkin);
                Console.WriteLine("Date Checkout: " + hotel_costs.date_checkout);
                Console.WriteLine("-------------------------");
            }
            return hotel_costs;
        }

        public int Update(int input)
        {
            string nama, attachment;
            DateTime dateCheckin, dateCheckout;
            int harga;

            var temp = from h in context.Hotel_Costs.ToList()
                       join t in context.Travels.ToList()
                       on h.travel_id equals t.travel_id
                       where h.hotel_id == input
                       select h;

            HOTEL_COST hotel_costs = context.Hotel_Costs.Find(input);

            Console.WriteLine("------------Data sebelum di Update-------------");
            Console.WriteLine("\nID Travel        : " + hotel_costs.travel_id);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Id           : " + hotel_costs.hotel_id);
            Console.WriteLine("Name Hotel   : " + hotel_costs.name);
            Console.WriteLine("Cost Hotel   : " + hotel_costs.cost);
            Console.WriteLine("Attachment   : " + hotel_costs.attachment);
            Console.WriteLine("Date Checkin : " + hotel_costs.date_checkin);
            Console.WriteLine("Date Checkout: " + hotel_costs.date_checkout);
            Console.WriteLine("-------------------------");

            // inputan by user
            Console.Write("\nMasukkan Nama Hotel      : ");
            nama = Console.ReadLine();
            Console.Write("Masukkan Cost Hotel      : ");
            harga = Convert.ToInt32(Console.ReadLine());
            Console.Write("Attachment               : ");
            attachment = Console.ReadLine();
            Console.Write("Masukkan Date Checkin    : ");
            dateCheckin = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Date Checkout   : ");
            dateCheckout = Convert.ToDateTime(Console.ReadLine());


            HOTEL_COST hOTEL_COST = GetById(input);

            hOTEL_COST.name = nama;
            hOTEL_COST.cost = harga;
            hOTEL_COST.attachment = attachment;
            hOTEL_COST.date_checkin = dateCheckin;
            hOTEL_COST.date_checkout = dateCheckout;
            
            
            context.Entry(hOTEL_COST).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("------------Data sesudah di Update-------------");
            Console.WriteLine("\nID Travel        : " + hotel_costs.travel_id);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Id           : " + hotel_costs.hotel_id);
            Console.WriteLine("Name Hotel   : " + hotel_costs.name);
            Console.WriteLine("Cost Hotel   : " + hotel_costs.cost);
            Console.WriteLine("Attachment   : " + hotel_costs.attachment);
            Console.WriteLine("Date Checkin : " + hotel_costs.date_checkin);
            Console.WriteLine("Date Checkout: " + hotel_costs.date_checkout);
            Console.WriteLine("----------------------------------------------");

            return input;
        }

        public int Delete(int input)
        {
            HOTEL_COST hOTEL_COST = context.Hotel_Costs.Find(input);
            context.Entry(hOTEL_COST).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("Hotel Cost dengan ID " + input + " Berhasil terhapus!");
            return input;
        }
    }
}
