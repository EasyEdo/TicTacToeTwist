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

                // The following lines check for a tie game.
                int placementCounter = 1;
                if (!board.GetGameOver()) {
                    for (int i = 0; i < 3; i++) { 
                        for (int j = 0; j < 3; j++) {
                            if (board.GetBoard(i,j) == "X" || board.GetBoard(i,j) == "O") {
                                placementCounter++;
                            }
                        }
                    }
                    if (placementCounter == 9) {
                        Console.CursorTop = 5;
                        Console.CursorLeft = 10;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tie Game");
                        Thread.Sleep(100);
                        Environment.Exit(0);
                    }
                }

                // Checks for a game over.
                if (board.GetGameOver()) {
                    board.PlayWin();
                }
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
