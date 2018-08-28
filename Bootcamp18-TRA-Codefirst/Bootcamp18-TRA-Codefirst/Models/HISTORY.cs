using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp18_TRA_Codefirst.Models
{
    class HISTORY
    {
        [Key]
        public int history_id { get; set; }
        public int travel_id { get; set; }
        public string status { get; set; }
        public DateTime date_approval { get; set; }

        public virtual List<TRAVEL> Travels { get; set; }
    }
}
