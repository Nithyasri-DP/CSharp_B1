 using System;
namespace ClassWorks
{
public class JaggedArr
   {
public void Jaggedclassone()
       {
            Console.WriteLine($"Jagged array's total row number: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Enter total count of elements in row {i+1}: ");
                int size = Convert.ToInt32(Console.ReadLine());
                jaggedArray[i] = new int[size];

                Console.WriteLine($"Enter elements: ");
                for (int j = 0; j < size; j++)
                {
                    jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine($"Entered elements: ");
            for (int i = 0;i < jaggedArray.Length;i++)
            {
            for (int j = 0; j < jaggedArray[i].Length;j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();    
            }
         }
    }
}
 
 
 
 
 
 
