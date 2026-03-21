using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    internal class RentedItem
    {
        public Equipment Equipment { get; } = null!;
        public User User { get; } = null!;
        public DateTime RentDate { get; }
        public int RentPeriod { get; set; }
        public DateTime? ReturnDate { get; set; } = null;
        public int OverdueFee { get; set; } = 0;



    }
}
