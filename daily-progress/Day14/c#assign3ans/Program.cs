using System;
namespace Assignmentthree
{
    //base class and its attributes
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public double Salary { get; set; }

        //parameterized constructor
        public Employee(int ID, string Name, DateTime DOB, double Salary)
        {
            this.Id = ID;
            this.Name = Name;
            this.DOB = DOB;
            this.Salary = Salary;
        }
        //using virtual method to compute salary, so that child class can be overridden
        public virtual double calSalary()
        {
            return Salary;
        }
        //display emp details
        public void display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, DOB: {DOB.ToShortDateString()}");
            Console.WriteLine($"Salary: {calSalary()}");
        }
    }

    //derived cls nd its additional properties
    class Manager : Employee
    {
        public double OnsiteAllowance { get; set; }
        public double Bonus { get; set; }
        //using base to call values from emp class
        public Manager(int Id, string Name, DateTime DOB, double Salary, double OnsiteAllowance, double Bonus) : base(Id, Name, DOB, Salary)
        {
            this.OnsiteAllowance = OnsiteAllowance;
            this.Bonus = Bonus;
        }
        //overriding part
        public override double calSalary()
        {
            return Salary + OnsiteAllowance + Bonus;
        }
    }

        class Program
        {
            public static void Main()
            {
                // Getting Employee details from user
                Console.WriteLine("Enter Employee Details:");
                Console.Write("Enter ID: ");
                int empId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Name: ");
                string empName = Console.ReadLine();
                Console.Write("Enter DOB (yyyy-mm-dd): ");
                DateTime empDob = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Salary: ");
                double empSalary = Convert.ToDouble(Console.ReadLine());

                Employee emp = new Employee(empId, empName, empDob, empSalary);
                emp.display();

                // Getting Manager details from user
                Console.WriteLine("\nEnter Manager Details:");
                Console.Write("Enter ID: ");
                int mgrId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Name: ");
                string mgrName = Console.ReadLine();
                Console.Write("Enter DOB (yyyy-mm-dd): ");
                DateTime mgrDob = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Salary: ");
                double mgrSalary = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Onsite Allowance: ");
                double onsiteAllowance = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Bonus: ");
                double bonus = Convert.ToDouble(Console.ReadLine());

                Manager mgr = new Manager(mgrId, mgrName, mgrDob, mgrSalary, onsiteAllowance, bonus);
                mgr.display();

                // Calling another program   
                abc.CountFunction();
                abc.CountFunction();
                abc.CountFunction();
            }
        }
}

