using APBD_TASK2.Database;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Controllers
{
    public class RentedItemController
    {
        public void addRentedItem(RentedItem rentedItem)
        {
            if (!Singleton.Instance.UserList.Contains(rentedItem.User))
            {
                throw new Exception("No matching user found in the database");
            }
            if (!Singleton.Instance.EquipmentList.Contains(rentedItem.Equipment))
            {
                throw new Exception("No matching equipment found in the database");
            }
            
            if (rentedItem.Equipment.Status == Enum.EquipmentStatus.Available)
            {

            }
        }
    }
}
