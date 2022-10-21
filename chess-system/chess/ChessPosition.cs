using board;

namespace chess
{
    class ChessPosition
    {
        public char column { get; set; }
        public int row { get; set; }

        public ChessPosition(char column, int row)
        {
            this.column = column;
            this.row = row;
        }

        //Método para converter a posição do xadrez para a matriz interna.
        public Position toPosition()
        {
            return new Position(8 - row, column - 'a');
        }

        public override string ToString()
        {
            return "" + column + row;
        }
    }
}
