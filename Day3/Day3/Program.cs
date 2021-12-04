using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputText = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\input.txt");
            int wordLenght = inputText[0].Length;
            int[] bitCount = new int[wordLenght];
            foreach (string line in inputText)
            {
                for (int i = 0; i < wordLenght; i++)
                {
                    if (line[i] == '1')
                    {
                        bitCount[i] += 1;
                    }
                }
            }

            //Part One
            int gammaRate = 0;
            int epsilonRate = 0;
            for (int i = 0; i < wordLenght; i++)
            {
                gammaRate <<= 1;
                epsilonRate <<= 1;
                if (bitCount[i] >= inputText.Length / 2)
                {
                    gammaRate += 1;
                }
                else
                {
                    epsilonRate += 1;
                }
            }

            Console.WriteLine($"Part One:\n" +
                              $"Gama Rate: b_{Convert.ToString(gammaRate, 2)} ({gammaRate})\n" +
                              $"Epsilon Rate: b_{Convert.ToString(epsilonRate, 2)} ({epsilonRate})\n" +
                              $"Power Consumption: {gammaRate * epsilonRate}");



            //Part Two
            List<string> inputList = new();

            foreach (string line in inputText)
            {
                inputList.Add(line);
            }

            for (int i = 0; i < wordLenght; i++)
            {
                int count = 0;
                foreach (string line in inputList)
                {
                    if (line[i] == '1')
                    {
                        count += 1;
                    }
                }

                char mostBit = '0';
                if (count > (inputList.Count - 1) / 2)
                {
                    mostBit = '1';
                }

                List<string> newInput = new();
                foreach (string line in inputList)
                {
                    if (line[i] == mostBit)
                    {
                        newInput.Add(line);
                    }
                }

                inputList = newInput;

                if (inputList.Count <= 1)
                {
                    break;
                }
            }

            int oxygenRating = Convert.ToInt32(inputList[0], 2);

            inputList.Clear();

            foreach (string line in inputText)
            {
                inputList.Add(line);
            }

            for (int i = 0; i < wordLenght; i++)
            {
                int count = 0;
                foreach (string line in inputList)
                {
                    if (line[i] == '1')
                    {
                        count += 1;
                    }
                }

                char leastBit = '0';
                if (count <= (inputList.Count - 1) / 2)
                {
                    leastBit = '1';
                }

                List<string> newInput = new();
                foreach (string line in inputList)
                {
                    if (line[i] == leastBit)
                    {
                        newInput.Add(line);
                    }
                }

                inputList = newInput;

                if (inputList.Count <= 1)
                {
                    break;
                }
            }
            int co2Rating = Convert.ToInt32(inputList[0], 2);
            Console.WriteLine($"\nPart Two:\n" +
                  $"Oxygen Rating: {oxygenRating}\n" +
                  $"CO2 Rating: {co2Rating}\n" +
                  $"Power Consumption: {oxygenRating * co2Rating}");
        }
    }
}
