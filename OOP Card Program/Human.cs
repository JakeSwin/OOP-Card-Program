using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// The Main Human Class.
    /// Contains methods that human players need to play the game,
    /// such as ability to pick a valid card from hand and play it.
    /// </summary>
    class Human : Player
    {
        /// <summary> Runs the Player constructor to initialise player attributes. </summary>
        /// <param name="ID"> Players ID. </param>
        public Human(int ID) : base(ID) { }

        /// <summary> Player chooses a valid card from hand then plays it. </summary>
        /// <returns> One Card object. </returns>
        public override Card Play()
        {
            // Get index of picked card
            int pickedCardIndex = PickCard();
            // Return the picked card from hand
            return Hand.PlayCard(pickedCardIndex - 1);
        }

        /// <summary> Outputs cards in hand, then user picks a valid card from hand. </summary>
        /// <returns> Index of picked card. </returns>
        private int PickCard()
        {
            Hand.OutputCards();

            Console.WriteLine("Please pick a card: ");
            // Get the index of a vaid card choice from user
            int pickedCard = ValidCardChoice();

            return pickedCard;
        }

        /// <summary> Gets a the index of a valid card choice from user. </summary>
        /// <remarks> 
        /// Will only return if input is an int, 
        /// that is less than the number of cards in hand,
        /// and greater than 0.
        /// </remarks>
        /// <returns> Index of picked card. </returns>
        private int ValidCardChoice()
        {
            int numberOfCards = Hand.NumberOfCards();
            while (true)
            {
                // The users choice of card is an int 
                bool validChoice = int.TryParse(Console.ReadLine(), out int choice);
                // that is less than or equal to the number of cards
                // and is greater than 0
                if (validChoice && choice <= numberOfCards && choice > 0) return choice;
                Console.WriteLine("Invalid card choice, please try again");
            }
        }
    }
}
