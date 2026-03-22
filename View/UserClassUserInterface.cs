using APBD_TASK2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.View
{
    public static class UserClassUserInterface
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

        public static void DisplayActiveRentals()
        {

        }
    }
}
