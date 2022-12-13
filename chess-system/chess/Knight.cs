using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }
        private bool canMove(Position position)
        {
            //Teta se a casa está livre ou a cor da peça é adversária
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position position = new Position(0, 0);

            position.setValues(base.position.row - 1, base.position.column - 2);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            position.setValues(base.position.row - 2, base.position.column - 1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            position.setValues(base.position.row - 2, base.position.column + 1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            position.setValues(base.position.row - 1, base.position.column + 2);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            position.setValues(base.position.row + 1, base.position.column + 2);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            position.setValues(base.position.row + 2, base.position.column + 1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            position.setValues(base.position.row + 2, base.position.column - 1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            position.setValues(base.position.row + 1, base.position.column - 2);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            return mat;
        }
     }
}
