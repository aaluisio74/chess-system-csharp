using board;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }

        // A palavra override indica que está sobrescrevendo o método da superclasse nesse local.
        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position position = new Position(0,0);

            // Above
            position.setValues(base.position.row - 1, base.position.column);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            // North East (ne)
            position.setValues(base.position.row - 1, base.position.column + 1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            // Right
            position.setValues(base.position.row, base.position.column + 1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            // Southeast (se)
            position.setValues(base.position.row + 1, base.position.column + 1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            // Below
            position.setValues(base.position.row + 1, base.position.column);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            // South-west (sw)
            position.setValues(base.position.row + 1, base.position.column -1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            //Left
            position.setValues(base.position.row, base.position.column - 1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            // Northwest (nw)
            position.setValues(base.position.row - 1, base.position.column - 1);
            if (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
            }

            return mat;
        }
    }
}
