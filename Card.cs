using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades,
    }
    public class Card
    {
        public string DisplayName { get; set; }
        public Suit Suit { get; set; }
        public int Value { get; set; }
    }
    public static class Extensions //modifies the queue function to work as an implimentation of a 'deck' 
    {
        public static void Enqueue(this Queue<Card> cards, Queue<Card> newCards)
        {
            foreach(var card in newCards)
            {
                cards.Enqueue(card);
            }
        }
    }
}
