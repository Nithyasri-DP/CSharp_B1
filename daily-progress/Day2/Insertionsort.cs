using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int[] intArray = new int[5];
            Console.WriteLine("Enter element data");
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }

            // sorting the array
            for (int j = 0; j <= intArray.Length - 2; j++)
            {
                for (int i = 0; i <= intArray.Length - 2; i++)
                {
                    count = count + 1;
                    if (intArray[i] > intArray[i + 1])
                     {
                        int temp = intArray[i + 1];
                        intArray[i + 1] = intArray[i];
                        intArray[i] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted Array");

            foreach (int item in intArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("The loop iterated for : " + count);
Console.Read();
        }

    }
}
