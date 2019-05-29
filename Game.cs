using System;
public class Game
{
    public int bet;
    public int handNumber;
    private Deck deck;
    Player human;
    Player dealer;
    bool playing;
    bool dealerTurn;

    public Game()
    {
        bet = 10;
        handNumber = 0;
        deck = new Deck();
        human = new Player();
        dealer = new Player();
        playing = true;
        dealerTurn = false;
    }
    public void Hit(Player p)
    {
        Card card = deck.Deal();

        if (p.Score + card.Value > 21)
        {
            if (card.Value == 11)
            {
                card.Value = card.OptionalValue;
            }
            else
            {
                p.Busted = true;
            }
        }
        p.Score += card.Value;
        p.Hand.Add(card);
    }

    public void PrintGame()
    {
        Console.WriteLine("|--------------------------------------|");
        Console.WriteLine("|                                      |");
        Console.WriteLine("|                                      |");


        if (!dealerTurn)
        {
            Console.WriteLine("         Dealer: " + dealer.Hand[0].Name);
        }
        else
        {
            Card[] dealerCards = dealer.Hand.ToArray();
            Console.Write("         Dealer: ");
            dealer.PrintHand();
        }
        Card[] cards = human.Hand.ToArray();
        Console.Write("\n\n         You: ");
        human.PrintHand();
        Console.WriteLine("|                                      |");
        Console.WriteLine("|                                      |");
        Console.WriteLine("|--------------------------------------|\n");
    }

    public void NextHand()
    {
        human.Hand.Clear();
        dealer.Hand.Clear();
        human.Score = 0;
        dealer.Score = 0;
        human.Busted = false;
        dealer.Busted = false;
        dealerTurn = false;
        bet = 10;
        handNumber++;

        deck = new Deck();
        // * Deal two cards to player
        Card card1 = deck.Deal();
        Card card2 = deck.Deal();
        human.Hand.Add(card1);
        human.Hand.Add(card2);
        human.Score = card1.Value + card2.Value;

        Card upcard = deck.Deal();
        Card downcard = deck.Deal();
        dealer.Hand.Add(upcard);
        dealer.Hand.Add(downcard);
        dealer.Score = upcard.Value + downcard.Value;

        Console.WriteLine("Balance: " + human.Winnings);
    }

    public void Play()
    {
        NextHand();

        while (playing)
        {
            PrintGame();
            Console.WriteLine("What would you like to do?\nenter => hit | s => stand | d => double down | q => quit");
            String action = Console.ReadLine();

            switch (action)
            {
                case "":
                    Hit(human);
                    break;
                case "s":
                    dealerTurn = true;
                    break;
                case "d":
                    bet = bet * 2;
                    Hit(human);
                    dealerTurn = true;
                    break;
                case "q":
                    Console.WriteLine("Thanks for playing.");
                    playing = false;
                    break;
                default:
                    Console.WriteLine("Not an option...\n Please say hit, stand, split or quit");
                    break;
            }

            if (human.Busted)
            {
                human.PrintHand();
                Console.WriteLine("You busted ...");
                human.Winnings -= bet;
                dealer.Winnings += bet;
                Console.WriteLine("Press enter to play another hand!");
                String anotherHand = Console.ReadLine();
                NextHand();
                Console.Clear();
                Console.WriteLine("|--------------------------------------|\n\n" + " Hand # " + handNumber + "                  Balance: " + human.Winnings);
            }

            if (dealerTurn)
            {

                while (!dealer.Busted && dealer.Score < 17)
                {
                    Hit(dealer);
                    PrintGame();
                }

                Console.WriteLine("Dealer Score: " + dealer.Score);
                if (dealer.Busted || dealer.Score < human.Score)
                {
                    Console.WriteLine("You Win! ...");
                    human.Winnings += bet;
                    dealer.Winnings -= bet;

                }
                if (!dealer.Busted && dealer.Score > human.Score)
                {
                    Console.WriteLine("You lose ...");
                    human.Winnings -= bet;
                    dealer.Winnings += bet;
                }
                if (dealer.Score == human.Score)
                {
                    Console.WriteLine("Push ...");
                }

                Console.WriteLine("Press enter to play another hand!");
                String anotherHand = Console.ReadLine();
                NextHand();
                Console.Clear();
                Console.WriteLine("|--------------------------------------|\n\n" + " Hand # " + handNumber + "                  Balance: " + human.Winnings);

            }

        }

    }

}