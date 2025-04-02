using System;

namespace AssignmentSolutions
{
    //parent class nd attributes
    public class Student
    {
        public int RollNo { get; set; }
        public string? Name { get; set; }
        public string? Class { get; set; }
        public string? Semester { get; set; }
        public string? Branch { get; set; }
        protected int[] Marks = new int[5];

        //constructor
        public Student(int rollNo, string name, string studentClass, string semester, string branch)
        {
            this.RollNo = rollNo;
            this.Name = name;
            this.Class = studentClass;
            this.Semester = semester;
            this.Branch = branch;
        }

        public void GetMarks()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter marks for subject {i + 1}: ");
                Marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public double CalAverage()
        {
            int total = 0;
            for (int i = 0; i < Marks.Length; i++)
            {
                total += Marks[i];
            }
            return total / 5;
        }
        public void DisplayData()
        {
            Console.WriteLine("\nStudent Details:");
            Console.WriteLine($"Roll No: {this.RollNo}");
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Class: {this.Class}");
            Console.WriteLine($"Semester: {this.Semester}");
            Console.WriteLine($"Branch: {this.Branch}");
            Console.WriteLine($"Marks: {string.Join(", ", this.Marks)}");
        }
    }

    //child class
    public class ResultEvaluation : Student
    {
        //using base to call parent class
        public ResultEvaluation(int rollNo, string name, string studentClass, string semester, string branch)
            : base(rollNo, name, studentClass, semester, branch)
        { }//constructor body
        public void DisplayResult()
        {
            // Check if any subject has marks less than 35 using a for loop
            for (int i = 0; i < Marks.Length; i++)
            {
                if (Marks[i] < 35)
                {
                    Console.WriteLine("Result: Failed (One or more subjects have marks less than 35)");
                    return;
                }
            }
            // Check if average is below 50 using the for loop result
            double average = CalAverage();
            if (average < 50)
            {
                Console.WriteLine("Result: Failed (Average marks below 50)");
            }
            else
            {
                Console.WriteLine("Result: Passed (Average marks above 50)");
            }
        }
    }

    // Main class to run the program
    public class StudentInherit
    {
        public static void StudResult() //calling this from main prgm
        {
            Console.Write("Enter Roll Number: ");
            int rollNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string? studentClass = Console.ReadLine();

            Console.Write("Enter Semester: ");
            string? semester = Console.ReadLine();

            Console.Write("Enter Branch: ");
            string? branch = Console.ReadLine();

            // Create a new student object using user input
            ResultEvaluation student = new ResultEvaluation(rollNo, name, studentClass, semester, branch);

            // Get marks from the user
            student.GetMarks();

            // Display student details
            student.DisplayData();

            // Display result
            student.DisplayResult();
        }
    }
}
