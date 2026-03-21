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
        public static void addUser(User user)
        {
            Singleton.Instance.UserList.Add(user);
        }

        public static int getActiveRentals(int UserId)
        {
            User? user = Singleton.Instance.UserList.FirstOrDefault(x =>
            {
                return x.Id == UserId;
            });
            if (user == null)
            {
                Console.WriteLine("No user with this Id found");
                return -1;
            }
            int count = 0;
            foreach (RentedItem item in Singleton.Instance.RentedItems)
            {
                if (item.User.Id == UserId) count++;
            }

            return count;
        }


        public static int calculateFee(int UserId)
        {
            User? user = Singleton.Instance.UserList.FirstOrDefault(x =>
            {
                return x.Id == UserId;
            });
            if (user == null)
            {
                Console.WriteLine("No user with this Id found");
                return -1;
            }
            int fee = 0;
            foreach (RentedItem item in Singleton.Instance.RentedItems)
            {
                DateTime endDate = item.RentDate.AddDays(item.RentPeriod);
                if (item.User.Id == UserId && DateTime.Now > endDate) fee += item.Equipment.Fee();
            }
            return fee;
        }
    }
}
