using APBD_TASK2.Database;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Controllers
{
    public static class UserController
    {
        public static void AddUser(User user)
        {
            Singleton.Instance.UserList.Add(user);
        }

        public static int GetActiveRentals(int UserId)
        {
            User user = UserById(UserId);
            int count = 0;
            foreach (RentedItem item in Singleton.Instance.RentedItems)
            {
                if (item.User.Id == UserId && item.ReturnDate == null) count++;
            }

            return count;
        }


        public static int CalculateTotalFee(int UserId)
        {
            User user = UserById(UserId);
            int fee = 0;
            foreach (RentedItem item in Singleton.Instance.RentedItems)
            {
                DateTime dueDate = item.RentDate.AddDays(item.RentPeriod);
                if (item.User.Id == UserId && !item.FeePaid && dueDate > DateTime.Now)
                {
                    fee += RentedItemController.GetFeeForRentedItem(item);
                }
            }
            return fee;
        }

        public static bool RentalLimitReached(int UserId)
        {
            User user = UserById(UserId);

            return GetActiveRentals(user.Id) >= user.MaxRentalLimit;
        }

        public static User UserById(int UserId)
        {
            if (UserIdExists(UserId))
            {
                User user = Singleton.Instance.UserList.FirstOrDefault(x =>
                {
                    return x.Id == UserId;
                });
                return user;
            } else
            {
                Console.WriteLine("Invalid User ID");
                return null;
            }            
        }

        public static bool UserIdExists(int UserId)
        {
            return Singleton.Instance.UserList.Any(x => x.Id == UserId);
        }
    }
}
