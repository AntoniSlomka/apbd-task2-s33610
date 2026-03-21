using APBD_TASK2.Database;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Controllers
{
    public class EquipmentController
    {
        public Singleton DataBase = null!;

        public EquipmentController(Singleton dataBase)
        {
            DataBase = dataBase;
        }

        public void addEquipment(Equipment equipment)
        {
            Database.Singleton.Instance.EquipmentList.Add(equipment);
        }
        
    }
}
