using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_TRA_Codefirst.Models;

namespace Bootcamp18_TRA_Codefirst.Controller
{
    class TransportController
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
                        Console.Write("Masukan ID Transport yang ingin dicari : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        GetById2(input);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Insert();
                        //Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Write("Masukan ID Transport yang ingin di Update : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Update(input);
                        Console.ReadKey(true);
                        break;
                    case 5:
                        Console.Write("Masukan ID Transport yang ingin di Delete : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Delete(input);
                        Console.ReadKey(true);
                        break;
                    default: break;
                }
            } while (pilihan != 6);
        }

        public List<TRANSPORT_COST> getAll()
        {
            //var getAll = context.Travels.ToList();

            var getAll = from tc in context.Transport_Costs.ToList()
                         join t in context.Travels.ToList()
                         on tc.travel_id equals t.travel_id
                         join ty in context.Tipes.ToList()
                         on tc.type_id equals ty.type_id
                         select tc;

            Console.WriteLine("----------List Transport Cost TRA Request----------\n");
            foreach (TRANSPORT_COST transport_costs in getAll)
            {
                Console.WriteLine("ID Travel        : " + transport_costs.travel_id);
                Console.WriteLine("ID Type          : " + transport_costs.type_id);
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id               : " + transport_costs.transport_id);
                Console.WriteLine("Cost Transport   : " + transport_costs.cost);
                Console.WriteLine("Attachment       : " + transport_costs.attachment);
                Console.WriteLine("Date             : " + transport_costs.date);
                Console.WriteLine("-------------------------");
            }

            return getAll.ToList();
        }

        public void Insert()
        {
            string attachment;
            DateTime date;
            int harga, travel, types;
            // inputan by user

            Console.Write("Masukkan ID Travel       : ");
            travel = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan ID Type         : ");
            types = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Cost Transport  : ");
            harga = Convert.ToInt32(Console.ReadLine());
            Console.Write("Attachment               : ");
            attachment = Console.ReadLine();
            Console.Write("Masukkan Date            : ");
            date = Convert.ToDateTime(Console.ReadLine());
           


            TRANSPORT_COST transport_costs = new TRANSPORT_COST()
            {
                cost = harga,
                attachment = attachment,
                date = date,
                travel_id = travel,
                type_id = types
            };
            try
            {
                context.Transport_Costs.Add(transport_costs);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public TRANSPORT_COST GetById(int input)
        {
            TRANSPORT_COST transport_costs = context.Transport_Costs.Find(input);
            if (transport_costs == null)
            {
                Console.Write("Id " + input + " Tidak Ada");

            }
            return transport_costs;
        }

        public TRANSPORT_COST GetById2(int input)
        {
            TRANSPORT_COST transport_costs = context.Transport_Costs.Find(input);

            var temp = from tc in context.Transport_Costs.ToList()
                       join t in context.Travels.ToList()
                       on tc.travel_id equals t.travel_id
                       join ty in context.Tipes.ToList()
                       on tc.type_id equals ty.type_id
                       where tc.transport_id == input
                       select tc;

            if (transport_costs == null)
            {
                Console.Write("Id " + input + " Tidak Ada");

            }
            else
            {
                Console.WriteLine("\nID Travel        : " + transport_costs.travel_id);
                Console.WriteLine("ID Type          : " + transport_costs.type_id);
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id               : " + transport_costs.transport_id);
                Console.WriteLine("Cost Transport   : " + transport_costs.cost);
                Console.WriteLine("Attachment       : " + transport_costs.attachment);
                Console.WriteLine("Date             : " + transport_costs.date);
                Console.WriteLine("-------------------------");
            }
            return transport_costs;
        }

        public int Update(int input)
        {
            string attachment;
            DateTime date;
            int harga, types;
            // inputan by user

            var temp = from tc in context.Transport_Costs.ToList()
                       join t in context.Travels.ToList()
                       on tc.travel_id equals t.travel_id
                       join ty in context.Tipes.ToList()
                       on tc.type_id equals ty.type_id
                       select tc;
            TRANSPORT_COST transport_costs = context.Transport_Costs.Find(input);

            Console.WriteLine("------------Data sebelum di Update-------------");
            Console.WriteLine("\nID Travel        : " + transport_costs.travel_id);
            Console.WriteLine("ID Type          : " + transport_costs.type_id);
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("Id               : " + transport_costs.transport_id);
            Console.WriteLine("Cost Transport   : " + transport_costs.cost);
            Console.WriteLine("Attachment       : " + transport_costs.attachment);
            Console.WriteLine("Date             : " + transport_costs.date);
            Console.WriteLine("-------------------------");

            Console.Write("\nMasukkan Cost Transport  : ");
            harga = Convert.ToInt32(Console.ReadLine());
            Console.Write("Attachment               : ");
            attachment = Console.ReadLine();
            Console.Write("Masukkan Date            : ");
            date = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan ID Type       : ");
            types = Convert.ToInt32(Console.ReadLine());


            TRANSPORT_COST tRANSPORT_COST = context.Transport_Costs.Find(input);
            tRANSPORT_COST.cost = harga;
            tRANSPORT_COST.attachment = attachment;
            tRANSPORT_COST.date = date;
            tRANSPORT_COST.type_id = types;
            
            context.Entry(tRANSPORT_COST).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("\n------------Data sesudah di Update-------------");
            Console.WriteLine("\nID Travel        : " + tRANSPORT_COST.travel_id);
            Console.WriteLine("ID Type          : " + tRANSPORT_COST.type_id);
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("Id               : " + tRANSPORT_COST.transport_id);
            Console.WriteLine("Cost Transport   : " + tRANSPORT_COST.cost);
            Console.WriteLine("Attachment       : " + tRANSPORT_COST.attachment);
            Console.WriteLine("Date             : " + tRANSPORT_COST.date);
            Console.WriteLine("-------------------------");

            return input;
        }

        public int Delete(int input)
        {
            TRANSPORT_COST tRANSPORT_COST = context.Transport_Costs.Find(input);
            context.Entry(tRANSPORT_COST).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("Transport Cost dengan ID " + input + " Berhasil terhapus!");
            return input;
        }
    }
}
