using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_TRA_Codefirst.Models;

namespace Bootcamp18_TRA_Codefirst.Controller
{
    class RoleController
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
                        Console.Write("Masukan ID Role yang ingin dicari : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        GetById2(input);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Insert();
                        //Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Write("Masukan ID Role yang ingin di Update : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Update(input);
                        Console.ReadKey(true);
                        break;
                    case 5:
                        Console.Write("Masukan ID Role yang ingin di Delete : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Delete(input);
                        Console.ReadKey(true);
                        break;
                    default: break;
                }
            } while (pilihan != 6);
        }

        public void Insert()
        {
            string nama;

            Console.Write("Masukan Nama Role : ");
            nama = Console.ReadLine();

            ROLE roles = new ROLE
            {
                name = nama
            };

            try
            {
                context.Roles.Add(roles);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public List<ROLE> getAll()
        {
            var getall = context.Roles.ToList();

            foreach (ROLE roles in getall)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id   : " + roles.role_id);
                Console.WriteLine("Name : " + roles.name);
                Console.WriteLine("-------------------------");
            }

            return getall;
        }

        public ROLE GetById(int input)
        {
            ROLE rOLE = context.Roles.Find(input);
            if (rOLE == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            return rOLE;
        }

        public ROLE GetById2(int input)
        {
            ROLE rOLE = context.Roles.Find(input);
            if (rOLE == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id   : " + rOLE.role_id);
                Console.WriteLine("Name : " + rOLE.name);
                Console.WriteLine("-------------------------");
            }
            return rOLE;
        }

        public int Update(int input)
        {
            string nama;

            var roles = context.Roles.Find(input);

            Console.WriteLine("\n-------Data Sebelum Diupdate---------");
            Console.WriteLine("Id   : " + roles.role_id);
            Console.WriteLine("Name : " + roles.name);
            Console.WriteLine("-------------------------------------\n");

            Console.Write("Masukan Nama Role : ");
            nama = Console.ReadLine();

            ROLE rOLE = GetById(input);
            rOLE.name = nama;

            context.Entry(rOLE).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("\n-------Data Setelah Diupdate---------");
            Console.WriteLine("Id   : " + rOLE.role_id);
            Console.WriteLine("Name : " + rOLE.name);
            Console.WriteLine("-------------------------------------");

            return input;
        }

        public int Delete(int input)
        {
            var rOLE = context.Roles.Find(input);
            context.Entry(rOLE).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("Role dengan ID " + input + " berhasil dihapus");
            Console.ReadKey(true);

            return input;
        }
    }
}
