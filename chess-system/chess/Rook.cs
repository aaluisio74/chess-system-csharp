using board;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool canMove(Position position)
        {
            //Teta se a casa está livre ou a cor da peça é adversária
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }

        // A palavra override indica que está sobrescrevendo o método da superclasse nesse local.
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
                position.row = position.row - 1;
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
                position.row = position.row + 1;
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
                position.column = position.column + 1;
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
                position.column = position.column - 1;
            }

            return mat;
        }

    }
}
