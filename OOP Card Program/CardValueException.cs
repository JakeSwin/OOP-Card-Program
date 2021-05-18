using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Card_Program
{
    /// <summary>
    /// Exception for if Card has an invalid value
    /// </summary>
    class CardValueException : Exception
    {
        /// <summary>
        /// Exception Constructor.
        /// Passess message to base Exception Method parameter
        /// </summary>
        /// <param name="message"> Exception message to be outputed </param>
        public CardValueException(string message) : base(message)
        {
            // Do nothing...
        }
    }
}
