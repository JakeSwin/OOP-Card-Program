using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// Exception for if Card has invalid suit name
    /// </summary>
    class CardSuitException : Exception
    {
        /// <summary>
        /// Exception Constructor.
        /// Passess message to base Exception Method parameter
        /// </summary>
        /// <param name="message"> Exception message to be outputed </param>
        public CardSuitException(string message) : base(message)
        {
            // Do nothing...
        }
    }
}
