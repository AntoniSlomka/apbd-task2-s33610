using APBD_TASK2.Database;
using APBD_TASK2.Models;
using APBD_TASK2.View;
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
            if (UserController.RentalLimitReached(rentedItem.User.Id))
            {
                Console.WriteLine($"This user has reached their rental limit: {UserController.GetActiveRentals(rentedItem.User.Id)}");
                return;
            }

            if (rentedItem.Equipment.Status != Enum.EquipmentStatus.Available)
            {
                Console.WriteLine($"This equipment is not avaiable for renting, status: {rentedItem.Equipment.Status}");
                return;
            }
            Singleton.Instance.RentedItems.Add(rentedItem);
            rentedItem.Equipment.Status = Enum.EquipmentStatus.Rented;
        }

        public static int GetFeeForRentedItem(RentedItem item)
        {
            int fee = 0;
            DateTime dueDate = item.RentDate.AddDays(item.RentPeriod);
            if (dueDate < DateTime.Now)
            {
                if (item.ReturnDate != null)
                {
                    DateTime returnedOn = (DateTime)item.ReturnDate;
                    int dayDiff = ((int)returnedOn.Subtract(dueDate).TotalDays);
                    fee += item.Equipment.Fee() * dayDiff;
                }
                else
                {
                    int dayDiff = ((int)DateTime.Now.Subtract(dueDate).TotalDays);
                    fee += item.Equipment.Fee() * dayDiff;
                }
            }
            return fee;
        }

        public static void ReturnRentedItem(RentedItem item)
        {

        }
    }
}
