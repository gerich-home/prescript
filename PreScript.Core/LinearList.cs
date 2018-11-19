using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PreScript.Core
{
    public class LinearList<T> : ILinearList<T>
    {
        readonly List<T> _list = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int i]
        {
            get { return _list[i]; }
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public void InsertAt(int i, T value)
        {
            _list.Insert(i, value);
        }

        public T RemoveAt(int i)
        {
            var removed = _list[i];
            _list.RemoveAt(i);
            return removed;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public override string ToString()
        {
            const int show = 10;

            var sb = new StringBuilder();

            sb.AppendFormat("Stack size: {0}\nItems: {{\n", _list.Count);

            foreach (var item in Enumerable.Reverse(_list).Take(show))
            {
                sb.AppendFormat("    {0}\n", item);
            }

            if (_list.Count > show)
                sb.Append("    ...\n");

            sb.Append("}");

            return sb.ToString();
        }
    }
}