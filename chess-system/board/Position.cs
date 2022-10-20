namespace board
{
    class Position
    {
        public int row { get; set; }
        public int column { get; set; }

        public Position(int linha, int coluna)
        {
            this.row = linha;
            this.column = coluna;
        }

        public override string ToString()
        {
            return row
                + ","
                + column;
        }

    }
}
