using System;
namespace AssignmentTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            swap();
            pattern();
            days();

            //Calling program from new class file
            Arrayassigntwo.avgval();
            Arrayassigntwo.minmax();
            Arrayassigntwo.marks();
            Arrayassigntwo.copy();

        }
        public static void swap()
        {
            Console.WriteLine($"Swapping Two numbers");
            int a, b, temp;
            Console.WriteLine($"Enter a and b values: ");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());          
            Console.WriteLine($"BEFORE SWAPPING:\n A is {a} and B is {b}");
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"AFTER SWAPPING:\n A is {a} and B is {b}");
        }

        public static void pattern()
        {
            Console.Write($"Enter a digit to print as pattern: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} {0} {0} {0}",a);
            Console.WriteLine("{0}{0}{0}{0}",a);
            Console.WriteLine($"{a} {a} {a} {a}");
            Console.WriteLine($"{a}{a}{a}{a}");

        }

        public static void days()
        {
            Console.Write($"Enter number(1-7) to get weekday value : ");
            int a = Convert.ToInt32(Console.ReadLine());
            switch(a)
            {
                case 1:
                    Console.WriteLine($"Monday");
                    break;
                case 2:
                    Console.WriteLine($"Tuesday");
                    break;
                case 3:
                    Console.WriteLine($"Wednesday");
                    break;
                case 4:
                    Console.WriteLine($"Thursday");
                    break;
                case 5:
                    Console.WriteLine($"Friday");
                    break;
                case 6:
                    Console.WriteLine($"Saturday");
                    break;
                case 7:
                    Console.WriteLine($"Sunday");
                    break;
                default:
                    Console.WriteLine($"Invalid number");
                    break;
            }
        }
    }
}
