using APBD_TASK2.Database;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Controllers
{
    public static class RentedItemController
    {
        public static void AddRentedItem(RentedItem rentedItem)
        {
            if (!Singleton.Instance.UserList.Contains(rentedItem.User))
            {
                throw new Exception("No matching user found in the database");
            }
            if (!Singleton.Instance.EquipmentList.Contains(rentedItem.Equipment))
            {
                throw new Exception("No matching equipment found in the database");
            }
            
            if (rentedItem.Equipment.Status == Enum.EquipmentStatus.Available
                && !UserController.RentalLimitReached(rentedItem.User.Id))
            {
                Singleton.Instance.RentedItems.Add(rentedItem);
                rentedItem.Equipment.Status = Enum.EquipmentStatus.Rented;
            }
        }
    }
}
