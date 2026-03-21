using APBD_TASK2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    public class User
    {
        private static int _nextId = 1;
        public int Id { get; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserType Type { get; set; }

        public int MaxRentalLimit => Type switch
        {
            UserType.Student => 2,
            UserType.Employee => 5,
            _ => 0
        };

        public User(string name, string surname, string email, UserType type)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Type = type;
        }
    }
}
