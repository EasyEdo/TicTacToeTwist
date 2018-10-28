/********************************************
 * Assignment 4: Tic Tac Toe with a Twist
 * Author: Ethan Darling
 * Board.cs
 *******************************************/ 

using System;
using System.Media;

/// <summary>
/// Class representing a Tic Tac Toe board, it's players,
/// and all of the functionality needed to check for a win
/// and print the neccessary board properties.
/// </summary>
namespace TicTacToeTwist {
    class Board {
        private String player1 = "Player 1";
        private String player2 = "Player 2";
        private Boolean gameOver = false;
        private Boolean p1Win = false;
        private Boolean p2Win = false;
        private int turn = 1;
        private SoundPlayer ding = new SoundPlayer(@"C:\Users\Ethan\Documents\Google Drive\Ein\2410-Csharp\TicTacToeTwist\TicTacToeTwist\res\ding.wav");
        private SoundPlayer wrong = new SoundPlayer(@"C:\Users\Ethan\Documents\Google Drive\Ein\2410-Csharp\TicTacToeTwist\TicTacToeTwist\res\wrong.wav");
        private SoundPlayer win = new SoundPlayer(@"C:\Users\Ethan\Documents\Google Drive\Ein\2410-Csharp\TicTacToeTwist\TicTacToeTwist\res\win.wav");

        /// <summary>
        /// Initial Tic Tac Toe board.
        /// </summary>
        private String[,] board = {
            {"1", "2", "3" },
            {"4", "5", "6" },
            {"7", "8", "9" }
        };

        /// <summary>
        /// Prints the appropriate winner if gameOver is true.
        /// </summary>
        public void PrintWinner() {
            PlayWin();
            if (gameOver == true) {
                if (p1Win == true) {
                    Console.Clear();
                    Console.CursorTop = 3;
                    Console.CursorLeft = 10;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(player1 + " Wins!");
                }
                else if (p2Win == true) {
                    Console.Clear();
                    Console.CursorTop = 3;
                    Console.CursorLeft = 10;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(player2 + " Wins!");
                }
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Prints the title and asks for the names of each player.
        /// </summary>
        public void PrintNames() {
            Console.CursorTop = 3;
            Console.CursorLeft = 10;
            Console.WriteLine("T I C  T A C  T O E  T W I S T");
            Console.CursorLeft = 10;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please enter Player One's name:");
            SetP1Name(Console.ReadLine());
            Console.CursorLeft = 10;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please enter Player Two's name:");
            SetP2Name(Console.ReadLine());
            Console.Clear();
        }

        /// <summary>
        /// Prints the current player's turn and some simple instructions.
        /// </summary>
        public void PrintTurns() {
            Console.CursorTop = 3;
            Console.CursorLeft = 5;
            if (GetTurn() == 1) {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
                Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorLeft = 5;
            Console.WriteLine(GetPlayer() + "'s Turn");
            Console.CursorLeft = 5;
            Console.WriteLine("Enter your placement corresponding to the numbers below (1-9): \n");
        }

        /// <summary>
        /// Prints the board in the following format:
        /// 1 | 2 | 3
        /// ---------
        /// 4 | 5 | 6
        /// ---------
        /// 7 | 8 | 9
        /// </summary>
        public void PrintBoard() {
            for (int i = 0; i < board.GetLength(0); i++) {
                Console.CursorLeft = 10;
                for (int j = 0; j < board.GetLength(1); j++) {
                    if (j < 2) {
                        if (board[i, j] == "X") {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (board[i, j] == "O") {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(board[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | ");
                    }
                    else {
                        if (board[i, j] == "X") {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (board[i, j] == "O") {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(board[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("   ");
                    }
                }
                Console.CursorLeft = 10;
                Console.WriteLine();
                Console.CursorLeft = 10;
                if (i < 2) {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------");
                }
                else {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ");
                }
            }
        }

        /// <summary>
        /// Checks each row, column, and diagonal whether they are equal.
        /// If they are equal true is returned.
        /// </summary>
        /// <returns></returns>
        public Boolean CheckWin() {
            // First Row
            if (board[0,0] == board[0,1] && board[0,1] == board[0,2]) {
                gameOver = true;
                WhoWon(0, 0);
                return true;
            }
            // Second Row
            if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2]) {
                gameOver = true;
                WhoWon(1, 0);
                return true;
            }
            // Third Row
            if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2]) {
                gameOver = true;
                WhoWon(2, 0);
                return true;
            }
            // First Column
            if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0]) {
                gameOver = true;
                WhoWon(0, 0);
                return true;
            }
            // Second Column
            if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1]) {
                gameOver = true;
                WhoWon(0, 1);
                return true;
            }
            // Third Column
            if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2]) {
                gameOver = true;
                WhoWon(0, 2);
                return true;
            }
            // Top Left to Bottom Right
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) {
                gameOver = true;
                WhoWon(0, 0);
                return true;
            }
            // Top Right to Bottom Left
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) {
                gameOver = true;
                WhoWon(0, 2);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Decides which player won based off of a particular board index.
        /// The winner is then printed out.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        private void WhoWon(int r, int c) {
            gameOver = true;
            if (board[r, c] == "X") {
                p1Win = true;
            }
            else if (board[r, c] == "O") {
                p2Win = true;
            }
            PrintWinner();
        }

        /// <summary>
        /// Plays the "ding" sound. 
        /// Used when the program has been started.
        /// </summary>
        public void PlayDing() {
            ding.Play();
        }

        /// <summary>
        /// Plays the "wrong" sound. 
        /// Used when the player inputs an incorrent placement.
        /// </summary>
        public void PlayWrong() {
            wrong.Play();
        }

        /// <summary>
        /// Plays the "win" sound.
        /// Used when a player winds.
        /// </summary>
        public void PlayWin() {
            win.Play();
        }

        /// <summary>
        /// Sets a particular index on the board with a marker.
        /// The marker should be either an "X" or and "O".
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="marker"></param>
        public void SetBoard(int r, int c, String marker) {
            this.board[r, c] = marker;
        }

        /// <summary>
        /// Returns a particular index on the board.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public String GetBoard(int r, int c) {
            return board[r, c];
        }

        /// <summary>
        /// Used to set the turn after a player has made a move.
        /// </summary>
        /// <param name="t"></param>
        public void SetTurn(int t) {
            if (t == 1)
                this.turn = 1;
            if (t == 2)
                this.turn = 2;
        }

        /// <summary>
        /// Returns the current turn, either a 1 or a 2 based off of setTurn.
        /// </summary>
        /// <returns></returns>
        public int GetTurn() {
            return turn;
        }

        /// <summary>
        /// Gets the players name bases off of the current turn.
        /// </summary>
        /// <returns></returns>
        public String GetPlayer() {
            if (this.turn == 1)
                return player1;
            return player2;
        }

        /// <summary>
        /// Gets the game over state.
        /// </summary>
        /// <returns></returns>
        public Boolean GetGameOver() {
            return gameOver;
        }

        /// <summary>
        /// Used to set player1 with a user given name.
        /// </summary>
        /// <param name="name"></param>
        public void SetP1Name(String name) {
            this.player1 = name;
        }

        /// <summary>
        /// Used to set player2 with a user given name.
        /// </summary>
        /// <param name="name"></param>
        public void SetP2Name(String name) {
            this.player2 = name;
        }
    }
}
