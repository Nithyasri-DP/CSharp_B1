using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.entity
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

        // Constructor
        public Reservation(int reservationID, int customerID, int vehicleID, DateTime startDate, DateTime endDate, decimal totalCost, string status)
        {
            ReservationID = reservationID;
            CustomerID = customerID;
            VehicleID = vehicleID;
            StartDate = startDate;
            EndDate = endDate;
            TotalCost = totalCost;
            Status = status;
        }

        // Default constructor
        public Reservation() { }

        // Method to calculate total cost based on daily rate
        public void CalculateTotalCost(decimal dailyRate)
        {
            int days = (EndDate - StartDate).Days;
            if (days <= 0)
                throw new ArgumentException("End date must be after start date.");

            TotalCost = dailyRate * days;
        }
    }
}
