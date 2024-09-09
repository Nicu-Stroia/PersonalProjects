using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

//hello
namespace Exercitii2
{
    internal class Hangman
    {
        public int nb;
        public string guessWd;
        public string tryGuess;

        public Hangman()
        {
            nb = 0;
        }

        public void BrowseFile()
        {
            string filePath = @"C:\Users\nicus\OneDrive\Desktop\Hangman Game.txt";
            Random rd = new Random();
            string[] allWd = File.ReadAllLines(filePath);
            nb = rd.Next(1, 151);
            for (int i = 0; i < allWd.Length;i++)
            {
                if (i == nb)
                {
                    guessWd = allWd[i];
                    break;
                }
            }
        }

        public void Game()
        {
            int ct3 = 1;
            int tries = 6;
            int ct4 = 1;
            bool save = false;
            char[] saveWd = new char[guessWd.Length];
            char[] saveWd2 = new char[guessWd.Length];
            Console.Write("The word has: ");
            Console.Write(guessWd.Length);
            Console.WriteLine(" letters");
            Console.Write("First letter is: ");
            Console.WriteLine(guessWd[0]);
            Console.Write("Last letter is: ");
            Console.WriteLine(guessWd[guessWd.Length-1]);
            while (tries > 0)
            {
                int ct5 = 1;
                Console.WriteLine();
                Console.Write("Enter the letter: ");
                tryGuess = Console.ReadLine();
                for (int j = 1; j < guessWd.Length-1; j++)
                {
                    if (tryGuess[0] == guessWd[j])
                    {
                        Console.Write("Letter ");
                        Console.Write(tryGuess[0]);
                        Console.Write(" is correct and is in postion: ");
                        Console.WriteLine(j);
                        saveWd[j] = tryGuess[0];
                        ct4++;
                    }
                    else
                    {
                        ct5++;
                    }
                }
                if (ct5 >= guessWd.Length-1)
                {
                    Console.Write("Letter ");
                    Console.Write(tryGuess[0]);
                    Console.WriteLine(" is incorrect, repeat!");
                }
                Console.Write(guessWd[0]);
                for (int i = 1; i < guessWd.Length - 1; i++)
                {
                    if (saveWd[i] == guessWd[i])
                    {
                        Console.Write(saveWd[i]);
                    }
                    else
                    {
                        saveWd[i] = '*';
                        Console.Write(saveWd[i]);
                    }
                }
                Console.WriteLine(guessWd[guessWd.Length - 1]);
                for (int t = 1; t < guessWd.Length - 1; t++)
                {
                    if (tryGuess[0] != guessWd[t])
                    {
                        ct3++;
                    }
                    if (ct3 >= guessWd.Length - 1)
                    {
                        tries--;
                    }
                }
                ct3 = 1;
                if (ct4 == guessWd.Length-1)
                {
                    save = true;
                }
                else
                {
                    save = false;
                }
                if (save == true)
                {
                    Console.Write("You won:). The word is: ");
                    Console.WriteLine(guessWd);
                    break;
                }
                else
                {
                    Console.Write("You have ");
                    Console.Write(tries);
                    Console.WriteLine(" more chances!");
                }
            }
            if (tries == 0)
            {
                Console.Write("You lost:(. The word was: ");
                Console.WriteLine(guessWd);
            }
        }
    }
}
