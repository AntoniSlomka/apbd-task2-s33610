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

        public static Equipment EquipmentById(int EquipmentId)
        {
            if (EquipmentIdExists(EquipmentId))
            {
                Equipment? equipment = Singleton.Instance.EquipmentList.FirstOrDefault(x =>
                {
                    return x.Id == EquipmentId;
                });
                return equipment;
            }
            else
            {
                Console.WriteLine("Invalid Equipment ID");
                return null;
            }
            
        }

        public static bool EquipmentIdExists(int EquipmentId)
        {
            return Singleton.Instance.EquipmentList.Any(x => x.Id == EquipmentId);
        }

    }
}
