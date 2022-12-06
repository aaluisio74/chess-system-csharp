using board;
using chess;
using System;
using System.Collections.Generic;

namespace chess_system
{
    class UI
    {
        public static void printMatch(ChessMatch chessMatch)
        {
            printBoard(chessMatch.board);
            Console.WriteLine();
            printCapturedPieces(chessMatch);
            Console.WriteLine("Turn: " + chessMatch.turn);
            Console.WriteLine("Waiting for play: " + chessMatch.currentPlayer);
            if (chessMatch.check)
            {
                Console.WriteLine("CHECK!");
            }
        }

        public static void printCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            printSet(chessMatch.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(chessMatch.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    printPiece(board.piece(i,j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] possiblePosition) //Bugfix
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor backgroundChanged = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    /*Se a posição estiver marcada como uma posição possível de movimento muda o
                      fundo para Cinza escuro, caso contrário, o fundo passa a ser a cor original.*/
                    if (possiblePosition[i,j] == true)
                    {
                        Console.BackgroundColor = backgroundChanged;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
