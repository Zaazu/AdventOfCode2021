using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        public struct Command
        {
            public string Direction { get; private set; }
            public int Value { get; private set; }

            public Command(string direction, int value)
            {
                Direction = direction;
                Value = value;
            }
        }

        static void Main(string[] args)
        {
            string[] inputText = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\input.txt");

            List<Command> commands = new();

            foreach (string line in inputText)
            {
                string[] split = line.Split(' ');

                if (!int.TryParse(split[1], out int value))
                {
                    Console.WriteLine("Parse error");
                    return;
                }

                commands.Add(new Command(split[0].ToLower(), value));
            }

            //Part One
            int position = 0;
            int depth = 0;

            foreach(Command command in commands)
            {
                if(command.Direction == "forward")
                {
                    position += command.Value;
                }
                else if (command.Direction == "up")
                {
                    depth -= command.Value;
                }
                else if (command.Direction == "down")
                {
                    depth += command.Value;
                }
            }
            Console.WriteLine("Part One: " + position + " x " + depth + " = " + (position * depth));

            //Part Two
            position = 0;
            depth = 0;
            int aim = 0;

            foreach (Command command in commands)
            {
                if (command.Direction == "forward")
                {
                    position += command.Value;
                    depth += (aim * command.Value);
                }
                else if (command.Direction == "up")
                {
                    aim -= command.Value;
                }
                else if (command.Direction == "down")
                {
                    aim += command.Value;
                }
            }

            Console.WriteLine("Part Two: " + position + " x " + depth + " = " + (position * depth));

            Console.ReadLine();
        }
    }
}
