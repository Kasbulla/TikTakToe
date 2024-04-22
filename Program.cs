using System;

namespace TikTakToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe();

            ticTacToe.PlayGame();
            Console.Read();
        }
    }
}