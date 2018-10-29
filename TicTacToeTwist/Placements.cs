/********************************************
 * Assignment 4: Tic Tac Toe with a Twist
 * Author: Ethan Darling
 * Updater.cs
 *******************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Class used to check each index on the board and whether the 
/// player has placed an "X" or an "O" on the board.
/// </summary>
namespace TicTacToeTwist {
    class Placements {
        private static int placement = 0;
        private int placementCounter = 0;

        public void PlacementCheck(Board board, int p, int r, int c) {
            if (placement == p && board.GetBoard(r, c) != "X" && board.GetBoard(r, c) != "O") {
                if (board.GetTurn() == 1) {
                    board.SetBoard(r, c, "X");
                    board.SetTurn(2);
                }
                else if (board.GetTurn() == 2) {
                    board.SetBoard(r, c, "O");
                    board.SetTurn(1);
                }
                Console.Clear();
                board.PrintTurns();
                board.PrintBoard();
                board.CheckWin();

                placementCounter++;
                endlessTTT(board);
               
                // Checks for a game over.
                if (board.GetGameOver()) {
                    board.PlayWin();
                }
            }
        }

        /// <summary>
        /// This method checks for how many placements have been made.
        /// If the placementCounter reaches 7 then the first move made gets erased,
        /// then the next, and so on till someone wins, there can be no draw game.
        /// If the placement Counter reaches 15 then it is reset back down to 6.
        /// </summary>
        /// <param name="board"></param>
        private void endlessTTT(Board board) {
            if (placementCounter == 7) {
                board.SetBoard(0, 0, "1");
            }
            if (placementCounter == 8) {
                board.SetBoard(0, 1, "2");
            }
            if (placementCounter == 9) {
                board.SetBoard(0, 2, "3");
            }
            if (placementCounter == 10) {
                board.SetBoard(1, 0, "4");
            }
            if (placementCounter == 11) {
                board.SetBoard(1, 1, "5");
            }
            if (placementCounter == 12) {
                board.SetBoard(1, 2, "6");
            }
            if (placementCounter == 13) {
                board.SetBoard(2, 0, "7");
            }
            if (placementCounter == 14) {
                board.SetBoard(2, 1, "8");
            }
            if (placementCounter == 15) {
                board.SetBoard(2, 2, "9");
                placementCounter = 6;
            }
        }

        public void Update(Board board) {
            Console.CursorLeft = 10;

            while (!int.TryParse(Console.ReadLine(), out placement)
                || placement <= 0 || placement > 9) {
                board.PlayWrong();
                Console.WriteLine("Please enter a Placement between 1 and 9.");
            }

            PlacementCheck(board, 1, 0, 0);
            PlacementCheck(board, 2, 0, 1);
            PlacementCheck(board, 3, 0, 2);
            PlacementCheck(board, 4, 1, 0);
            PlacementCheck(board, 5, 1, 1);
            PlacementCheck(board, 6, 1, 2);
            PlacementCheck(board, 7, 2, 0);
            PlacementCheck(board, 8, 2, 1);
            PlacementCheck(board, 9, 2, 2);
        }
    }
}
