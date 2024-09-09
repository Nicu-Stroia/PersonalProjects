using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercitii2
{
    internal class CrossWords
    {
        public char[,] grid = new char[10, 10];
        public string word;
        public void GridInitialization()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        public void AddToGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                word = Console.ReadLine();
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = word[j];
                }
            }
        }

        List<string> list = new List<string>();
        public void AddToList()
        {
            string filePath = @"C:\Users\nicus\OneDrive\Desktop\Cuvinte CrossWords.txt";
            string[] wd = File.ReadAllLines(filePath);
            for (int i = 0; i < 19; i++)
            {
                list.Add(wd[i]);
            }
        }

        public void GameMeniu()
        {
            Console.WriteLine();
            Console.WriteLine("Game meniu:");
            Console.WriteLine("odd i and j");
            Console.WriteLine("even i and j");
            Console.WriteLine("vowels");
            Console.WriteLine("consonantes");
            Console.WriteLine("stop");
        }
        public void Game()
        {
            string input;
            string guessWd;
            int ct = 0;
            int columnsNr;
            int rowsNr;
            int dim;
            int tries = 3;
            char[,] gridSv = new char[10, 10];
            char[,] gridSv2 = new char[10, 10];
            string word2;
            int tries2 = 10;
            int ct3 = 0;
            int ct2 = 0;
            Console.WriteLine();
            Console.Write("Enter the level: ");
            input = Console.ReadLine();
            switch (input)
            {
                case "odd i and j":
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (i % 2 != 0 && j % 2 != 0)
                            {
                                gridSv[i, j] = grid[i, j];
                                Console.Write(grid[i, j]);
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("*");
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                case "even i and j":
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (i % 2 == 0 && j % 2 == 0)
                            {
                                gridSv[i, j] = grid[i, j];
                                Console.Write(grid[i, j]);
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("*");
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                case "vowels":
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (grid[i, j] == 'A' || grid[i, j] == 'E' || grid[i, j] == 'I' || grid[i, j] == 'O' || grid[i, j] == 'U')
                            {
                                gridSv[i, j] = grid[i, j];
                                Console.Write(grid[i, j]);
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("*");
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                case "consonants":
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (grid[i, j] != 'A' || grid[i, j] != 'E' || grid[i, j] != 'I' || grid[i, j] != 'O' || grid[i, j] != 'U')
                            {
                                gridSv[i, j] = grid[i, j];
                                Console.Write(grid[i, j]);
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("*");
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                case "stop":
                    Console.WriteLine("The game is over");
                    break;
                default:
                    Console.WriteLine("Re-enter the desired level!");
                    break;
            }
            while (tries > 0)
            {
                Console.Write("Enter a letter: ");
                guessWd = Console.ReadLine();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (grid[i, j] == guessWd[0])
                        {
                            gridSv[i, j] = guessWd[0];
                        }
                        else
                        {
                            ct++;
                        }
                    }
                }
                tries--;
                rowsNr = grid.GetLength(0);
                columnsNr = grid.GetLength(1);
                dim = rowsNr + columnsNr;
                if (ct == dim)
                {
                    Console.WriteLine("The letter doesn't exist!");
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (gridSv[i, j] == grid[i, j])
                    {
                        Console.Write(gridSv[i, j]);
                        Console.Write(" ");

                    }
                    else
                    {
                        Console.Write("*");
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            while (tries2 > 0)
            {
                Console.Write("Enter your word: ");
                word2 = Console.ReadLine();
                for (int i = 0; i < 10; i++)
                {
                    ct2 = 0;
                    for (int j = 0; j < word2.Length; j++)
                    {
                        if (grid[i, j] == word2[j] || grid[j, i] == word2[j])
                        {
                            gridSv2[i, j] = word2[j];
                            ct2++;
                        }
                    }
                    for (int t = 0; t < 19; t++)
                    {
                        if (ct2 >= word[t])
                        {
                            break;
                        }
                    }
                }
                if (ct2 >= word2.Length-1)
                {
                    Console.WriteLine("The word is correct");
                    ct3++;
                }
                if (ct2 <= word2.Length-1)
                {
                    Console.WriteLine("The word is wrong!");
                    tries2--;
                    Console.Write("You have ");
                    Console.Write(tries2);
                    Console.WriteLine(" more chances");
                }
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (gridSv2[i, j] == gridSv[i, j])
                        {
                            Console.Write(gridSv2[i, j]);
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("*");
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                if (ct3 == list.Count)
                {
                    Console.WriteLine("You won:)");
                }
            }
            if (tries2 < 0)
            {
                Console.WriteLine("You lost:(");
            }
            if (input != "stop")
            {
                Game();
            }
        }
    }
}
