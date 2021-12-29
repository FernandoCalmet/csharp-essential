using System;

namespace _1.Basics.Lesson05.SumGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the first integer:");
            int first = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the second integer:");
            int second = Convert.ToInt32(Console.ReadLine());

            int result = first + second;
            Console.WriteLine($"The result is {result}");

            Console.ReadKey();
        }
    }
}
