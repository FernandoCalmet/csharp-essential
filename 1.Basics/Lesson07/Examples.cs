using System;

namespace _1.Basics.Lesson07
{
    public class Examples
    {
        public void Example1()
        {
            Console.WriteLine("Enter the first number: ");
            int first = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            int second = Convert.ToInt32(Console.ReadLine());

            if (first > second)
            {
                Console.WriteLine($"The greater number is {first}");
            }
            else
            {
                Console.WriteLine($"The greater number is {second}");
            }

            Console.ReadKey();
        }

        public void Example2()
        {
            Console.WriteLine("Enter your random string: ");
            string sentence = Console.ReadLine();

            Console.WriteLine("Choose your color: r for Red, g for Green, o for Other");
            char color = Convert.ToChar(Console.ReadLine());

            if (color == 'r')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(sentence);
            }
            else if (color == 'g')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sentence);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(sentence);
            }

            Console.ReadKey();
        }

        public void Example3()
        {
            Console.WriteLine("Enter your number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number > 50)
            {
                if (number % 2 == 0) //reminder in division with two for even numbers is always a zero.
                {
                    Console.WriteLine(number * 2);
                }
                else
                {
                    Console.WriteLine(number * 3);
                }
            }
            else
            {
                Console.WriteLine(number * 5);
            }

            Console.ReadKey();
        }

        public void Example4()
        {
            Console.WriteLine("Enter the month number from 1 to 12");
            int month = Convert.ToInt32(Console.ReadLine());

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("Number of days is 31");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("Number of days is 30");
                    break;
                case 2:
                    Console.WriteLine("Number of days is 28 or 29");
                    break;
                default:
                    Console.WriteLine("Your number is not between 1 and 12");
                    break;
            }

            Console.ReadKey();
        }
    }
}
