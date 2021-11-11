using Core.Helpers;
using System;

namespace API.Commands
{
    public class SignupRequested
    {
        public UserType UserType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime Birthday { get; set; }
    }
}
