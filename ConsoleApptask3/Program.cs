using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int low, high;

            // Get a valid positive low number from the user
            do
            {
                low = GetIntegerInput("Enter a positive low number: ");
                if (low <= 0)
                {
                    Console.WriteLine("Low number must be positive.");
                }
            } while (low <= 0);

            // Get a valid high number greater than the low number from the user
            do
            {
                high = GetIntegerInput("Enter a high number greater than the low number: ");
                if (high <= low)
                {
                    Console.WriteLine("High number must be greater than the low number.");
                }
            } while (high <= low);
            // Create an array to hold numbers between low and high
            int[] numberArray = new int[high - low + 1];
            // Fill the array with numbers in ascending order
            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = low + i;
            }
            // Reverse the array to get numbers in descending order
            Array.Reverse(numberArray);
            // Create a new file "numbers.txt" and write numbers to it
            string fileName = "numbers.txt";
            File.WriteAllLines(fileName, Array.ConvertAll(numberArray, n => n.ToString()));

            Console.WriteLine($"Numbers from {low} to {high} have been written to {fileName} in reverse order.");

            // Wait for user input before closing the console window
            Console.ReadLine();
        }
           // in order to get integer input from the user with validation
        static int GetIntegerInput(string prompt)
        {
            int userInput;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }
    }
}
