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
        public int MinimumISO { get; set; }
        public int MaximumISO { get; set; }
        public double LensFocalLength { get; set; }
        public bool recordingCapabilities { get; set; }

        public Camera(string name, string description, int resolutionMP, int minimumISO, int maximumISO, double lensFocalLength, bool recordingCapabilities) 
            : base(name, description = "Camera")
        {
            ResolutionMP = resolutionMP;
            MinimumISO = minimumISO;
            MaximumISO = maximumISO;
            LensFocalLength = lensFocalLength;
            this.recordingCapabilities = recordingCapabilities;
        }

    }
}
