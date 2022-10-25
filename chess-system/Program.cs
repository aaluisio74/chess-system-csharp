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
                    try
                    {
                        Console.Clear();
                        UI.printBoard(chessMatch.board);

                        Console.WriteLine();
                        Console.WriteLine("Turn: " + chessMatch.turn);
                        Console.WriteLine("Waiting for play: " + chessMatch.currentPlayer);

                        Console.WriteLine();
                        Console.Write("Source: ");
                        //Lê a posição e transforma em uma posição de matriz.
                        Position source = UI.readChessPosition().toPosition();
                        chessMatch.validateSourcePosition(source);

                        bool[,] positionMoves = chessMatch.board.piece(source).possibleMoves();

                        Console.Clear();
                        UI.printBoard(chessMatch.board, positionMoves);

                        Console.WriteLine();
                        Console.Write("Target: ");
                        Position target = UI.readChessPosition().toPosition();
                        chessMatch.validateTargetPosition(source, target);

                        chessMatch.nextTurn(source, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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
