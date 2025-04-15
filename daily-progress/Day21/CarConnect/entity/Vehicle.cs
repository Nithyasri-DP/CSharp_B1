namespace CarConnect.entity
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int VehicleYear { get; set; }
        public string? Color { get; set; } 
        public string RegistrationNumber { get; set; }
        public bool VehicleAvailability { get; set; }
        public decimal DailyRate { get; set; }

        // Default constructor
        public Vehicle() { }

        // Parameterized constructor
        public Vehicle(int vehicleID, string model, string make, int vehicleYear, string? color, string registrationNumber, bool vehicleAvailability, decimal dailyRate)
        {
            this.VehicleID = vehicleID;
            this.Model = model;
            this.Make = make;
            this.VehicleYear = vehicleYear;
            this.Color = color;
            this.RegistrationNumber = registrationNumber;
            this.VehicleAvailability = vehicleAvailability;
            this.DailyRate = dailyRate;
        }
    }
}
