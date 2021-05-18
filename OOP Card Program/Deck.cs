using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// The Main Deck class.
    /// Contains functionality to populate its own collection with correct amount of cards,
    /// and to shuffle cards in random order.
    /// </summary>
    class Deck : CardCollection
    {
        /// <summary> Populates Deck when object is instantiated </summary>
        /// <remarks> Calls CardCollection constructor to initialise Cards list </remarks>
        public Deck() : base()
        {
            // Populate Deck with correct amount of cards
            PopulateDeck();
        }

        /// <summary> Populates deck with correct amount of cards, using valid suits and values </summary>
        private void PopulateDeck()
        {
            string[] validSuits = { "Clubs", "Diamonds", "Hearts", "Spades" };

            foreach (string suit in validSuits)
            {
                for (int value = 2; value <= 14; value++)
                {
                    CreateCardAndAddToDeck(suit, value);
                }
            }
        }

        /// <summary> Creates a Card then adds it to the Deck </summary>
        /// <param name="suit"> Suit of card to be created </param>
        /// <param name="value"> Value of card to be created </param>
        private void CreateCardAndAddToDeck(string suit, int value)
        {
            try
            {
                var card = new Card(suit, value);
                Cards.Add(card);
            }
            catch (CardSuitException E)
            {
                // Output error message 
                Console.WriteLine(E.Message);
            }
            catch (CardValueException E)
            {
                // Output error message
                Console.WriteLine(E.Message);
            }
        }

        /// <summary> Shuffles Deck in random order </summary>
        public void Shuffle()
        {
            Random rng = new Random();

            int n = Cards.Count;

            // Go through each card in collection backwards and...
            while (n > 1)
            {
                n--;
                // Switch current card with card that has not yet been switched
                int k = rng.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
    }
}
