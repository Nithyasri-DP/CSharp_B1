/*using System;
namespace FirstCore_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sample Object Creation\n");
            Program pgm = new Program();
            pgm.GettingInputs();

            //calling non static int func
            int Result = pgm.Add(10, 5);
            Console.WriteLine($"Result is {Result}");   
        }
        public void GettingInputs() //using non-static method
        {
            string? fname, lname;
            Console.WriteLine("Enter ur first and last name: ");
            fname = Console.ReadLine(); 
            lname = Console.ReadLine();
            Console.WriteLine($"I am {fname} {lname}");
        }
        public int Add(int x, int y)
        {
            return x + y;
        }

    }
}
*/


