using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.entity
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string AdminPassword { get; set; }
        public string AdminRole { get; set; }
        public DateTime? JoinDate { get; set; } 


        public Admin() { }

        public Admin(int adminID, string firstName, string lastName, string email, string phoneNumber, string username, string adminPassword, string adminRole)
        {
            this.AdminID = adminID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Username = username;
            this.AdminPassword = adminPassword;
            this.AdminRole = adminRole;
        }
    }
}
