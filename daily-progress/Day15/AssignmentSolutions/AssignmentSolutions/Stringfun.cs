using System;
using System.Linq;

namespace AssignmentSolutions
{
    class Stringfunction
    {
        public static void stringfunc()
        {
            //Accepting a word and displaying its length
            Console.Write("Enter a word: ");
            string? word = Console.ReadLine();
            Console.WriteLine("Length of the word: " + word.Length);

            //Taking the accepted word and displaying its reverse
            string reversedWord = new string(word.Reverse().ToArray());
            Console.WriteLine("Reversed word: " + reversedWord);

            // Task 3: Accepting two words and check if they are the same
            Console.Write("Enter first word: ");
            string? firstWord = Console.ReadLine();
            Console.Write("Enter second word: ");
            string? secondWord = Console.ReadLine();

            if (firstWord == secondWord)
                Console.WriteLine("Both words are same");
            else
                Console.WriteLine("Both words are not same");
        }
    }
    class Stringfun
    {
        public static void Main()
        {
            Stringfunction.stringfunc(); // Calling main class program(string)
            StudentInherit.StudResult(); // Calling subclass program(student)
            Accommodation.Stay(); // Calling subclass program(dayscholar)
            Bank.Fundtransfer(); // Calling subclass program(bank)
        }
    }
}
