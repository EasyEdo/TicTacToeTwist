using System;
using System.Collections.Generic;
using System.Linq;
/********************************************
 * Assignment 4: Tic Tac Toe with a Twist
 * Author: Ethan Darling
 * Program.cs
 *******************************************/

using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Class used to initialize the game and use everything
/// inside of the Board and Updater classes.
/// </summary>
namespace TicTacToeTwist {
    class Program {

        static void Main(string[] args) {
            Board board = new Board();
            Placements placements = new Placements();

            // Sound played when starting program.
            board.PlayDing();

            Console.CursorLeft = 10;
            board.PrintNames();
            board.PrintTurns();
            board.PrintBoard();
            // Initializes the turn to 1.
            board.SetTurn(1);
            Console.WriteLine();

            // Checks for a game over situation.
            // Updates the placements and checks for a 
            // win if it is not a game over situation.
            while (board.GetGameOver() != true) {
                placements.Update(board);
            }
        }
    }
}
