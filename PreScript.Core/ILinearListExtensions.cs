namespace PreScript.Core
{
    public static class ILinearListExtensions
    {
        public static void Push<T>(this ILinearList<T> list, T value)
        {
            list.InsertAt(list.Count, value);
        }

        public static T Pop<T>(this ILinearList<T> list)
        {
            var result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }

        public static T Peek<T>(this ILinearList<T> list, int index)
        {
            return list[list.Count - 1 - index];
        }
    }
}