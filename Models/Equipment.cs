using APBD_TASK2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    public abstract class Equipment
    {
        private static int _nextId = 1;

        public int Id { get; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public EquipmentStatus Status { get; set; }
        public DateTime DateAdded { get; set; }
        
        public Equipment(string name, string description = "")
        {
            this.Id = _nextId++;
            this.Name = name;
            this.Description = description;
            this.Status = EquipmentStatus.Available;
            this.DateAdded = DateTime.Now;
        }

    }
}
