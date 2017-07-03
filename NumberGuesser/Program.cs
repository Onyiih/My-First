using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class Program
    {
        static int userInput = 0;
        static void Main(string[] args)
        {
            GetAppInfo();

            GetUserInfo();

            //This is where action begins
            while (true)
            {
                Random random;
                random = new Random();
                int correctNumber = random.Next(10);

                Console.WriteLine("Guess a number between 0 and 10");
                string input = Console.ReadLine();

                //adding validation for exception
                //int.TryParse(input, out userInput);

                GetInput(input);

                while (userInput != correctNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Number!!! Please try again...");
                    Console.ResetColor();

                    //adding validation for handling exception

                    input = Console.ReadLine();

                    //int.TryParse(input, out userInput);
                    GetInput(input);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations!!! You are correct");
                Console.ResetColor();

                Console.WriteLine("Would you like to play again? Yes or No");
                string reply = Console.ReadLine().ToUpper();
                if (reply == "YES" || reply == "Y")
                {
                    continue;
                }
                else
                {
                    return;
                }

            }//While loop ends here

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        //Method to get user information
        private static void GetUserInfo()
        {
            Console.WriteLine("\nPlease introduce yourself:");
            string userName = Console.ReadLine();
            Console.WriteLine($"Welcome {userName} \n");
            //Console.WriteLine(Environment.NewLine);
        }

        //method to print App information
        static void GetAppInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This is a number guessing game.");
            Console.WriteLine("Version 1.3");
            Console.ResetColor();
        }
        //added new method
        /*private static void GetInput(string userinput)
        {
            int input = 0;
            try
            {
                input = int.Parse(userinput);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Invalid format, type only numeric values");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("Enter a value");
            }
            catch(OverflowException ex)
            {
                Console.WriteLine("maximum number exceeded");
            }
        }*/

        private static void GetInput(string input)
        {
            while (true)
            {
                try
                {
                    userInput = int.Parse(input);
                    return;
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input: enter only numeric values");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something bad happened");
                    Console.ResetColor();
                }
                //retry
                Console.WriteLine("Please, enter another value:");
                input = Console.ReadLine();
            }
        }

    }


}
