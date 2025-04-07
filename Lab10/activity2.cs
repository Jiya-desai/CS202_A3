using System;

namespace activity2
{
    class Calculator
    {
        private double num1;
        private double num2;
        public Calculator(double num1, double num2) // Constructor
        {
            this.num1 = num1;
            this.num2 = num2;
        }
        public double Add()  // Addition method
        {
            return num1 + num2;
        }
        public double Subtract() // Subtraction method
        {
            return num1 - num2;
        }
        public double Multiply() // Multiplication method
        {
            return num1 * num2;
        }
        public double Divide() // Division method
        {
            return num1 / num2;
        }
        public bool IsSumEven() // Check if the sum is even or odd
        {
            return (num1 + num2) % 2 == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator Program");

            // Get first number from user
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            // Get second number from user
            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            // Create Calculator object
            Calculator calc = new Calculator(num1, num2);

            // Calculate and display results
            Console.WriteLine($"Addition: {calc.Add()}");
            Console.WriteLine($"Subtraction: {calc.Subtract()}");
            Console.WriteLine($"Multiplication: {calc.Multiply()}");
            Console.WriteLine($"Division: {calc.Divide()}");

            // Check if sum is even or odd
            string evenOrOdd = calc.IsSumEven() ? "even" : "odd";
            Console.WriteLine($"The sum is {evenOrOdd}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
