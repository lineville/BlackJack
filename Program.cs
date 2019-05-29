using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to BlackJack!\n");
            Console.WriteLine("Shuffling the Deck");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.Write(". ");
            }
            Console.WriteLine();
            Game blackjack = new Game();
            blackjack.Play();
        }
    }

}
