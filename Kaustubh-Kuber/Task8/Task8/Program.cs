using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string operation = args[0];
                List<int> negativeNumbers = new List<int>();

                if (operation.ToLower() == "add")
                {
                    string delimitor = ExtractDelimitor(args);

                    int totalSum = 0;

                    totalSum = PerformSum(args, totalSum, delimitor, ref negativeNumbers);

                    if (negativeNumbers.Count() > 0 && totalSum < 0)
                    {
                        Console.WriteLine("Error: Negative numbers ({0}) not allowed.", string.Join(",", negativeNumbers.Select(n => n.ToString()).ToArray()));
                    }
                    else
                    {
                        Console.WriteLine("Total Sum of Numbers::{0}", totalSum);
                    }
                }
                else if (operation.ToLower() == "multiply")
                {
                    string delimitor = ExtractDelimitor(args);

                    int total = 0;

                    total = PerformMultiplication(args, total, delimitor, ref negativeNumbers);

                    if (negativeNumbers.Count() > 0 && total < 0)
                    {
                        Console.WriteLine("Error: Negative numbers ({0}) not allowed.", string.Join(",", negativeNumbers.Select(n => n.ToString()).ToArray()));
                    }
                    else
                    {
                        Console.WriteLine("Total Result of Numbers::{0}", total);
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


        private static int PerformSum(string[] args, int totalSum, string delimitor, ref List<int> negativeNumbers)
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
                            negativeNumbers.Add(Convert.ToInt32(currentNumber));
                        }

                        if (negativeNumbers.Count() == 0)
                        {
                            numbersToAdd.Add(Convert.ToInt32(currentNumber));
                        }
                    }
                }

                if (negativeNumbers.Count() > 0)
                {
                    return -1;
                }

                totalSum = numbersToAdd.Sum();
            }
            return totalSum;
        }

        private static int PerformMultiplication(string[] args, int total, string delimitor, ref List<int> negativeNumbers)
        {
            if (args.Length > 1)
            {
                List<int> numbersToMultiply = new List<int>();
                string[] charSplit = new string[] { delimitor };
                string currentNumber = "0";

                foreach (string number in args[1].Split(charSplit, StringSplitOptions.None))
                {
                    if (number != "\\\\")
                    {
                        currentNumber = number.Trim('\\');
                        if (Convert.ToInt32(currentNumber) < 0)
                        {
                            negativeNumbers.Add(Convert.ToInt32(currentNumber));
                        }

                        if (negativeNumbers.Count() == 0)
                        {
                            numbersToMultiply.Add(Convert.ToInt32(currentNumber));
                        }
                    }
                }

                if (negativeNumbers.Count() > 0)
                {
                    return -1;
                }

                total = numbersToMultiply.Aggregate((num1, num2) => num1 * num2);
            }
            return total;
        }
    }
}
