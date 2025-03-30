using System;
using System.Linq;

namespace AssignmentTwo
{
    class Arrayassigntwo
    {
        public static void avgval()
        {
            int[] a = { 1, 2, 3, 4, 5 };
            double avg = a.Average();
            Console.WriteLine("Elements are: "+string.Join(",", a));
            Console.WriteLine($"Average is {avg}"); 
        }

        public static void minmax() //getting inputs from user
        {
            Console.Write($"Enter total count of elements: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] num = new int[size];                        
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter element {i+1}: ");
                num[i] = Convert.ToInt32(Console.ReadLine());
            }
            int min = num.Min();
            int max = num.Max();
            Console.Write($"Minimum value from the elements is: {min}\n");
            Console.Write($"Maximum value from the elements is: {max}");
        }

        //Getting 10 students and marks and displaying some operations
        public static void marks()
        {
            int[] mark = new int[10];
            Console.WriteLine("TEN STUDENTS MARKS");
            for (int i = 0;i < mark.Length;i++)
            {
                Console.Write($"Enter mark {i + 1}: ");
                mark[i] = Convert.ToInt32(Console.ReadLine());
            }
            //getting answers through in-built func
            int tot = mark.Sum();
            double avg = mark.Average();
            int min = mark.Min();
            int max = mark.Max();
            int[] ascending = mark.OrderBy(x => x).ToArray();
            int[] descending = mark.OrderByDescending(x => x).ToArray();

            Console.WriteLine($"Total marks: {tot}");
            Console.WriteLine($"Average marks: {avg}");
            Console.WriteLine($"Minimum marks: {min}");
            Console.WriteLine($"Maximum marks: {max}");
            Console.WriteLine($"Ascending order: {string.Join(",", ascending)}");
            Console.WriteLine($"Descending order: {string.Join(",", descending)}");

            /*getting answers without using in-built func
            //a)Sum of total
            int tot = 0;
            for (int i = 0; i < mark.Length; i++)
            {
                tot += mark[i];
            }
            //b)Average of marks
            double avg = (double)tot / mark.Length;
            //c)Minimum & Maximum marks
            int min = mark[0], max = mark[0];
            for(int i = 1; i < mark.Length; i++)
            {
                if (mark[i] < min) min = mark[i];
                if (mark[i] > max) max = mark[i];
            }
            Console.WriteLine($"Total marks: {tot}");
            Console.WriteLine($"Average marks: {avg}");
            Console.WriteLine($"Minimum marks: {min}");
            Console.WriteLine($"Maximum marks: {max}");*/
        }

        //Copy the elements of one array into another array without inbuilt
        public static void copy()
        {
            //getting array values from user
            Console.Write($"Enter array element count: ");
            int size = Convert.ToInt32 (Console.ReadLine());
            int[] orgnl = new int[size];
            for(int i = 0; i < size; i++)
            {
                Console.Write($"Enter element {i+1}: ");
                orgnl[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] copied = new int[orgnl.Length];
            //using for loop for copying manually
            for(int i = 0; i < orgnl.Length;i++)
            {
                copied[i] = orgnl[i];
            }   
            //displaying copied array elements
            Console.Write($"Copied array: "+string.Join (",", copied));
        }
    }
}
