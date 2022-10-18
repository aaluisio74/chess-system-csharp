﻿using System;
using board;

namespace chess_system
{
    class UI
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.piece(i,j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}