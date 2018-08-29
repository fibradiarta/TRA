using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_TRA_Codefirst.Models;

namespace Bootcamp18_TRA_Codefirst.Controller
{
    class CategoryController
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
                        Console.Write("Masukan ID Category yang ingin dicari : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        GetById2(input);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Insert();
                        //Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Write("Masukan ID Category yang ingin di Update : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Update(input);
                        Console.ReadKey(true);
                        break;
                    case 5:
                        Console.Write("Masukan ID Category yang ingin di Delete : ");
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

            Console.Write("Masukan Nama Category : ");
            nama = Console.ReadLine();

            CATEGORY categories = new CATEGORY
            {
                name = nama
            };

            try
            {
                context.Categories.Add(categories);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public List<CATEGORY> getAll()
        {
            var getall = context.Categories.ToList();

            foreach (CATEGORY categories in getall)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id               : " + categories.catagory_id);
                Console.WriteLine("Name Category    : " + categories.name);
                Console.WriteLine("-------------------------");
            }

            return getall;
        }

        public CATEGORY GetById(int input)
        {
            CATEGORY categories = context.Categories.Find(input);
            if (categories == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            return categories;
        }

        public CATEGORY GetById2(int input)
        {
            CATEGORY categories = context.Categories.Find(input);
            if (categories == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id   : " + categories.catagory_id);
                Console.WriteLine("Name : " + categories.name);
                Console.WriteLine("-------------------------");
            }
            return categories;
        }

        public int Update(int input)
        {
            string nama;

            var categories = context.Categories.Find(input);

            Console.WriteLine("\n-------Data Sebelum Diupdate---------");
            Console.WriteLine("Id               : " + categories.catagory_id);
            Console.WriteLine("Name Category    : " + categories.name);
            Console.WriteLine("-------------------------------------\n");

            Console.Write("Masukan Nama Category : ");
            nama = Console.ReadLine();

            CATEGORY cATEGORY = GetById(input);
            cATEGORY.name = nama;

            context.Entry(cATEGORY).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("\n-------Data Setelah Diupdate---------");
            Console.WriteLine("Id               : " + cATEGORY.catagory_id);
            Console.WriteLine("Name Category    : " + cATEGORY.name);
            Console.WriteLine("-------------------------------------");

            return input;
        }

        public int Delete(int input)
        {
            var categories = context.Categories.Find(input);
            context.Entry(categories).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("Category dengan ID " + input + " berhasil dihapus");
            Console.ReadKey(true);

            return input;
        }
    }
}
