using System;

namespace activity3
{
    class MathOperations
    {
        // Function to calculate factorial
        public long CalculateFactorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Factorial is not defined for negative numbers");
            if (number == 0 || number == 1)
                return 1;
            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        // Function to print numbers from 1 to n using for loop
        public void PrintNumbers(int n)
        {
            Console.WriteLine($"Printing numbers from 1 to {n}:");
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MathOperations math = new MathOperations();
            // Using for loop to print numbers from 1 to 10
            math.PrintNumbers(10);
            // Using while loop to keep asking for input until user enters "exit"
            string userInput = "";
            while (userInput.ToLower() != "exit")
            {
                Console.WriteLine("\nEnter a number to calculate factorial (or type 'exit' to quit): ");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "exit")
                    break;
                try
                {
                    int number = int.Parse(userInput);
                    long factorial = math.CalculateFactorial(number);
                    Console.WriteLine($"Factorial of {number} is: {factorial}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number or 'exit'.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Result is too large to calculate. Try a smaller number.");
                }
            }
            Console.WriteLine("Program ended. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
