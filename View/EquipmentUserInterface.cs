using APBD_TASK2.Controllers;
using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.View
{
    public static class EquipmentUserInterface
    {
        public static List<String> EquipmentTypes = new List<String>(["Camera", "Laptop", "Projector"]);
        public static void DisplayEquipment()
        {
            Console.WriteLine("Equipment List");
            Console.WriteLine($"{"ID",-3} | {"Name",-25}| {"Status",-10}");
            foreach (var item in Singleton.Instance.EquipmentList)
            {
                Console.WriteLine($"{item.Id, -3} | {item.Name,-25}| {item.Status.ToString(),-10}");
            }
        }

        public static void DisplayEquipmentByStatus(EquipmentStatus status = EquipmentStatus.Available)
        {
            Console.WriteLine($"{status.ToString()} Equipment List");
            Console.WriteLine($"{"ID",-3} | {"Name",-25}| {"Status",-10}");
            var count = 0;
            foreach (var item in Singleton.Instance.EquipmentList)
            {
                if (item.Status == status)
                {
                    Console.WriteLine($"{item.Id,-3} | {item.Name,-25}| {item.Status.ToString(),-10}");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("None");
            }
        }

        public static void AddNewEquipment()
        {
            Console.WriteLine("Choose the equipment type to add (enter index number): ");
            for (var i = 0; i < EquipmentTypes.Count; i++)
            {
                Console.WriteLine($"{i+1}. {EquipmentTypes[i]}");
            }
            var line = Console.ReadLine();
            switch (int.Parse(line))
            {
                case 1: AddNewCamera(); break;
                case 2: AddNewLaptop(); break;
                case 3: AddNewProjector(); break;
                default: Console.WriteLine("Incorrect index"); break;
            }
        }

        private static void AddNewCamera()
        {
            Console.WriteLine("Adding new Camera: ");
            Console.WriteLine("Enter Equipment Name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter Equipment Description: ");
            String description = Console.ReadLine();

            Console.WriteLine("Enter matrix resolution in MP: ");
            double res = double.Parse(Console.ReadLine());
            Console.WriteLine("Has recording capabilities? (Y/N)");
            bool recording = false;
            if (Console.ReadLine().ToLower() == "y") recording = true;
            EquipmentController.AddEquipment(new Camera(name, description, res, recording));
            Console.WriteLine("New Camera added!");

        }

        private static void AddNewLaptop()
        {
            Console.WriteLine("Adding new Laptop: ");
            Console.WriteLine("Enter Equipment Name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter Equipment Description: ");
            String description = Console.ReadLine();

            Console.WriteLine("Enter the RAM memory amount in GB: ");
            int ram= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter screen resolution in inches: ");
            double res = double.Parse(Console.ReadLine());
            EquipmentController.AddEquipment(new Laptop(name, description, ram, res));
            Console.WriteLine("New Laptop added!");
        }

        private static void AddNewProjector()
        {
            Console.WriteLine("Adding new Projector: ");
            Console.WriteLine("Enter Equipment Name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter Equipment Description: ");
            String description = Console.ReadLine();

            Console.WriteLine("Enter the brightness in Lumens: ");
            int bright = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter projector resolution: ");
            String res = Console.ReadLine();
            EquipmentController.AddEquipment(new Projector(name, description, bright, res));
            Console.WriteLine("New Laptop added!");
        }
    }
}
