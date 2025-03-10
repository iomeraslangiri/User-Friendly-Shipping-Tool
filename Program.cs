using System;

namespace PackageExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Display the welcome message
                Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
                
                // Get weight with validation
                float weight = InputHelper.GetValidFloat("Please enter the package weight:");
                
                // Check the weight limit
                if (weight > 50)
                {
                    Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                    return;
                }
                
                // Get dimensions with validation
                float width = InputHelper.GetValidFloat("Please enter the package width:");
                float height = InputHelper.GetValidFloat("Please enter the package height:");
                float length = InputHelper.GetValidFloat("Please enter the package length:");
                
                // Check the total dimensions
                float totalDimensions = width + height + length;
                if (totalDimensions > 50)
                {
                    Console.WriteLine("Package too big to be shipped via Package Express.");
                    return;
                }
                
                // Calculate the shipping quote
                float dimensionProduct = width * height * length;
                float quoteValue = (dimensionProduct * weight) / 100;
                
                // Display the formatted quote
                Console.WriteLine($"Your estimated total for shipping this package is: ${quoteValue:F2}");
                Console.WriteLine("Thank you!");
            }
            catch (Exception ex)
            {
                // Display any unexpected errors
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Keep console window open
                Console.ReadLine();
            }
        }
    }
    
    /// <summary>
    /// Helper class for input validation
    /// </summary>
    public static class InputHelper
    {
        /// <summary>
        /// Gets a valid float input from the user with error handling
        /// </summary>
        /// <param name="prompt">The prompt message to display</param>
        /// <returns>A valid float value</returns>
        public static float GetValidFloat(string prompt)
        {
            float result;
            bool isValid = false;
            
            // Continue prompting until valid input is received
            do
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                
                // Try to parse the input
                isValid = float.TryParse(input, out result);
                
                // Check if the input is valid
                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                else if (result < 0)
                {
                    // Ensure the value is not negative
                    Console.WriteLine("Value cannot be negative. Please try again.");
                    isValid = false;
                }
                
            } while (!isValid);
            
            return result;
        }
    }
}