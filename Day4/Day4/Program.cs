using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {

        struct BingoBoardNumber
        {
            public int Number { get; private set; }
            public bool Matched { get; set; }

            public BingoBoardNumber(int number)
            {
                Number = number;
                Matched = false;
            }
        }

        static void Main(string[] args)
        {
            string[] inputText = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\input.txt");

            List<int> bingoNums = inputText[0]?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<List<List<BingoBoardNumber>>> allBoards = new();

            List<List<BingoBoardNumber>> board = new();
            for (int i = 2; i < inputText.Length; i++)
            {
                List<int> rowNums = inputText[i]?.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                if (rowNums.Count > 0)
                {
                    List<BingoBoardNumber> rowNumsTuple = new();

                    foreach (int number in rowNums)
                    {
                        rowNumsTuple.Add(new BingoBoardNumber(number));
                    }

                    board.Add(rowNumsTuple);
                }
                else
                {
                    allBoards.Add(board);
                    board = new();
                }
            }
            //Add last board
            if (board.Count > 0)
            {
                allBoards.Add(board);
            }


            List<List<List<BingoBoardNumber>>> winningBoards = new();
            List<int> winningNumber = new();

            foreach (var bingoNum in bingoNums)
            {
                for (int b = 0; b < allBoards.Count; b++)
                {
                    for (int row = 0; row < allBoards[b].Count; row++)
                    {
                        for (int num = 0; num < allBoards[b][row].Count; num++)
                        {
                            if (bingoNum == allBoards[b][row][num].Number)
                            {
                                BingoBoardNumber bingoBoardNumber = allBoards[b][row][num];
                                bingoBoardNumber.Matched = true;
                                allBoards[b][row][num] = bingoBoardNumber;
                                break;
                            }
                        }
                    }
                }


                for (int b = 0; b < allBoards.Count; b++)
                {
                    bool winner = false;
                    //Check Rows
                    for (int row = 0; row < allBoards[b].Count; row++)
                    {
                        bool rowMatched = true;
                        for (int col = 0; col < allBoards[b][row].Count; col++)
                        {
                            if (!allBoards[b][row][col].Matched)
                            {
                                rowMatched = false;
                                break;
                            }
                        }

                        //Winner
                        if (rowMatched)
                        {
                            winningBoards.Add(allBoards[b]);
                            winningNumber.Add(bingoNum);
                            allBoards.Remove(allBoards[b]);
                            winner = true;
                            break;
                        }
                    }

                    if (winner)
                    {
                        continue;
                    }

                    //Check Cols
                    for(int col = 0; col < allBoards[b][0].Count;col++)
                    {
                        bool colMatched = true;
                        for (int row = 0; row < allBoards[b].Count; row++)
                        {
                            if (!allBoards[b][row][col].Matched)
                            {
                                colMatched = false;
                                break;
                            }
                        }

                        //Winner
                        if (colMatched)
                        {
                            winningBoards.Add(allBoards[b]);
                            winningNumber.Add(bingoNum);
                            allBoards.Remove(allBoards[b]);
                            winner = true;
                            break;
                        }
                    }
                }
            }


            int sum = 0;
            if (winningBoards[0] != null)
            {
                for (int row = 0; row < winningBoards[0].Count; row++)
                {
                    for (int num = 0; num < winningBoards[0][row].Count; num++)
                    {
                        if (!winningBoards[0][row][num].Matched)
                        {
                            sum += winningBoards[0][row][num].Number;
                        }
                    }
                }
            }

            Console.WriteLine("Part One: " + sum * winningNumber[0]);


            sum = 0;
            if (winningBoards.Last() != null)
            {
                for (int row = 0; row < winningBoards.Last().Count; row++)
                {
                    for (int num = 0; num < winningBoards.Last()[row].Count; num++)
                    {
                        if (!winningBoards.Last()[row][num].Matched)
                        {
                            sum += winningBoards.Last()[row][num].Number;
                        }
                    }
                }
            }


            Console.WriteLine("Part Two: " + sum * winningNumber.Last());

            Console.ReadLine();
        }
    }
}
