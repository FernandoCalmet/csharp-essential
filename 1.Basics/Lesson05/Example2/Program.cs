using System;

namespace _1.Basics.Lesson05.FullNameGenerator
{
    class Program
    {
        static void Main(string[] args)
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
