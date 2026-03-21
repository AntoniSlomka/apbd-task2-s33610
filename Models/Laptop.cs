using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    internal class Laptop : Equipment
    {
        public int RamGB { get; set; }
        public int ScreenSizeInch {  get; }
        
        public Laptop(string name, string description, int ramGB, int screenSize) : base (name, description = "Laptop") 
        {
            this.RamGB = ramGB;
            this.ScreenSizeInch = screenSize;
        }

        public override int Fee()
        {
            return 5;
        }
    }
}
