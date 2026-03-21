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
                if (item.User.Id == UserId) count++;
            }

            return count;
        }


        public static int CalculateFee(int UserId)
        {
            User user = UserById(UserId);
            int fee = 0;
            foreach (RentedItem item in Singleton.Instance.RentedItems)
            {
                DateTime endDate = item.RentDate.AddDays(item.RentPeriod);
                int dayDiff = ((int)DateTime.Now.Subtract(endDate).TotalDays);
                if (item.User.Id == UserId && DateTime.Now > endDate) fee += item.Equipment.Fee() * dayDiff;
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
            User? user = Singleton.Instance.UserList.FirstOrDefault(x =>
            {
                return x.Id == UserId;
            });
            if (user == null)
            {
                throw new Exception("No user with this Id found");
            }
            return user;
        }
    }
}
