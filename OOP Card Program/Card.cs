using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// The main Card class for all Card instantiations.
    /// Stores necessary information for card.
    /// Contains all methods for comparisons between cards.
    /// </summary>
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        /// <summary> The Suit property represents the card's suit </summary>
        public string Suit { get; private set; }
        /// <summary> The Value property represents the card's numberical value </summary>
        public int Value { get; private set; }

        /// <summary> Constructor for creating card object. </summary>
        /// <remarks>
        /// Valid suits are Clubs, Diamonds, Hearts and Spades
        /// Valid values are between 2 and 14
        /// </remarks>
        /// <param name="suit"> Used to set card suit </param>
        /// <param name="value"> Used to set card value </param>
        public Card(string suit, int value)
        {
            string[] validSuits = { "Clubs", "Diamonds", "Hearts", "Spades" };

            // If input suit is not contained in valid suit then throw an error
            if (!Array.Exists(validSuits, element => element == suit)) throw new CardSuitException("Card suit is not real");
            // If input value is less than 2 or greater than 14 throw an error 
            if (value < 2 || value > 14) throw new CardValueException("Card value out of bounds");

            // Otherwise...
            this.Suit = suit;
            this.Value = value;
        }

        /// <summary> Compares if two cards values are equal </summary>
        /// <remarks> Implementation of method from IEquatable </remarks>
        /// <param name="othercard"> Card to compare to </param>
        /// <returns> True if Cards are equal, otherwise false </returns>
        public bool Equals(Card othercard)
        {
            if (this.Value == othercard.Value) return true;
            return false;
        }

        /// <summary> Compares this card value to another card value </summary>
        /// <param name="othercard"> Card to compare to </param>
        /// <returns>
        /// -1 if less than other card.
        /// 1 if greater than other card.
        /// 0 if equal to other card.
        /// </returns>
        public int CompareTo(Card othercard)
        {
            if (this < othercard) return -1;
            if (this > othercard) return 1;
            return 0;
        }

        /// <summary> Compares if left card value is less than right card value </summary>
        /// <param name="left"> Left side card </param>
        /// <param name="right"> Right side card </param>
        /// <returns>True if less than, otherwise false</returns>
        public static bool operator < (Card left, Card right) =>
            left.Value < right.Value;

        /// <summary> Compares if left card value is greater than right card value </summary>
        /// <param name="left"> Left side card </param>
        /// <param name="right"> Right side card </param>
        /// <returns>True if greater than, otherwise false</returns>
        public static bool operator > (Card left, Card right) =>
            left.Value > right.Value;

        /// <summary> Adds left card value and right card value </summary>
        /// <param name="left"> Left side card </param>
        /// <param name="right"> Right side card </param>
        /// <returns> Integer product of left card value + right card value </returns>
        public static int operator + (Card left, Card right) =>
            left.Value + right.Value;

        /// <summary> Subtracts left card value and right card value </summary>
        /// <param name="left"> Left side card </param>
        /// <param name="right"> Right side card </param>
        /// <returns> Integer product of left card value - right card value </returns>
        public static int operator - (Card left, Card right) =>
            left.Value - right.Value;

        /// <summary> Converts Card value and suit into human readable format </summary>
        /// <returns> string of card's full name </returns>
        public override string ToString()
        {
            // String name is equal to... 
            string name = Value switch
            {
                11 => "Jack",
                12 => "Queen",
                13 => "King",
                14 => "Ace",
                _ => Value.ToString()
            };
            return name + " of " + Suit;
        }
    }
}
