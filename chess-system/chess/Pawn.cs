using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        { 
        }

        public override string ToString()
        {
            return "P";
        }

        private bool thereIsEnemy(Position position)
        {
            Piece p = board.piece(position);
            return p != null && p.color != color;
        }

        private bool free(Position position)
        {
            return board.piece(position) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position position = new Position(0, 0);

            if (color == Color.White)
            {
                position.setValues(base.position.row - 1, base.position.column);
                if (board.validPosition(position) && free(position))
                {
                    mat[position.row, position.column] = true;
                }

                // Aqui tem uma particularidade do Peão
                position.setValues(base.position.row - 2, base.position.column);
                if (board.validPosition(position) && free(position) && numberOfMoves == 0) //Aqui!
                {
                    mat[position.row, position.column] = true;
                }

                position.setValues(base.position.row - 1, base.position.column - 1);
                if (board.validPosition(position) && thereIsEnemy(position))
                {
                    mat[position.row, position.column] = true;
                }

                position.setValues(base.position.row - 1, base.position.column + 1);
                if (board.validPosition(position) && thereIsEnemy(position))
                {
                    mat[position.row, position.column] = true;
                }
            }
            else
            {
                position.setValues(base.position.row + 1, base.position.column);
                if (board.validPosition(position) && free(position))
                {
                    mat[position.row, position.column] = true;
                }

                // Aqui tem uma particularidade do Peão
                position.setValues(base.position.row + 2, base.position.column);
                if (board.validPosition(position) && free(position) && numberOfMoves == 0) //Aqui!
                {
                    mat[position.row, position.column] = true;
                }

                position.setValues(base.position.row + 1, base.position.column - 1);
                if (board.validPosition(position) && thereIsEnemy(position))
                {
                    mat[position.row, position.column] = true;
                }

                position.setValues(base.position.row + 1, base.position.column + 1);
                if (board.validPosition(position) && thereIsEnemy(position))
                {
                    mat[position.row, position.column] = true;
                }
            }
            return mat;
        }
    }
}
            
