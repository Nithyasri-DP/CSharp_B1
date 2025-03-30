using System;
namespace ClassWorks
{
    class Employee
    {
        static void Main(string[] args)
        {
            ClassOne emp = new ClassOne();
            emp.GetEmpDetails();
            emp.DisplayDetails();

            //Calling JaggedArray Program here
            JaggedArr jag = new JaggedArr();
            jag.Jaggedclassone();
        }
    }
    public class ClassOne
    {
        int Empid;
        string? Ename;
        double Salary;       
        public void GetEmpDetails()
        {
            Console.WriteLine($"Output of Employee details Program\n");
            Console.Write("Enter Emp id: ");
            Empid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Emp name: ");
            Ename = Console.ReadLine();
            Console.Write("Enter Salary: ");
            Salary= Convert.ToDouble(Console.ReadLine());
         }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee id: {Empid}");
            Console.WriteLine($"Employee name: {Ename}");
            Console.WriteLine($"Employee salary: {Salary}");
            Console.WriteLine($"***********************************************************\n");
        }
    }
}


