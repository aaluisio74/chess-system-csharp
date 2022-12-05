using board;
using System.Collections.Generic;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces; // Conjunto de Peças no tabuleiro.
        private HashSet<Piece> captured; // Conjunto de peças capturadas.


        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            //Instancia os conjuntos de peças.
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public void makeMove(Position source, Position target)
        {
            Piece p = board.removePiece(source);
            p.increaseNumberOfMoves();
            Piece capturedPiece = board.removePiece(target);
            board.placePiece(p, target);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
        }

        public void nextTurn(Position source, Position target)
        {
            makeMove(source, target);
            turn++;
            changePlayer();
        }

        public void validateSourcePosition(Position position)
        {
            if (board.piece(position) == null)
            {
                throw new BoardException("There is no piece in the chosen source position!");
            }
            if (currentPlayer != board.piece(position).color)
            {
                throw new BoardException("The chosen source piece is not yours!");
            }

            if (!board.piece(position).areTherePossibleMoves())
            {
                throw new BoardException("There is no possible moves for the chosen source piece!");
            }
        }

        public void validateTargetPosition(Position source, Position target)
        {
            if (!board.piece(source).canMoveTo(target)) //Warning! Don't forget the exclamation mark for negation.
            {
                throw new BoardException("Invalid target position!");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        // Conjunto de peças capturadas de uma determinada cor.
        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private void placeNewPiece(char column, int row, Piece piece)
        {
            board.placePiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void placePieces()
        {
            placeNewPiece('c', 1, new Rook(board, Color.White));
            placeNewPiece('c', 2, new Rook(board, Color.White));
            placeNewPiece('d', 2, new Rook(board, Color.White));
            placeNewPiece('e', 2, new Rook(board, Color.White));
            placeNewPiece('e', 1, new Rook(board, Color.White));
            placeNewPiece('d', 1, new King(board, Color.White));

            placeNewPiece('c', 7, new Rook(board, Color.Black));
            placeNewPiece('c', 8, new Rook(board, Color.Black));
            placeNewPiece('d', 7, new Rook(board, Color.Black));
            placeNewPiece('e', 7, new Rook(board, Color.Black));
            placeNewPiece('e', 8, new Rook(board, Color.Black));
            placeNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
