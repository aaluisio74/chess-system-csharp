namespace board
{
    abstract class Piece //A peça é uma classe muito genérica. Não se define nessa classe os possíveis movimentos.
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int numberOfMoves { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            position = null;
            this.board = board;
            this.color = color;
            numberOfMoves = 0;
        }
        public void increaseNumberOfMoves()
        {
            numberOfMoves++;
        }

        public void decreaseNumberOfMoves()
        {
            numberOfMoves--;
        }

        //Existe movimentos possíveis?
        public bool areTherePossibleMoves()
        {
            bool[,] mat = possibleMoves();
            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;                    }
                }
            }
            return false;

        }

        //Informa se a posição é um movimento possível para a peça.
        //Trocar o nome para não confundir com o método canMove das peças (King e Rook)
        public bool possibleMove(Position position)
        {
            return possibleMoves()[position.row, position.column];
        }

        //Método abstrato não tem implementação nessa classe.
        //Quando um método é abstrato, a classe se torna abstrata também.
        public abstract bool[,] possibleMoves();        
    }
}
