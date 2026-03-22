using APBD_TASK2.Controllers;
using APBD_TASK2.Database;
using APBD_TASK2.Models;
using APBD_TASK2.View;

namespace APBD_TASK2
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = Singleton.Instance;
            EquipmentController.AddEquipment(new Camera("NIKON D5100", "Digital SLR-Camera", 16, true));
            EquipmentController.AddEquipment(new Camera("NIKON D850", "Digital full frame DSLR Camera", 45, true));

            EquipmentController.AddEquipment(new Laptop("ThinkPad T480s", "Lenovo Laptop", 16, 14));
            EquipmentController.AddEquipment(new Laptop("HP 15", "Ryzen 7 5825U", 16, 15.6));

            EquipmentController.AddEquipment(new Projector("SAMSUNG The Freestyle", "Portable projector", 230, "Full HD"));
            EquipmentController.AddEquipment(new Projector("JMGO N1S Ultimate", "Portable projector", 3300, "4K"));

            EquipmentUserInterface.DisplayEquipmentByStatus(Enum.EquipmentStatus.Available);
            EquipmentUserInterface.AddNewEquipment();
        }
    }
}