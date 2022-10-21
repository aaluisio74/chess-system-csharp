using System;
using board;


namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            placePieces();
        }

        public void makeMove(Position source, Position target)
        {
            Piece p = board.removePiece(source);
            p.increaseNumberOfMoves();
            Piece capturedPiece = board.removePiece(target);
            board.placePiece(p, target);
        }

        private void placePieces()
        {
            board.placePiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.placePiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.placePiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.placePiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());

        }
    }
}
