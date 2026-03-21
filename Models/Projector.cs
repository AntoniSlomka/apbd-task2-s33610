using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APBD_TASK2.Models
{
    internal class Projector : Equipment
    {
        public int Brightness { get; set; }

        public String Resolution { get; set; } = null!;
        
        public Projector(String name, String description, int brightness, String resolution) : base(name, description = "Projector")
        {
            this.Brightness = brightness;
            this.Resolution = resolution;
        }

    }
}
