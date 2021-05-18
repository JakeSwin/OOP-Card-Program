using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// The Main parent class for Players.
    /// Contains attributes to store relevent player information,
    /// Along with methods for interfacing with these values
    /// </summary>
    abstract class Player
    {
        /// <summary> Hand property represents players current hand. </summary>
        public Hand Hand { get; private set; }

        /// <summary> Score property represents how many turns player has currently won. </summary>
        public int Score { get; private set; }

        /// <summary> ID property represents players identification number. </summary>
        public int ID { get; private set; }

        /// <summary> TurnTotal property represents total value of cards currently in play. </summary>
        public int TurnTotal { get; private set; }

        /// <summary>
        /// Constructor for Player.
        /// Instantiates all attributes to initial values
        /// </summary>
        /// <param name="ID"> Players ID </param>
        public Player(int ID)
        {
            this.ID = ID;
            this.Score = 0;
            this.TurnTotal = 0;
            this.Hand = new Hand();
        }

        /// <summary>
        /// Abstract Method for Play.
        /// Every player must have some method for playing Cards.
        /// Must return one card each time method is called
        /// </summary>
        /// <returns> One Card Object </returns>
        public abstract Card Play();

        /// <summary> Increases score by value. </summary>
        /// <param name="value"> Amount to increase score by. </param>
        public void IncrementScore(int value) => 
            Score += value;

        /// <summary> Increases turn total by input card value </summary>
        /// <param name="card"> Card to increase turn total by value </param>
        public void AddTurnTotal(Card card) =>
            TurnTotal += card.Value;

        /// <summary> Resets turn total back to 0 </summary>
        public void ResetTurnTotal() =>
            TurnTotal = 0;
    }
}
