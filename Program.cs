using APBD_TASK2.Controllers;
using APBD_TASK2.Database;
using APBD_TASK2.Models;
using APBD_TASK2.View;

namespace APBD_TASK2
{
    class Program
    {
        public static void DisplayHelp()
        {
            Console.WriteLine("""
                > help - display the list of commands
                > addUser - Add new user
                > viewusers - Display the list of users
                > addEq / addEquipment - Add new Equipment
                > viewEq / viewEquipment - Display the full equipment list
                > viewEqA / viewEquipmentA- Displays list of equipment that has avaiable status
                > rent - Rent equipment to a user
                > return - Return the rented item
                > mia - Set equipment status to unavaiable
                > viewRentals - Display rentals for the selected user
                > viewOverDue - Display all overdue rentals
                > summary - Generate a short summary of the rental system
                > q - To exit the application
                """);
        }
        static void Main(string[] args)
        {
            //Sample data
            //==============================
            var db = Singleton.Instance;
            Equipment camera1 = new Camera("NIKON D5100", "Digital SLR-Camera", 16, true);
            EquipmentController.AddEquipment(camera1);
            EquipmentController.AddEquipment(new Camera("NIKON D850", "Digital full frame DSLR Camera", 45, true));

            EquipmentController.AddEquipment(new Laptop("ThinkPad T480s", "Lenovo Laptop", 16, 14));
            EquipmentController.AddEquipment(new Laptop("HP 15", "Ryzen 7 5825U", 16, 15.6));

            EquipmentController.AddEquipment(new Projector("SAMSUNG The Freestyle", "Portable projector", 230, "Full HD"));
            EquipmentController.AddEquipment(new Projector("JMGO N1S Ultimate", "Portable projector", 3300, "4K"));

            User s1 = new User("Antoni", "Slomka", "s33610@pjwstk.edu.pl", Enum.UserType.Student);
            User l1 = new User("John", "Smith", "jsmith@pjwstk.edu.pl", Enum.UserType.Employee);
            UserController.AddUser(s1);
            UserController.AddUser(l1);

            RentedItemController.AddRentedItem(new RentedItem(camera1, s1, new DateTime(2026,3,12), 5, null));
            //==============================
            ////EquipmentUserInterface.DisplayEquipmentByStatus(Enum.EquipmentStatus.Available);
            ////EquipmentUserInterface.AddNewEquipment();

            //UserUI.DisplayUsers();

            //EquipmentUI.DisplayEquipment();

            //EquipmentUI.MakeEquipmentUnavailable();

            //EquipmentUI.DisplayEquipment();

            //RentedItemUI.ShowAllOverdueRentals();


            ////RentedItemUI.AddNewRental();
            ////RentedItemUI.AddNewRental();

            //////EquipmentUI.DisplayEquipment();

            ////RentedItemUI.DisplayActiveRentalsForUser();
            ///
            //Welcome message
            Console.WriteLine("Welcome to the Rental Service! Type help to display the list of commands.");
            String line = "";
            while ((line = Console.ReadLine()) != "q")
            {
                switch (line.ToLower())
                {
                    case "help": DisplayHelp(); break;
                    case "adduser": UserUI.AddNewUser(); break;
                    case "viewusers": UserUI.DisplayUsers(); break;
                    case "addeq": case "addequipment": EquipmentUI.AddNewEquipment(); break;
                    case "vieweq": case "viewequipment": EquipmentUI.DisplayEquipment(); break;
                    case "vieweqa": case "viewequipmenta": EquipmentUI.DisplayEquipmentByStatus(); break;
                    case "rent": RentedItemUI.AddNewRental(); break;
                    case "return": RentedItemUI.ReturnRental(); break;
                    case "mia": EquipmentUI.MakeEquipmentUnavailable(); break;
                    case "viewrentals": RentedItemUI.DisplayActiveRentalsForUser(); break;
                    case "viewoverdue": RentedItemUI.DisplayAllOverdueRentals(); break;
                    case "summary": Console.WriteLine(); break;
                    default: break;
                }
            }

        }
    }
}