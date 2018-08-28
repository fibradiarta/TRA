using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp18_TRA_Codefirst.Models
{
    class TYPE
    {
        [Key]
        public int type_id { get; set; }
        public string name { get; set; }
    }
}
