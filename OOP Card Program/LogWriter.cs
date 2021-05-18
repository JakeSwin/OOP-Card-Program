using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_Card_Program
{
    /// <summary> Handles outputting to log </summary>
    class LogWriter
    {
        /// <summary> Outputs game information to log file </summary>
        /// <param name="playerOneScore"> Player one's score </param>
        /// <param name="playerTwoScore"> Player two's score </param>
        /// <param name="matchHistory"> Complete match history </param>
        public static void OutputGameToLog(int playerOneScore, int playerTwoScore, List<string> matchHistory)
        {
            // Store lines to be outputted to log file
            var fileLines = new List<string>();
            // Store if Player One or Player Two won
            string winningPlayer = playerOneScore > playerTwoScore ? "Player One" : "Player Two";

            fileLines.Add($"Player One Score: {playerOneScore}");
            fileLines.Add($"Player Two Score: {playerTwoScore}");
            fileLines.Add("Match History: ");
            // Add full match history to lines
            matchHistory.ForEach(x => fileLines.Add(x));
            fileLines.Add($"{winningPlayer} won! ");
            fileLines.Add(" ");

            // Append all lines to GameLog.txt 
            File.AppendAllLines("GameLog.txt", fileLines);
        }
    }
}
