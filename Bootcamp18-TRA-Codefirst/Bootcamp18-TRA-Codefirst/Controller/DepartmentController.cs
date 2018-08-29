using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_TRA_Codefirst.Models;

namespace Bootcamp18_TRA_Codefirst.Controller
{
    class DepartmentController
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
                        Console.Write("Masukan ID Department yang ingin dicari : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        GetById2(input);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Insert();
                        //Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Write("Masukan ID Department yang ingin di Update : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Update(input);
                        Console.ReadKey(true);
                        break;
                    case 5:
                        Console.Write("Masukan ID Department yang ingin di Delete : ");
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

            Console.Write("Masukan Nama Department : ");
            nama = Console.ReadLine();

            DEPARTMENT deparments = new DEPARTMENT
            {
                name = nama
            };

            try
            {
                context.Departments.Add(deparments);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public List<DEPARTMENT> getAll()
        {
            var getall = context.Departments.ToList();

            foreach (DEPARTMENT departments in getall)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id               : " + departments.department_id);
                Console.WriteLine("Name Department  : " + departments.name);
                Console.WriteLine("-------------------------");
            }

            return getall;
        }

        public DEPARTMENT GetById(int input)
        {
            DEPARTMENT departments = context.Departments.Find(input);
            if (departments == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            return departments;
        }

        public DEPARTMENT GetById2(int input)
        {
            DEPARTMENT departments = context.Departments.Find(input);
            if (departments == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id   : " + departments.department_id);
                Console.WriteLine("Name : " + departments.name);
                Console.WriteLine("-------------------------");
            }
            return departments;
        }

        public int Update(int input)
        {
            string nama;

            var departments = context.Departments.Find(input);

            Console.WriteLine("\n-------Data Sebelum Diupdate---------");
            Console.WriteLine("Id               : " + departments.department_id);
            Console.WriteLine("Name Department  : " + departments.name);
            Console.WriteLine("-------------------------------------\n");

            Console.Write("Masukan Nama Department : ");
            nama = Console.ReadLine();

            DEPARTMENT dEPARTMENT = GetById(input);
            dEPARTMENT.name = nama;

            context.Entry(dEPARTMENT).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("\n-------Data Setelah Diupdate---------");
            Console.WriteLine("Id               : " + dEPARTMENT.department_id);
            Console.WriteLine("Name Department  : " + dEPARTMENT.name);
            Console.WriteLine("-------------------------------------");

            return input;
        }

        public int Delete(int input)
        {
            var departments = context.Departments.Find(input);
            context.Entry(departments).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("Department dengan ID " + input + " berhasil dihapus");
            Console.ReadKey(true);

            return input;
        }
    }
}
