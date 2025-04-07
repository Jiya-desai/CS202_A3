using System;

namespace activity2_with_exception_handling
{
    class Calculator
    {
        private double num1;
        private double num2;

        // Constructor
        public Calculator(double num1, double num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        // Addition method
        public double Add()
        {
            return num1 + num2;
        }

        // Subtraction method
        public double Subtract()
        {
            return num1 - num2;
        }

        // Multiplication method
        public double Multiply()
        {
            return num1 * num2;
        }

        // Division method with exception handling
        public double Divide()
        {
            if (num2 == 0)
                throw new DivideByZeroException("Cannot divide by zero");

            return num1 / num2;
        }

        // Check if the sum is even or odd
        public bool IsSumEven()
        {
            return (num1 + num2) % 2 == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator with Exception Handling");

            try
            {
                // Get first number from user
                Console.Write("Enter first number: ");
                double num1 = GetNumberFromUser();

                // Get second number from user
                Console.Write("Enter second number: ");
                double num2 = GetNumberFromUser();

                // Create Calculator object
                Calculator calc = new Calculator(num1, num2);

                // Calculate and display results
                Console.WriteLine($"Addition: {calc.Add()}");
                Console.WriteLine($"Subtraction: {calc.Subtract()}");
                Console.WriteLine($"Multiplication: {calc.Multiply()}");

                // Handle division separately for division by zero
                try
                {
                    Console.WriteLine($"Division: {calc.Divide()}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Division Error: {ex.Message}");
                }

                // Check if sum is even or odd
                string evenOrOdd = calc.IsSumEven() ? "even" : "odd";
                Console.WriteLine($"The sum is {evenOrOdd}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format. Please enter valid numbers.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Number is too large or too small for double data type.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Program execution completed.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        // Helper method to get number from user with exception handling
        static double GetNumberFromUser()
        {
            while (true)
            {
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                }
                catch (OverflowException)
                {
                    Console.Write("Number too large. Please enter a smaller number: ");
                }
            }
        }
    }
}
