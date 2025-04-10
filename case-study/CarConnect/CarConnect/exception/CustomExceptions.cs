using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.exception
{
    // Thrown when authentication fails
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message) { }
    }

    // Thrown when there's an issue with reservations
    public class ReservationException : Exception
    {
        public ReservationException(string message) : base(message) { }
    }

    // Thrown when a vehicle is not found
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException(string message) : base(message) { }
    }

    // Thrown when an admin is not found
    public class AdminNotFoundException : Exception
    {
        public AdminNotFoundException(string message) : base(message) { }
    }

    // Thrown when input is invalid
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }

    // Thrown when database connection fails
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message) : base(message) { }
    }

    // Thrown when customer not found
    public class CustomerException : Exception
    {
        public CustomerException(string message) : base(message) { }        
    }

    // Thrown when vehicle is not found
    public class VehicleException : Exception
    {
        public VehicleException(string message) : base(message) { }       
    }
}
