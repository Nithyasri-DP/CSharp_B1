using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.entity
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? cAddress { get; set; }
        public string Username { get; set; } = null!;
        public string cPassword { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }

        public Customer() { }

        public Customer(int customerID, string firstName, string lastName, string email, string phoneNumber, string cAddress, string username, string cPassword, DateTime registrationDate)
        {
            this.CustomerID = customerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.cAddress = cAddress;
            this.Username = username;
            this.cPassword = cPassword;
            this.RegistrationDate = registrationDate;
        }

        public bool Authenticate(string password)
        {
            return this.cPassword == password;
        }
    }
}




