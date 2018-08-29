using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp18_TRA_Codefirst.Models
{
    class TRANSPORT_COST
    {
        [Key]
        public int transport_id { get; set; }
        public string attachment { get; set; }
        public int cost { get; set; }
        public DateTime date { get; set; }


        public int type_id { get; set; }
        public virtual TYPE Types { get; set; }
        public int travel_id { get; set; }
        public virtual TRAVEL Travels { get; set; }
    }
}
