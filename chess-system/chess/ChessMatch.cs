using board;


namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            placePieces();
        }

        public void makeMove(Position source, Position target)
        {
            Piece p = board.removePiece(source);
            p.increaseNumberOfMoves();
            Piece capturedPiece = board.removePiece(target);
            board.placePiece(p, target);
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
            if (board.piece(source).canMoveTo(target))
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
