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

        public DateTime dateAdded { get; set; }

    }
}
