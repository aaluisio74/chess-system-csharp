using board;

namespace chess_system.board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int numberOfMoves { get; protected set; }
        public UI board { get; protected set; }

        public Piece(Position position, UI board, Color color)
        {
            this.position = position;
            this.board = board;
            this.color = color;
            this.numberOfMoves = 0;
        }
    }
}
