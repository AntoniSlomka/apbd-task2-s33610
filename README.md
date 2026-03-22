# Rental Service
A console application that manages school's rental service.
The application stores data about users, equipment and rented items and allows to:
- Add new users and equipment
- Rent equipment to users
- Return rented items
- Calculate late fee for rented items
- Display information in-depth information about database elements

## Usage
Application can be interacted with through the following commands:
- `help` - display the list of commands
- `addUser` - Add new user
- `viewusers` - Display the list of users
- `addEq` / `addEquipment` - Add new Equipment
- `viewEq` / `viewEquipment` - Display the full equipment list
- `viewEqA` / `viewEquipmentA`- Displays list of equipment that has avaiable status
- `rent` - Rent equipment to a user
- `return` - Return the rented item
- `mia` - Set equipment status to unavaiable (mia - missing in action)
- `viewRentals` - Display rentals for the selected user
- `viewOverDue` - Display all overdue rentals
- `summary` - Generate a short summary of the rental system
- `q` - To exit the application

## Implementation
Classes in the Model directory represent different types of equipment, the item that has been rented
and users.
The operations on the database are implemented with controllers in the Controllers directory.
They include: creating objects and adding them to the database and querrying database for entries and their information.
The view model is implemented with UI classes in the View directory. Those classes
implement all the operations done by the listed commands including helper display methods.

