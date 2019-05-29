using System;
using System.Collections.Generic;

public class Player
{
    public int Winnings { get; set; } = 50;
    public int Score { get; set; } = 0;
    public bool Busted { get; set; } = false;

    public List<Card> Hand;

    public void PrintHand()
    {
        foreach (Card c in Hand)
        {
            Console.Write(c.Name + " ");
        }
        Console.WriteLine();
    }

    public Player()
    {
        Hand = new List<Card>();
    }

}