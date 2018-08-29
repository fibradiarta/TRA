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
                        Console.Write("Masukan ID User yang ingin dicari : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        //GetById2(input);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Insert();
                        //Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Write("Masukan ID User yang ingin di Update : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        //Update(input);
                        Console.ReadKey(true);
                        break;
                    case 5:
                        Console.Write("Masukan ID User yang ingin di Delete : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        //Delete(input);
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

            foreach (TRAVEL travels in getAll)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id               : " + travels.travel_id);
                Console.WriteLine("Departure Date   : " + travels.departure_date);
                Console.WriteLine("Arrival Date     : " + travels.arrival_date);
                Console.WriteLine("Destination      : " + travels.destination);
                Console.WriteLine("Status           : " + travels.status);
                Console.WriteLine("Total            : " + travels.total);
                Console.WriteLine("Category         : " + travels.category_id);
                Console.WriteLine("Nama User        : " + travels.Users.name);
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
           
            // proses save ke database


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

        /*public USER GetById(int input)
        {
            USER uSER = context.Users.Find(input);
            if (uSER == null)
            {
                Console.Write("Id " + input + " Tidak Ada");

            }
            return uSER;
        }

        public USER GetById2(int input)
        {
            USER users = context.Users.Find(input);
            if (users == null)
            {
                Console.Write("Id " + input + " Tidak Ada");

            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id : " + users.user_id);
                Console.WriteLine("Name : " + users.name);
                Console.WriteLine("Email : " + users.email);
                Console.WriteLine("Job Title : " + users.job_title);
                Console.WriteLine("Gender : " + users.gender);
                Console.WriteLine("Birth Date : " + users.birth_date);
                Console.WriteLine("Password : " + users.password);
                Console.WriteLine("Department   : " + users.department_id);
                Console.WriteLine("Role         : " + users.role_id);
                Console.WriteLine("-------------------------");
            }
            return users;
        }

        public int Update(int input)
        {
            string nama, email, jobtitle, jenis_kelamin, password;
            DateTime tanggal_lahir;
            //int id_dept, id_rol;
            // inputan by user
            var users = context.Users.Find(input);
            if (users == null)
            {
                Console.Write("User dengan ID " + input + " tidak tersedia");
            }
            else
            {
                Console.WriteLine("--------Data Sebelum di Update---------");
                Console.WriteLine("Id           : " + users.user_id);
                Console.WriteLine("Name         : " + users.name);
                Console.WriteLine("Email        : " + users.email);
                Console.WriteLine("Job Title    : " + users.job_title);
                Console.WriteLine("Gender       : " + users.gender);
                Console.WriteLine("Birth Date   : " + users.birth_date);
                Console.WriteLine("Password     : " + users.password);
                Console.WriteLine("Department   : " + users.department_id);
                Console.WriteLine("Role         : " + users.role_id);
                Console.WriteLine("-------------------------\n");

                Console.Write("Masukkan Nama Lengkap    : ");
                nama = Console.ReadLine();
                Console.Write("Masukkan Email           : ");
                email = Console.ReadLine();
                Console.Write("Masukkan Job Title       : ");
                jobtitle = Console.ReadLine();
                Console.Write("Masukkan Gender          : ");
                jenis_kelamin = Console.ReadLine();
                Console.Write("Masukkan Birth Date      : ");
                tanggal_lahir = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Masukkan Password        : ");
                password = Console.ReadLine();
                /*Console.Write("Masukkan Department ID : ");
                id_dept = Convert.ToInt32(Console.ReadLine());
                Console.Write("Masukkan Role ID : ");
                id_rol = Convert.ToInt32(Console.ReadLine());


                USER uSER = GetById(input);
                uSER.name = nama;
                uSER.email = email;
                uSER.job_title = jobtitle;
                uSER.gender = jenis_kelamin;
                uSER.birth_date = tanggal_lahir;
                uSER.password = password;

                context.Entry(uSER).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                Console.WriteLine("\n--------Data Sesudah di Update---------");
                Console.WriteLine("Id           : " + users.user_id);
                Console.WriteLine("Name         : " + users.name);
                Console.WriteLine("Email        : " + users.email);
                Console.WriteLine("Job Title    : " + users.job_title);
                Console.WriteLine("Gender       : " + users.gender);
                Console.WriteLine("Birth Date   : " + users.birth_date);
                Console.WriteLine("Password     : " + users.password);
                Console.WriteLine("Department   : " + users.department_id);
                Console.WriteLine("Role         : " + users.role_id);
                Console.WriteLine("-------------------------");
            }



            return input;
        }

        public int Delete(int input)
        {
            USER users = context.Users.Find(input);
            context.Entry(users).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("User dengan ID User " + input + " Berhasil terhapus!");
            return input;
        }*/
    }
}
