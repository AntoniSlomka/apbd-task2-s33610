using APBD_TASK2.Database;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.View
{
    public static class RentedItemUserInterface
    {
        public static void DisplayActiveRentalsForUser()
        {
            Console.WriteLine("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            User? user = Singleton.Instance.UserList.FirstOrDefault(x =>
            {
                return x.Id == userId;
            });
            if (user == null)
            {
                Console.WriteLine("Invalid User Id!");
                return;
            }
            Console.WriteLine($"Rented Items for UserId {1}:");
            Console.WriteLine($"{"ID",-3} | {"Equipment",-25}| {"Rent Date",-10} - {"Due Date",10} | Returned on");
            var items = Singleton.Instance.RentedItems.FindAll(x => { return x.User == user; });
            foreach (var item in items)
            {
                Console.WriteLine(FormatRental(item));
            }

        }

        public static String FormatRental(RentedItem item)
        {
            return $"""{item.Id,-3} | {item.Equipment.Name,-25}| {item.RentDate.ToShortDateString(),-10} - {item.RentDate.AddDays(item.RentPeriod).ToShortDateString(),10} | {(item.ReturnDate != null ? item.ReturnDate : "not returned yet")}""";
        }
    }
}
