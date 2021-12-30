using System;

namespace _1.Basics
{
    public class Program
    {
        static int option = 0;

        static void Main(string[] args)
        {
            Lesson05.Examples lesson05 = new Lesson05.Examples();
            Lesson06.Examples lesson06 = new Lesson06.Examples();
            Lesson07.Examples lesson07 = new Lesson07.Examples();

            do
            {
                Console.WriteLine("Select a number option: \n");
                Console.WriteLine("0: Lesson05 - SumGenerator");
                Console.WriteLine("1: Lesson05 - FullNameGenerator");
                Console.WriteLine("2: Lesson06 - Example 1");
                Console.WriteLine("3: Lesson06 - Example 2");
                Console.WriteLine("4: Lesson07 - Example 1");
                Console.WriteLine("5: Lesson07 - Example 2");
                Console.WriteLine("6: Lesson07 - Example 3");
                Console.WriteLine("7: Lesson07 - Example 4");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        lesson05.SumGenerator();
                        break;
                    case 1:
                        lesson05.FullNameGenerator();
                        break;
                    case 2:
                        lesson06.Example1();
                        break;
                    case 3:
                        lesson06.Example2();
                        break;
                    case 4:
                        lesson07.Example1();
                        break;
                    case 5:
                        lesson07.Example2();
                        break;
                    case 6:
                        lesson07.Example3();
                        break;
                    case 7:
                        lesson07.Example4();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadKey();
            }
            while (option < 8);
        }
    }
}
