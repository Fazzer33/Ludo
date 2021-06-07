namespace Ludo
{
    public class CellId
    {
        private int _index;
        public int Index
        {
            get { return _index; }
        }

        private CellId(int index)
        {
            _index = index;
        }
        public static CellId Create(int index)
        {
            return new CellId(index);
        }


        public override int GetHashCode()
        {
            return ("" + Index).GetHashCode(); // Create a string and re-use the HashCode
        }
    }
}