using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp18_TRA_Codefirst.Models
{
    class USER
    {
        [Key]
        public int user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string job_title { get; set; }
        public string gender { get; set; }
        public DateTime birth_date { get; set; }
        public string password { get; set; }

        public virtual List<TRAVEL> Travels { get; set; }
        
        public int department_id { get; set; }
        public virtual DEPARTMENT Departments { get; set; }
        public int role_id { get; set; }
        public virtual ROLE Roles { get; set; }
    }
}
