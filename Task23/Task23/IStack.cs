namespace Task23
{
    internal interface IStack
    {
        public void Push(int value);
        public int Pop();
        public bool IsEmpty();
        public int GetLength();
    }
}