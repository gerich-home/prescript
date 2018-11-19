using System.Collections.Generic;

namespace PreScript.Core
{
    public interface ILinearList<T> : IEnumerable<T>
    {
        T this[int i] { get; }
        int Count { get; }
        void InsertAt(int i, T value);
        T RemoveAt(int i);
        void Clear();
    }
}