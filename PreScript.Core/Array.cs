namespace PreScript.Core
{
    public class Array<T> : IArray<T>
    {
        private readonly T[] _data;

        public Array(int length)
        {
            _data = new T[length];
        }

        public Array(T[] data)
        {
            _data = data;
        }

        public T this[int i]
        {
            get { return _data[i]; }
            set { _data[i] = value; }
        }

        public int Length { get { return _data.Length; } }
    }
}