using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// The Main Hand Class.
    /// Contains functionality to Play out a selected card, to sort cards by value
    /// and to recieve cards into its own collection
    /// </summary>
    class Hand : CardCollection
    {
        /// <summary> Instatiates Card Collection </summary>
        public Hand() : base() { }

        /// <summary> Removes and outputs card from selected index </summary>
        /// <param name="index"> Position in collection of card to play </param>
        /// <returns> One Card object </returns>
        public Card PlayCard(int index)
        {
            // Get card at index from collection
            Card playedCard = Cards[index];
            // Remove it from collection
            Cards.RemoveAt(index);
            // Then Return the card
            return playedCard;
        }

        /// <summary> Sorts the cards by their value in Ascending order </summary>
        public void SortByValue()
        {
            // Sort cards in Ascending order
            Cards.Sort();
        }

        /// <summary> Take list of cards and add to card collection </summary>
        /// <param name="addedCards"> List of cards to be added to collection </param>
        public void RecieveCards(List<Card> addedCards)
        {
            // If the current amount of cards held + the amount of cards to be added is greater than 10
            if (Cards.Count + addedCards.Count > 10)
            {
                // Output error message
                Console.WriteLine("Error, recieving this amount would go over the max hand amount of 10");
                // Then exit the method
                return;
            }
            // Otherwise add cards to collection
            Cards.AddRange(addedCards);
        }
    }
}
