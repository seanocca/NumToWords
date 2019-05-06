using System;
using System.Collections.Generic;

namespace NumbersToWords
{
    class Program
    {
        /// <summary> Used to access the NumToWords class </summary>
        private static NumToWords conversion = new NumToWords();


        static void Main(string[] args)
        {
            FunctionalTesting();
            RecursiveProgram();
        }

        /// <summary>
        /// Created this function to provide simple testing example
        /// of how my routine works in different situations
        /// </summary>
        private static void FunctionalTesting()
        {
            Console.WriteLine("Testing Framework:");

            List<string> tests = new List<string>()
            {
                "10.28",
                "128.56",
                "4285.92",
                "3742829.62",
                "1,287,612.23",
                "765,657,897.8812"
            };

            foreach(string test in tests)
            {
                Console.WriteLine("Input: " + test);
                string output = conversion.ConvertNumbersToWords(test);
                Console.WriteLine("Output: " + output);
                Console.WriteLine("TEST COMPLETE");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Recursively calls this program so the user can convert as many numbers to words as they want
        /// </summary>
        private static void RecursiveProgram()
        {
            // Ask the user to enter a number
            string initialRequest = "Please Enter a Valid Number Below to Convert to Words: ";
            Console.WriteLine(initialRequest);

            // Take the entered number clean any foreign items from the string
            // and convert it into a string output 
            string number = Console.ReadLine();
            number = number.Replace(",", "");
            if (!double.TryParse(number, out double result))
            {
                Console.WriteLine("This is NOT a Valid Number. Please Try Again.");
                RecursiveProgram();
            } else
            {
                string output = conversion.ConvertNumbersToWords(number);
                string placeholder = "Calculating Conversion to Words...";
                Console.WriteLine(placeholder);
                Console.WriteLine(output);
            }

            // Prompt the user on how to convert again
            string reRunQuestion = "Press Ctrl+C to Exit or Press Any Key to Convert Again...";
            Console.Write(reRunQuestion);

            // Wait for the user to enter a key
            Console.ReadLine();

            // Calls the program again so it can run 
            RecursiveProgram();
        }

    }
}
