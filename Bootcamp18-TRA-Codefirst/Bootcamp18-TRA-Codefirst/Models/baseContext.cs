using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp18_TRA_Codefirst.Models
{
    class baseContext : DbContext
    {
        public baseContext() : base("Console.DBTRA3") { }

        public DbSet<TRAVEL> Travels { get; set; }
        public DbSet<USER> Users { get; set; }
        public DbSet<HISTORY> Histories { get; set; }
        public DbSet<TRANSPORT_COST> Transport_Costs { get; set; }
        public DbSet<HOTEL_COST> Hotel_Costs { get; set; }
        public DbSet<CATEGORY> Categories { get; set; }
        public DbSet<DEPARTMENT> Departments { get; set; }
        public DbSet<TYPE> Tipes { get; set; }
        public DbSet<ROLE> Roles { get; set; }
    }
}
