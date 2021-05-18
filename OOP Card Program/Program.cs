using System;
using System.Collections.Generic;
using System.IO;

namespace OOP_Card_Program
{
    /// <summary> The Program main class </summary>
    class Program
    {
        /// <summary> Plays game while user wants to </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            do
            {
                SetupAndPlayGame();
            } while (ContinueGame());
        }

        /// <summary> Creates a new game </summary>
        static void SetupAndPlayGame()
        {
            var newDeck = new Deck();
            newDeck.Shuffle();

            (Player playerOne, Player playerTwo) = SetupPlayers(newDeck);

            Console.Clear();
            Game lincoln = new Game(playerOne, playerTwo, newDeck);
            lincoln.PlayFullGame();
        }

        /// <summary> Correctly sets up player objects </summary>
        /// <param name="deck"> Deck for setting up players </param>
        /// <returns> Two complete player objects </returns>
        static (Player playerOne, Player playerTwo) SetupPlayers(Deck deck)
        {
            var playerOne = new Human(1);
            var playerTwo = new Computer(2);

            playerOne.Hand.RecieveCards(deck.Deal(10));
            playerTwo.Hand.RecieveCards(deck.Deal(10));

            return (playerOne, playerTwo);
        }

        /// <summary> Checks if user wants to continue playing </summary>
        /// <returns> 
        /// true if user wants to play, 
        /// false if user doesn't want to play.
        /// </returns>
        static bool ContinueGame()
        {
            while (true)
            {
                Console.Write("Do you want to continue playing (y/n): ");
                string choice = Console.ReadLine();
                if (choice == "y") return true;
                if (choice == "n") return false;
            }
        }
    }
}
