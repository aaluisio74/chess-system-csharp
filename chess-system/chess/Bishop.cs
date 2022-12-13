using board;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "B";
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

            // Northwest (NW)
            position.setValues(base.position.row - 1, base.position.column - 1);
            while (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.row - 1, position.column - 1);
            }

            // North East (NE)
            position.setValues(base.position.row - 1, base.position.column + 1);
            while (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.row - 1, position.column + 1);
            }


            // Southeast (SE)
            position.setValues(base.position.row + 1, base.position.column + 1);
            while (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.row + 1, position.column + 1);
            }

            // South-west (SW)
            position.setValues(base.position.row + 1, base.position.column - 1);
            while (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.row + 1, position.column - 1);
            }

            return mat;
        }

    }
}
