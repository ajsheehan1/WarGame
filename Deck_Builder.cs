using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public static class Deck_Builder
    {
        public static Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();
            for (int i = 2; i <= 14; i++) // 2 - > Ace (14)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Enqueue(new Card()
                    {
                        Suit = suit,
                        Value = i,
                        DisplayName =  GetFaceCards(i, suit),
                        
                    });
                }
            }
            return Shuffle(cards);
        }

        private static Queue<Card> Shuffle(Queue<Card> cards)
        {
            //shuffle the existing cards using fisher yates modern 
            List<Card> transformedCards = cards.ToList();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                //picking a card that has not been shuffled 
                int k = r.Next(n + 1);

                //swap the selected item with last 'unselected' card
                Card temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            Queue<Card> shuffledCards = new Queue<Card>();
            foreach (var card in transformedCards)
            {
                shuffledCards.Enqueue(card);
            }
            return shuffledCards;
        }

        private static string GetFaceCards(int value, Suit suit)
        {
            string valueDisplay = " ";
            if (value >= 2 && value <= 10)
            {
                valueDisplay = $"{value} of ";
            }
            else if (value == 11) // assigning 11-14 as face cards
            {
                valueDisplay = "Jack of ";
            }
            else if (value == 12)
            {
                valueDisplay = "Queen of ";
            }
            else if (value == 13)
            {
                valueDisplay = "King of ";
            }
            else if (value == 14)
            {
                valueDisplay = "Ace of ";
            }
            return valueDisplay + Enum.GetName(typeof(Suit), suit);
        }
    }
}
