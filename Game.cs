using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Game
    {

        private Player Player1; 
        private Player Player2;
        private int TurnCount; 

        public Game(string player1name, string player2name)
        {
            Player1 = new Player(player1name);
            Player2 = new Player(player2name);

            var cards = Deck_Builder.CreateCards(); // creates and shuffles cards

            var deck = Player1.Deal(cards); //returns player2 deck, player 1 keeps thier deck
            Player2.Deck = deck;
        }
        public bool IsEndOfGame()
        {
            if (!Player1.Deck.Any())
            {
                Console.WriteLine(Player1.Name + " is out of cards! " + Player2.Name + " Wins!");
                return true;
            }
            else if (!Player2.Deck.Any())
            {
                Console.WriteLine(Player2.Name + " is out of cards! " + Player1.Name + " Wins!");
                return true;
            }
            else if (TurnCount > 500)
            {
                Console.WriteLine("500 turns met! It's a truce!");
                return true;
            }
            return false;
        }
        public void PlayTurn()
        {
            Queue<Card> pool = new Queue<Card>();

            var player1card = Player1.Deck.Dequeue();
            var player2card = Player2.Deck.Dequeue();

            pool.Enqueue(player1card);
            pool.Enqueue(player2card);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "---WAR!---"));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Player1.Name}'s Cards in hand: {Player1.Deck.Count} \n" +
                $"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Player2.Name}'s Cards in hand: {Player2.Deck.Count} \n" +
                $"");
            Console.ResetColor();



            Console.WriteLine(Player1.Name + " plays "
                + player1card.DisplayName + " ||| "
                + Player2.Name + " plays " + player2card.DisplayName);
        
            //WAR!
            while (player1card.Value == player2card.Value)
            {
                //if p1 or p2 doesnt have enough cards, game over
                if (Player1.Deck.Count < 4)
                {
                    Player1.Deck.Clear();
                    return;
                }
                if (Player2.Deck.Count < 4)
                {
                    Player2.Deck.Clear();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("---WAR!---");

                Console.ResetColor();
                Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{Player1.Name} card 1");
                Console.WriteLine($"{Player1.Name} card 2");
                Console.WriteLine($"{Player1.Name} card 3\n" +
                    $"");


                int i = 0;
                while (i < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n ---WAR!---  \n" +
                        "");
                    i = i + 1;
                }



                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Player2.Name} card 1");
                Console.WriteLine($"{Player2.Name} card 2");
                Console.WriteLine($"{Player2.Name} card 3");
                Console.ReadLine();
                Console.ResetColor();

                
                // 3 Cards each out of the deck during war
                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());

                //4th card for the final play in war 
                player1card = Player1.Deck.Dequeue();
                player2card = Player2.Deck.Dequeue();

                pool.Enqueue(player1card);
                pool.Enqueue(player2card);

                Console.WriteLine(Player1.Name + " plays "
                          + player1card.DisplayName + ", "
                          + Player2.Name + " plays "
                          + player2card.DisplayName);
            }
            //Add the won cards to the winning player's deck, 
            //and display which player won that hand. 
            if (player1card.Value < player2card.Value)
            {
                Player2.Deck.Enqueue(pool);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine(Player2.Name + " takes the hand!");
            }
            else
            {
                Player1.Deck.Enqueue(pool);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Player1.Name + " takes the hand!");
            }
            TurnCount++;
        }
    }
}
