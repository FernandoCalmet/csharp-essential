using System;

namespace _1.Basics.Lesson06
{
    public class Examples
    {
        public void Example1()
        {
            string testString = "this is some string to use it for our example.";

            string partWithoutLength = testString.Substring(10);
            string partWithLength = testString.Substring(5, 10);

            Console.WriteLine(partWithoutLength);
            Console.WriteLine(partWithLength);

            Console.ReadKey();
        }

        public void Example2()
        {
            Console.WriteLine("Enter your full name, blank space separated");
            string fullName = Console.ReadLine();

            int blankPosition = fullName.IndexOf(' ');
            string name = fullName.Substring(0, blankPosition);
            string lastName = fullName.Substring(blankPosition + 1);

            Console.WriteLine(name);
            Console.WriteLine(lastName);

            Console.ReadKey();
        }
    }
}
