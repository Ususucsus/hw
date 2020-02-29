namespace Task23
{
    public interface IStack
    {
        public void Push(int value);
        public int Pop();
        public bool IsEmpty();
        public int GetLength();
    }
}