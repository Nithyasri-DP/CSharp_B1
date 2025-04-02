using System;

namespace AssignmentSolutions
{
    interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }
        double Fees { get; set; }
        void ShowDetails();
    }
    //Dayscholar implements IStudent
    class Dayscholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double Fees { get; set; }
        //constructor
        public Dayscholar(int studentId, string name, double fees)
        {
            StudentId = studentId;
            Name = name;
            Fees = fees;
        }
        //viweing details
        public void ShowDetails()
        {
            Console.WriteLine($"Dayscholar Student ID: {StudentId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Fees: {Fees}");
        }
    }    

    //Resident implements IStudent
    class Resident : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double Fees { get; set; }
        public double AccommodationFees { get; set; }
        //constructor
        public Resident(int studentId, string name, double fees, double accommodationFees)
        {
            StudentId = studentId;
            Name = name;
            Fees = fees;
            AccommodationFees = accommodationFees;
        }
        //viweing details
        public void ShowDetails()
        {
            Console.WriteLine($"Resident Student ID: {StudentId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Fees (Tuition + Resident): {Fees + AccommodationFees}");
        }
    }
    //main class
    class Accommodation
    {
        public static void Stay()
        {
            //Instance of Dayscholar
            IStudent student1 = new Dayscholar(1, "Anu", 8000);
            student1.ShowDetails();
            //Instance of Resident
            IStudent student2 = new Resident(2, "Yakshna", 8000, 2000);
            student2.ShowDetails();
        }
    }
}