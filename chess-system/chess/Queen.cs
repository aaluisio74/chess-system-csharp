using board;

namespace chess
{
    class Queen : Piece
    {

        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
        }
        private bool canMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position position = new Position(0, 0);

            // Above
            position.setValues(base.position.row - 1, base.position.column);
            while (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.row - 1, position.column);
            }

            // Below
            position.setValues(base.position.row + 1, base.position.column);
            while (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.row + 1, position.column);
            }

            // Right
            position.setValues(base.position.row, base.position.column + 1);
            while (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.row, position.column + 1);
            }

            //Left
            position.setValues(base.position.row, base.position.column - 1);
            while (board.validPosition(position) && canMove(position))
            {
                mat[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.row, position.column - 1);
            }

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

            // North East (ne)
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
