﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    internal class Game
    {
        public int nb;
        public int nb1;
        public int tries;
        public Game()
        {
            nb = 0;
        }

        public void GenerateNumber()
        {
            int level;
            int maxnb = 101;
            for (int i = 1; i <= 5; i++)
            {
                level = i;
                Console.Write("level: ");
                Console.WriteLine(level);
                Random random = new Random();
                nb = random.Next(0, maxnb);
                maxnb = maxnb + 100;
                GuessNumber();
            }
        }

        public void GuessNumber()
        {
            Console.Write("Enter the number: ");
            nb1 = int.Parse(Console.ReadLine());
            if (nb >= nb1 && nb != nb1)
            {
                Console.Write("The number is biger than ");
                Console.WriteLine(nb1);
                tries++;
            }
            if (nb <= nb1 && nb != nb1)
            {
                Console.Write("The number is smaller than ");
                Console.WriteLine(nb1);
                tries++;
            }
            if (nb1 == nb)
            {
                tries++;
                Console.Write("The number is guessed and your score is: ");
                Console.WriteLine(tries);
                tries = 0;
            }
            else
            {
                GuessNumber();
            }

        }
    }
}
