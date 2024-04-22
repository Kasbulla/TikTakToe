using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    internal class TicTacToe
    {
        private char[,] field = new char[3, 3];
        private char currentPlayer = 'X';

        public void PlayGame()
        {
            InitializeBoard();
            bool gameOver = false;
            while (!gameOver)
            {
                try
                {
                    PrintBoard();
                    bool isValid = false;
                    while(!isValid)
                    {
                        Console.WriteLine($"Player {currentPlayer} turn!");
                        Console.WriteLine("Enter a line number! (0-2) ");
                        int row = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter a column number (0-2)");
                        int column = int.Parse(Console.ReadLine());

                        if (IsMooveValid(row, column))
                        {
                            field[row, column] = currentPlayer;
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                            Console.ReadLine();
                            isValid = false;
                        }
                    }
                    if (GameOver())
                    {
                        gameOver = true;
                    }
                    else
                    {
                        SwitchPlayer();
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine($"Invalid input: {formatException.Message}");
                    Console.ReadLine();
                }
              

            }
            Console.Read();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = ' ';
                }
            }
        }

        private void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("  0   1   2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{field[i, j]}");
                    if (j < 2)
                        Console.Write(" | ");
                }
                Console.WriteLine();
                if (i < 2)
                    Console.WriteLine("-------------");
            }
            Console.WriteLine();
        }
        
        private bool IsMooveValid(int row, int column)
        {
            if (row >= 0 && row < 3 && column >= 0 && column < 3 && field[row, column] == ' ')
            {
                return true;
            }
            return false; 
        }

        private void SwitchPlayer()
        {
            string player = currentPlayer == 'X' ? "O" : "X";

            if(currentPlayer == 'X')
            {
                currentPlayer = 'O';
            }
            else
            {
                currentPlayer = 'X';
            }
        }

        private bool GameOver()
        {
            if (IsWinner())
            {
                Console.WriteLine($"The Winner is: {currentPlayer}");
                return true;
            }

            if(FieldFull())
            {
                Console.WriteLine("Field is Full. It's a tie!");
                return true;
            }
            return false;
        }

        private bool IsWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                //Horizontal
                if (field[i, 0] == currentPlayer && field[i, 1] == currentPlayer && field[i, 2] == currentPlayer)
                {
                    return true;
                }
                //Vertikal
                if (field[0, i] == currentPlayer && field[1, i] == currentPlayer && field[2, i] == currentPlayer)
                {
                    return true;
                }
            }

            if (field[0, 0] == currentPlayer && field[1, 1] == currentPlayer && field[2, 2] == currentPlayer)
            {
                return true;
            }
            if (field[0, 2] == currentPlayer && field[1, 1] == currentPlayer && field[2, 0] == currentPlayer)
            {
                return true;
            }

            return false;
        }

        private bool FieldFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == ' ')
                        return false;
                }
            }
            return true;
        }

    }
}
