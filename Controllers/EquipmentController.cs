using APBD_TASK2.Database;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Controllers
{
    public static class EquipmentController
    {
        public static void AddEquipment(Equipment equipment)
        {
            Singleton.Instance.EquipmentList.Add(equipment);
        }
        
    }
}
