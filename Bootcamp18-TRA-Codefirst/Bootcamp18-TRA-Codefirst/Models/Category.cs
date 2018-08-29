using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp18_TRA_Codefirst.Models
{
    class CATEGORY
    {
        [Key]
        public int catagory_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public virtual List<TRAVEL> Travels { get; set; }
    }
}
