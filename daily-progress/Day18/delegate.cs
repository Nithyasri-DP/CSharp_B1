using System;

namespace Delegate
{
    delegate int NumberChanger(int n);

    internal class Program
    {
        public static void Main(string[] args)
        {
           Multicast();
           SingleCast();
        }
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultiplyNum(int q)
        {
            num *= q;
            return num;
        }

        public static int getNum()
        {
            return num;
        }

        //Multicast delegate where 35 is lost
        public static void Multicast()
        {
            NumberChanger nc1 = new NumberChanger(AddNum);
            nc1 += MultiplyNum;
            // AddNum(25) then MultiplyNum(25)
            nc1(25); 
            Console.WriteLine("Final Value of Num: " + getNum());
        }

        //Singlecast to preserve intermediate value
        public static void SingleCast()
        {
            NumberChanger add = new NumberChanger(AddNum);
            add(25); // num = 35
            Console.WriteLine("After AddNum: " + getNum());

            NumberChanger multiply = new NumberChanger(MultiplyNum);
            multiply(25); // num = 875
            Console.WriteLine("After MultiplyNum: " + getNum());
        }
    }
}
