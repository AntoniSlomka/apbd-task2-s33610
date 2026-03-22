using APBD_TASK2.Controllers;
using APBD_TASK2.Database;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.View
{
    public static class RentedItemUI
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
            Console.WriteLine($"{"ID",-3} | {"UserId",-6} | {"Equipment",-25}| {"Rent Date",-10} - {"Due Date",10} | {"Returned on", -17} | Fee");
            var items = Singleton.Instance.RentedItems.FindAll(x => { return x.User == user; });
            if (items.Count == 0 ) Console.WriteLine("None");
            foreach (var item in items)
            {
                Console.WriteLine(FormatRental(item));
            }
            
        }

        public static void AddNewRental()
        {
            Console.WriteLine("Creating new Rental");
            Console.WriteLine("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            User? user = UserController.UserById(userId);
            if (user == null) return;
            Console.WriteLine("Enter Equipment ID: ");
            int equipmentId = int.Parse(Console.ReadLine());
            Equipment? equipment = EquipmentController.EquipmentById(equipmentId);
            if (equipment == null) return;
            Console.WriteLine("Enter rent period: ");
            int rentPeriod = int.Parse(Console.ReadLine());
            RentedItemController.AddRentedItem(new RentedItem(equipment, user, DateTime.Now, rentPeriod, null));
        }

        public static void ReturnRental()
        {
            Console.WriteLine("Enter rental ID: ");
            int rentalId = int.Parse(Console.ReadLine());
            if (!Singleton.Instance.RentedItems.Any(x => x.Id == rentalId))
            {
                Console.WriteLine("Invalid rental ID");
                return;
            }
            RentedItem rentedItem = Singleton.Instance.RentedItems.FirstOrDefault(x => x.Id == rentalId);
            RentedItemController.ReturnRentedItem(rentedItem);

        }

        public static String FormatRental(RentedItem item)
        {
            return $"{item.Id,-3} | {item.User.Id, -6} | {item.Equipment.Name,-25}| {item.RentDate.ToShortDateString(),-10} -"
                + $" {item.RentDate.AddDays(item.RentPeriod).ToShortDateString(),10} |"
                + $" {(item.ReturnDate != null ? item.ReturnDate : "not returned yet"), -17} |"
                + $" {(item.FeePaid ? ($"Paid: " + RentedItemController.GetFeeForRentedItem(item)) : RentedItemController.GetFeeForRentedItem(item))}";
        }

        public static void DisplayAllOverdueRentals()
        {
            Console.WriteLine("Overdue rentals: ");
            Console.WriteLine($"{"ID",-3} | {"UserId", -6} | {"Equipment",-25}| {"Rent Date",-10} - {"Due Date",10} | {"Returned on",-17} | Fee");
            int count = 0;
            foreach (var item in Singleton.Instance.RentedItems)
            {
                DateTime dueDate = item.RentDate.AddDays(item.RentPeriod);
                if (DateTime.Now > dueDate)
                {
                    Console.WriteLine(FormatRental(item));
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("None");
        }

        public static void DisplaySystemSummary()
        {
            Console.WriteLine("Summary: ");
            Console.WriteLine($"Total users count: {Singleton.Instance.UserList.Count()}");
            Console.WriteLine($"Total equipment count: {Singleton.Instance.EquipmentList.Count()}");
            Console.WriteLine($"Total rental count: {Singleton.Instance.RentedItems.Count()}");
            int unreturnedCount = Singleton.Instance.EquipmentList.Count(x => x.Status != Enum.EquipmentStatus.Available);
            Console.WriteLine($"Number of un-returned rentals: {unreturnedCount}");
            int overdueUserCount = Singleton.Instance.UserList.Count(x => {return UserController.CalculateTotalFee(x.Id) != 0;});
            Console.WriteLine($"Number of users with overdue fee: {overdueUserCount}");
            int totalFee = Singleton.Instance.UserList.Sum(x => { return UserController.CalculateTotalFee(x.Id);});
            Console.WriteLine($"Total value of overdue fee of all users: {totalFee}");
        }
    }


}