using chess_system.board;

namespace board
{
    class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;
        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public bool thereIsPiece(Position position)
        {
            validatePosition(position);
            return piece(position) != null;
        }

        public void placePiece(Piece piece, Position position)
        {
            if (thereIsPiece(position))
            {
                throw new BoardException("There is already a piece on position!");
            }

            pieces[position.row, position.column] = piece;
            piece.position = position;
        }

        public Piece piece(Position position)
        {
            return pieces[position.row, position.column];
        }

        //Verifica se a posição é válida
        public bool validPosition(Position position) //posição Valida
        {
            if (position.row < 0 || position.row >= rows || position.column < 0 || position.column >= columns)
            {
                return false;
            }
            return true;
        }

        //Validar a posição
        public void validatePosition(Position position) //Validar posição
        {
            if (!validPosition(position))
            {
                throw new BoardException("Position not on the board. Invalid position!");
            }
        }
    }
}
