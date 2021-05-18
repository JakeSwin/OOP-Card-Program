using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// The Main Game Class.
    /// Contains necessary logic to play Lincoln game.
    /// </summary>
    class Game
    {
        /// <summary> Stores the player one object. </summary>
        public Player playerOne { get; private set; }

        /// <summary> Stores the player two object. </summary>
        public Player playerTwo { get; private set; }

        /// <summary> Stores the deck object for use in the game. </summary>
        public Deck gameDeck { get; private set; }

        /// <summary> Stores the current match history. </summary>
        public List<string> matchHistory { get; private set; }

        /// <summary> Stores the number of points the players get for winning a hand. </summary>
        public int winningAmount { get; private set; }

        /// <summary> Stores if player one will play first or not. </summary>
        public bool playerOnePlaysFirst { get; private set; }

        /// <summary> Constructor inintialises attributes. </summary>
        /// <param name="playerOne"> Player one object. </param>
        /// <param name="playerTwo"> Player two object. </param>
        /// <param name="gameDeck"> Deck object for game. </param>
        public Game(Player playerOne, Player playerTwo, Deck gameDeck)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            this.gameDeck = gameDeck;
            matchHistory = new List<string>();
            winningAmount = 1;
            playerOnePlaysFirst = true;
        }

        /// <summary> Public method to initialise playing game. </summary>
        public void PlayFullGame()
        {
            PlayFullHand();
            CheckLastRoundDraw();
            FinishGame();
        }

        /// <summary> Playing a full hand is playing 5 turns. </summary>
        private void PlayFullHand()
        {
            foreach (var i in Enumerable.Range(0, 5))
            {
                PlayFullTurn();
            }
        }

        /// <summary> Plays out a full turn of game between players. </summary>
        private void PlayFullTurn()
        {
            bool playerOneTurn = playerOnePlaysFirst;
            foreach (var i in Enumerable.Range(0, 4))
            {
                // Decide who plays this turn
                Player thisTurnPlayer = playerOneTurn ? playerOne : playerTwo;

                UserInterface();

                // Let the player take a turn and add result to match history
                matchHistory.Add(PlayerTakesTurn(thisTurnPlayer));

                // Switch who's turn it is next time
                playerOneTurn = !playerOneTurn;
            }
            // Decide which player has the greater turn total
            int result = playerOne.TurnTotal.CompareTo(playerTwo.TurnTotal);
            playerOne.ResetTurnTotal();
            playerTwo.ResetTurnTotal();
            // Change game state based on result
            DecideTurnResult(result);
        }

        /// <summary> Applies changes to Game from turn result. </summary>
        /// <remarks> 
        /// 1 = Player one win, 
        /// -1 = Player two win, 
        /// 0 = draw 
        /// </remarks>
        /// <param name="result"> Result of the turn. </param>
        private void DecideTurnResult(int result)
        {
            Player turnWinningPlayer = result switch
            {
                -1 => playerTwo,
                1 => playerOne,
                _ => null
            };
            // If round was a draw...
            if (turnWinningPlayer == null)
            {
                matchHistory.Add("Card Totals are the same");
                matchHistory.Add("Next round will win an additional point");
                winningAmount += 1;
                return;
            }
            // Otherwise...
            matchHistory.Add($"Player {turnWinningPlayer.ID} wins the hand");
            turnWinningPlayer.IncrementScore(winningAmount);
            // If player one won the turn then they play first next round 
            playerOnePlaysFirst = turnWinningPlayer.ID == 1 ? true : false;
            winningAmount = 1;
        }

        /// <summary> Makes a player take their turn </summary>
        /// <param name="player"> The player to take a turn </param>
        /// <returns> Message of player played card </returns>
        private string PlayerTakesTurn(Player player)
        {
            Card playedCard = player.Play();

            player.AddTurnTotal(playedCard);
            Console.Clear();

            return $"Player {player.ID} has played {playedCard}";
        }

        /// <summary> Performs required functions if last round in a game is a draw </summary>
        private void CheckLastRoundDraw()
        {
            if (!(playerOne.Score == playerTwo.Score)) return;

            var playerOneCard = gameDeck.Deal();
            var playerTwoCard = gameDeck.Deal();

            if (playerOneCard > playerTwoCard) playerOne.IncrementScore(1);
            else playerTwo.IncrementScore(1);
        }

        /// <summary> Finishes Game </summary>
        /// <remarks> Calls LogWriter to output game data to file </remarks>
        private void FinishGame()
        {
            string winningPlayer = playerOne.Score > playerTwo.Score ? "Player One" : "Player Two";

            Console.WriteLine("Game Over");
            Console.WriteLine($"{winningPlayer} wins");
            // Outputs match information to log file
            LogWriter.OutputGameToLog(playerOne.Score, playerTwo.Score, matchHistory);
        }

        /// <summary> The user interface for the game </summary>
        private void UserInterface()
        {
            Console.WriteLine("---- Lincoln Card Game ----");
            Console.WriteLine("Score: ");
            Console.WriteLine($"Player One: {playerOne.Score}");
            Console.WriteLine($"Player Two: {playerTwo.Score}");
            Console.WriteLine("Current hand: ");
            Console.WriteLine($"Player One: {playerOne.TurnTotal}");
            Console.WriteLine($"Player Two: {playerTwo.TurnTotal}");
            Console.WriteLine("Match History: ");
            matchHistory.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
