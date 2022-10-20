﻿using chess_system.board;

namespace board
{
    class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;
        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public void placePiece(Piece piece, Position position)
        {
            pieces[position.row, position.column] = piece;
            piece.position = position;
        }
    }
}
