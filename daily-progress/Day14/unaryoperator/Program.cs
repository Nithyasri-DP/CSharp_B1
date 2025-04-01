using System;
namespace dayfour
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine($"Unary Operator Overloading");
            Distance d1 = new Distance();
            d1.dist = 25;
            Console.WriteLine("Before Increment:");
            d1.Display();
            // Calls the overloaded ++ operator
            d1 = ++d1;  
            Console.WriteLine("After Increment:");
            d1.Display();
            Console.Read();
        }
    }

    class Distance
    {
        public int dist;

        // Unary Operator Overloading (++)
        public static Distance operator ++(Distance a)
        {
            Distance temp = new Distance();
            temp.dist = a.dist + 1; // Increment distance by 1
            return temp;
        }
        public void Display()
        {
            Console.WriteLine("Distance: " + dist);
        }
    }
}
