using System;
using System.Collections.Generic;
using System.Text;

namespace TriviaMeister.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name
        {
            get => $"{FirstName} {LastName}";
        }
    }
}
