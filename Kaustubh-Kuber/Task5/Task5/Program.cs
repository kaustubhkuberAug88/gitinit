using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string operation = args[0];

                if (operation.ToLower() == "add")
                {
                    string delimitor = ExtractDelimitor(args);

                    int totalSum = 0;

                    totalSum = PerformSum(args, totalSum, delimitor);

                    if (totalSum < 0)
                    {
                        Console.WriteLine("Error: Negative numbers not allowed.");
                    }
                    else
                    {
                        Console.WriteLine("Total Sum of Numbers::{0}", totalSum);
                    }
                }
            }

            Console.ReadLine();
        }

        private static string ExtractDelimitor(string[] args)
        {
            string[] splitChars = new string[] { "\\\\" };
            string delimitor = args[1].Split(splitChars, StringSplitOptions.None)[1];
            return delimitor;
        }


        private static int PerformSum(string[] args, int totalSum, string delimitor)
        {
            if (args.Length > 1)
            {
                List<int> numbersToAdd = new List<int>();
                string[] charSplit = new string[] { delimitor };
                string currentNumber = "0";

                foreach (string number in args[1].Split(charSplit, StringSplitOptions.None))
                {
                    if (number != "\\\\")
                    {
                        currentNumber = number.Trim('\\');
                        if (Convert.ToInt32(currentNumber) < 0)
                        {
                            return -1;
                        }
                        numbersToAdd.Add(Convert.ToInt32(currentNumber));
                    }
                }

                totalSum = numbersToAdd.Sum();
            }
            return totalSum;
        }
    }
}
