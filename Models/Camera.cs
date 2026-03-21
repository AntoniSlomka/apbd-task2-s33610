using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    internal class Camera : Equipment
    {

        public int ResolutionMP { get; set; }
        public bool recordingCapabilities { get; set; }

        public Camera(string name, string description, int resolutionMP, bool recordingCapabilities) 
            : base(name, description = "Camera")
        {
            this.ResolutionMP = resolutionMP;
            this.recordingCapabilities = recordingCapabilities;
        }

    }
}
