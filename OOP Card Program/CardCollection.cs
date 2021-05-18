using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// The Main Parent class for Card Collections
    /// Contains functionality for cards to be Stored, Dealt and Outputted
    /// </summary>
    class CardCollection
    {
        /// <summary> The Cards property represents the list of all contained Cards. </summary>
        protected List<Card> Cards { get; set; }

        /// <summary>
        /// Constructor for Card Collection.
        /// Instantiates Cards property as a list of Cards.
        /// </summary>
        public CardCollection() =>
            Cards = new List<Card>();

        /// <summary> Counts how many cards are in the collection. </summary>
        /// <returns> Integer of how many Cards are contained in Cards property. </returns>
        public int NumberOfCards() =>
            Cards.Count();

        /// <summary> Outputs the name of every card in the collection. </summary>
        public virtual void OutputCards()
        {
            int i = 0;
            // For each card in the collection
            // Output its position in the collection followed by its name
            Cards.ForEach(c => Console.WriteLine(++i + ") " + c));
        }
        
        /// <summary> Deal an ammount of cards from the collection. </summary>
        /// <remarks>
        /// If amount is greater than the number of cards currently in collection, throw an error.
        /// If amount is less than 1, throw an error.
        /// </remarks>
        /// <param name="amount"> The number of cards that should be dealt. </param>
        /// <returns> List of Cards of size "amount". </returns>
        public List<Card> Deal(int amount)
        {
            // If input amount is greater than the number of cards currently in the collection
            // Throw an error
            if (amount > Cards.Count) throw new CardValueException("Value too high");
            // if input amount is less than 1
            // Throw an error
            if (amount < 1) throw new CardValueException("Value too low");

            // Otherwise...
            List<Card> cardRange = Cards.GetRange(0, amount);
            Cards.RemoveRange(0, amount);

            return cardRange;
        }

        /// <summary> Deal one card from the collection. </summary>
        /// <returns> One Card object. </returns>
        public Card Deal()
        {
            // Get card from collection
            var card = Cards[0];
            Cards.RemoveAt(0);

            // Then return it
            return card;
        }
    }
}
