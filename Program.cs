using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck myDeck = new Deck();
            myDeck.reset();
            Player Marco = new Player("Marco");
            Marco.Draw(myDeck);


        }
    }
    class Card
    {
        string stringVal;
        string suit;
        int val;
        public Card(string stringVal, string suit, int val)
        {
            this.stringVal = stringVal;
            this.suit = suit;
            this.val = val;
        }
    }
    
    class Deck
    {
        public List<Card> cards {get; set;}
        public Deck()
        {
            Initialize();
        }
        public void Initialize()
        {
            cards = new List<Card>();
            string[] suits = new string[] {"Clubs", "Spades", "Hearts", "Diamonds"};
            for( int i = 1; i <= 13; i++) {
                foreach (string suit in suits)
                {
                    string stringVal = i.ToString();
                    if( i == 1 )
                    {
                        stringVal = "Ace";
                    }
                    if( i == 11 )
                    {
                        stringVal = "Jack";
                    }
                    if( i == 12 )
                    {
                        stringVal = "Queen";
                    }
                    if( i == 13 )
                    {
                        stringVal = "King";
                    }
                    cards.Add(new Card(stringVal, suit, i));
                }
            }
        }
        public Card Deal()
        {
            Card cardToDeal = cards[0];
            cards.RemoveAt(0);
            return cardToDeal;
        }
        public void reset()
        {
            Initialize();
        }
        public void shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int randIdx = rand.Next(0,cards.Count);
                Card temp = cards[randIdx];
                cards[randIdx] = cards[i];
                cards[i] = temp;
            }
        }
    }
    class Player
    {
        string name {get; set;}
        List<Card> Hand;
        public Player(string name)
        {
            this.name = name;
            this.Hand = new List<Card>();
        }
        public Card Draw(Deck myDeck)
        {
            Card newCard = myDeck.Deal();
            this.Hand.Add(newCard);
            return newCard;
        }
        public Card Discard(int index)
        {
            if ( index >= Hand.Count ) {
                return null;
            }
            Card discarded = Hand[index];
            Hand.RemoveAt(index);
            return discarded;
        }
    }
}
