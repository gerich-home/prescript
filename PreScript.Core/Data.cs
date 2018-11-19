namespace PreScript.Core
{
    public class Data<T> : IOperation
    {
        public readonly T Value;

        public Data(T value)
        {
            Value = value;
        }

        public void Process(IPreScriptState state)
        {
            state.Stack.Push(this);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (Value.Equals((obj as Data<T>).Value))
                return true;

            return base.Equals(obj);
            
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Value.GetHashCode();
        }
    }
}