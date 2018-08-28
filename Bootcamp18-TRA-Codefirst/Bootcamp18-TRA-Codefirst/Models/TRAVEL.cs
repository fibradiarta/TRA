using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp18_TRA_Codefirst.Models
{
    class TRAVEL
    {
        [Key]
        public int travel_id { get; set; }
        public int user_id { get; set; }
        public int category_id { get; set; }
        public DateTime departure_date { get; set; }
        public DateTime arrival_date { get; set; }
        public string destination { get; set; }
        public string status { get; set; }
        public int total { get; set; }

        public virtual List<CATEGORY> Categories { get; set; }
        public virtual List<USER> Users { get; set; }
    }
}
