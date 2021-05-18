namespace Ludo
{
    public class CellId
    {
        private int _row;
        public int Row
        {
            get { return _row; }
        }

        private int _col;
        public int Col
        {
            get { return _col; }
        }

        private CellId(int row, int col)
        {
            _row = row;
            _col = col;
        }
        public static CellId Create(int row, int col)
        {
            return new CellId(row, col);
        }

        public override bool Equals(object other)
        {
            var otherCasted = other as CellId;
            if (otherCasted == null)
            {
                return false;
            }
            return otherCasted.Row == this.Row && otherCasted.Col == this.Col;
        }

        public override int GetHashCode()
        {
            return ("" + Row + Col).GetHashCode(); // Create a string and re-use the HashCode
        }
    }
}