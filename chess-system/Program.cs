using System;
using board;
using chess;
using chess_system.board;

namespace chess_system
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition position = new ChessPosition('c', 7);

            Console.WriteLine(position);

            Console.WriteLine(position.toPosition());

            Console.ReadLine();
        }
    }
}
