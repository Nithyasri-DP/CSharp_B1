using System;

namespace ClsAssignment
{
    public class Program
    {
        static void Main()
        {
            //ComparingNum();
            //IntSign();
            //ArithmeticOp();
            //MultiplicationTable();
            Sumoftwo();
        }

        //1) Comparing 2 integers are equal or not
        public static void ComparingNum()
        {
            Console.WriteLine("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
                Console.WriteLine("{0} and {1} are equal", num1, num2);
            else
                Console.WriteLine("{0} and {1} are not equal", num1, num2);
        }

        //2) Entered number is positive or not (using nested ternary)
        public static void IntSign()
        {
            Console.Write("Enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num > 0 ? $"{num} is Positive" : num < 0 ? $"{num} is Negative" : "Number is Zero");        
        }

     
        //3) Performing Multiple Operations (using switch statement)
        static void ArithmeticOp()
        {
            int num1, num2, res = 0;
            char op;
            Console.WriteLine("Enter operand 1: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter operator(+,-,*,/): ");
            op = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter operand 2: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case '+':
                    res = num1 + num2;
                    break;
                case '-':
                    res = num1 - num2;
                    break;
                case '*':
                    res = num1 * num2;
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Zero division Error");
                        return;
                    }
                    else
                        res = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Error Occured");
                    return;
            }
            Console.WriteLine($"{num1} {op} {num2} = {res}");
        }

        //4) Multiplication Table Values
        static void MultiplicationTable()
        {
            int num, i;
            Console.Write("Enter the number: ");
            num = Convert.ToInt32(Console.ReadLine());
            for(i=0; i<=10; i++)
            {
                Console.WriteLine($"{num} x {i} = {num*i}");
            }
        }

        //5) Add 2 numbers, if inputs are same then multiply added res by 3 (using ternary)
        static void Sumoftwo()
        {
            int num1, num2, sum;
            Console.Write("Enter first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            sum = num1 + num2;
            Console.WriteLine(num1 == num2 ? sum * 3 : sum);
        }
    }
}

