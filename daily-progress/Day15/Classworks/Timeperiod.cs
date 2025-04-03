using System;
namespace AssignmentFour
{
    public class TimePeriod
    {
        private double minutes;

        public double Hours
        {
            get { return minutes / 60; } // Convert minutes to hours
            set { minutes = value * 60; } // Convert hours to minutes
        }        
        public TimePeriod(double hours)
        {
            minutes = hours * 60; // Initialize minutes based on the input hours
        }

        public string GetTimePeriod()
        {
            return $"Time Period: {Hours} hours ({minutes} minutes)";
        }

        public static void Main()
        {
            // Creating timeperiod object with 1 hr
            TimePeriod period = new TimePeriod(1);
            Console.WriteLine(period.GetTimePeriod());  

            // Change the time to 2 hours
            period.Hours = 2;
            Console.WriteLine(period.GetTimePeriod());
            
            // Calling second program
             Furnitures.furni();
        }
    }
}
