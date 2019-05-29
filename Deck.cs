using System;
using System.Collections;
using System.Collections.Generic;

public class Deck
{
    const int DECK_SIZE = 52;
    public ArrayList deck = new ArrayList();
    private Random random = new Random();


    // * Constructs a full shuffled deck
    public Deck()
    {
        String[] SUITES = new String[4] { "Spades", "Hearts", "Clubs", "Diamonds" };
        String[] FACECARDS = new String[] { "Jack", "Queen", "King" };

        // * Add all the NON-face Cards to the deck
        for (int i = 2; i <= 10; i++)
        {
            for (int j = 0; j < SUITES.Length; j++)
            {
                String suite = SUITES[j];
                deck.Add(new Card("" + i, i, suite));
            }
        }

        //  * Add the Jacks Queens and Kings
        for (int i = 0; i < FACECARDS.Length; i++)
        {
            for (int j = 0; j < SUITES.Length; j++)
            {
                String suite = SUITES[j];
                deck.Add(new Card(FACECARDS[i], 10, suite));
            }
        }

        // * Add the aces with the optional of 11
        for (int j = 0; j < SUITES.Length; j++)
        {
            String suite = SUITES[j];
            Card ace = new Card("Ace", 11, suite);
            ace.OptionalValue = 1;
            deck.Add(ace);
        }
    }

    public Card Deal()
    {
        int index = random.Next(deck.Count);
        Card c = (Card)deck[index];
        deck.Remove(c);
        return c;
    }

    public void Print()
    {
        foreach (Card c in deck)
        {
            Console.Write(c.Name + " ");
        }
    }


}