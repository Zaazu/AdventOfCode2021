using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            string[] inputText = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\input.txt");
            List<int> input = new();

            foreach (string line in inputText)
            { 
                if (!int.TryParse(line, out int parsed))
                {
                    Console.WriteLine("Conversion Error");
                    break;
                }

                input.Add(parsed);
            }

            //Part One
            int numIncreased = 0;
            for (int i = 1; i < input.Count; i++)
            {
                if(input[i - 1] < input[i])
                {
                    numIncreased++;
                }
            }
            Console.WriteLine("Part One Increased: " + numIncreased);

            //Part Two
            numIncreased = 0;
            for (int i = 3; i < input.Count; i++)
            {
                if ((input[i - 3] + input[i - 2] + input[i - 1]) < (input[i - 2] + input[i - 1] + input[i]))
                {
                    numIncreased++;
                }
            }
            Console.WriteLine("Part Two Increased: " + numIncreased);

            Console.ReadLine();
        }
    }
}
