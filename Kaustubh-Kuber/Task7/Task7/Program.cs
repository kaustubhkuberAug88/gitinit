﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
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
                    int totalSum = 0;

                    totalSum = PerformSum(args, totalSum);

                    Console.WriteLine("Total Sum of Numbers::{0}", totalSum);
                }
            }

            Console.ReadLine();
        }

        private static int PerformSum(string[] args, int totalSum)
        {
            if (args.Length > 1)
            {
                List<int> numbersToAdd = new List<int>();

                foreach (string number in args[1].Split(','))
                {
                    if (Convert.ToInt32(number) <= 1000)
                    {
                        numbersToAdd.Add(Convert.ToInt32(number));
                    }
                }

                totalSum = numbersToAdd.Sum();
            }
            return totalSum;
        }
    }
}
