using board;

namespace board
{
    abstract class Piece //A peça é uma classe muito genérica.
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int numberOfMoves { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.numberOfMoves = 0;
        }

        //Método abstrato não tem implementação nessa classe.
        //Quando um método é abstrato, a classe se torna abstrata também.
        public abstract bool[,] possibleMoves();

        public void increaseNumberOfMoves()
        {
            numberOfMoves++;
        }
    }
}
