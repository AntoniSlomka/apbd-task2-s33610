using APBD_TASK2.Controllers;
using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.View
{
    public static class UserUI
    {
        public static void DisplayUsers()
        {
            Console.WriteLine("User List");
            Console.WriteLine($"{"ID",-3} | {"Name",-15}| {"Surname",-15}| {"UserType", -15}| {"Email", -15}");
            foreach (var user in Singleton.Instance.UserList)
            {
                Console.WriteLine($"{user.Id,-3} | {user.Name,-15}| {user.Surname,-15}| {user.Type,-15}| {user.Email,-15}");
            }
        }

        public static void AddNewUser()
        {
            Console.WriteLine("Adding new User");
            Console.WriteLine("Enter user's first name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter user's last name: ");
            String surname = Console.ReadLine();
            Console.WriteLine("Enter user's email: ");
            String email = Console.ReadLine();
            Console.WriteLine("Enter user type (S - Student, E - Employee): ");
            String typeInput = Console.ReadLine();
            UserType type = new UserType();
            switch (typeInput.ToLower())
            {
                case "s": type = UserType.Student; break;
                case "e": type = UserType.Employee; break;
                default: Console.WriteLine("Incorrect user type"); return;
            }

            UserController.AddUser(new User(name, surname, email, type));
        }

    }
}
