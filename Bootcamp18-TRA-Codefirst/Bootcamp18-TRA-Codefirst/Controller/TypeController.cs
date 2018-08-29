using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_TRA_Codefirst.Models;

namespace Bootcamp18_TRA_Codefirst.Controller
{
    class TypeController
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
                        Console.Write("Masukan ID Type yang ingin dicari : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        GetById2(input);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Insert();
                        //Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Write("Masukan ID Type yang ingin di Update : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Update(input);
                        Console.ReadKey(true);
                        break;
                    case 5:
                        Console.Write("Masukan ID Type yang ingin di Delete : ");
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

            Console.Write("Masukan Nama Type : ");
            nama = Console.ReadLine();

            TYPE types = new TYPE
            {
                name = nama
            };

            try
            {
                context.Tipes.Add(types);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public List<TYPE> getAll()
        {
            var getall = context.Tipes.ToList();

            foreach (TYPE types in getall)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id               : " + types.type_id);
                Console.WriteLine("Name Type        : " + types.name);
                Console.WriteLine("-------------------------");
            }

            return getall;
        }

        public TYPE GetById(int input)
        {
            TYPE types = context.Tipes.Find(input);
            if (types == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            return types;
        }

        public TYPE GetById2(int input)
        {
            TYPE types = context.Tipes.Find(input);
            if (types == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id   : " + types.type_id);
                Console.WriteLine("Name : " + types.name);
                Console.WriteLine("-------------------------");
            }
            return types;
        }

        public int Update(int input)
        {
            string nama;

            var types = context.Tipes.Find(input);

            Console.WriteLine("\n-------Data Sebelum Diupdate---------");
            Console.WriteLine("Id               : " + types.type_id);
            Console.WriteLine("Name Type        : " + types.name);
            Console.WriteLine("-------------------------------------\n");

            Console.Write("Masukan Nama Department : ");
            nama = Console.ReadLine();

            TYPE tYPE = GetById(input);
            tYPE.name = nama;

            context.Entry(tYPE).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("\n-------Data Setelah Diupdate---------");
            Console.WriteLine("Id               : " + tYPE.type_id);
            Console.WriteLine("Name Type        : " + tYPE.name);
            Console.WriteLine("-------------------------------------");

            return input;
        }

        public int Delete(int input)
        {
            var types = context.Tipes.Find(input);
            context.Entry(types).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("Type dengan ID " + input + " berhasil dihapus");
            Console.ReadKey(true);

            return input;
        }
    }
}
