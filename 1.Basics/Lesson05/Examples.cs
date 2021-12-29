using System;

namespace _1.Basics.Lesson05
{
    public class Examples
    {
        public void SumGenerator()
        {
            Console.WriteLine("Write the first integer:");
            int first = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the second integer:");
            int second = Convert.ToInt32(Console.ReadLine());

            int result = first + second;
            Console.WriteLine($"The result is {result}");

            Console.ReadKey();
        }

        public void FullNameGenerator()
        {
            Console.WriteLine("What is your first name:");
            string name = Console.ReadLine();

            Console.WriteLine("What is your last name:");
            string lastName = Console.ReadLine();

            string fullName = name + " " + lastName;
            Console.WriteLine($"Your full name is: {fullName}");

            Console.ReadKey();
        }
    }
}
