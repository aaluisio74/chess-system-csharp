using System;
using board;
using chess;

namespace chess_system
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.finished)
                {
                    Console.Clear();
                    UI.printBoard(chessMatch.board);

                    Console.WriteLine();
                    Console.Write("Source: ");
                    //Lê a posição e transforma em uma posição de matriz.
                    Position source = UI.readChessPosition().toPosition();

                    bool[,] positionMoves = chessMatch.board.piece(source).possibleMoves();

                    Console.Clear();
                    UI.printBoard(chessMatch.board, positionMoves);

                    Console.WriteLine();
                    Console.Write("Target: ");
                    Position target = UI.readChessPosition().toPosition();

                    chessMatch.makeMove(source, target);
                }

                UI.printBoard(chessMatch.board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
