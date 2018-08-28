using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp18_TRA_Codefirst.Models
{
    class HOTEL_COST
    {
        [Key]
        public int hotel_id { get; set; }
        public int travel_id { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public string attachment { get; set; }
        public DateTime date_checkin { get; set; }
        public DateTime date_checkout { get; set; }

        public virtual List<TRAVEL> Travels { get; set; }
    }
}
