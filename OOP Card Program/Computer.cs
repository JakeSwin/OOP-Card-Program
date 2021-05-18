using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// The Main Computer Class.
    /// Contains methods that computer players need to play the game,
    /// such as playing the highest value card from hand
    /// </summary>
    class Computer : Player
    {
        /// <summary> Runs the Player constructor to initialise player attributes. </summary>
        /// <param name="ID"> Players ID. </param>
        public Computer(int ID) : base(ID) { }

        /// <summary> Computer chooses highest value card from hand then plays it. </summary>
        /// <returns> One Card object. </returns>
        public override Card Play()
        {
            // Sort hand in terms of value
            Hand.SortByValue();
            // Play the highest value card
            return Hand.PlayCard(Hand.NumberOfCards() - 1);
        }
    }
}
