﻿using System;
using board;

namespace chess_system
{
    class Program
    {
        static void Main(string[] args)
        {

            Board board = new Board(8,8);

            UI.printBoard(board);

            Console.ReadLine();
        }
    }
}
