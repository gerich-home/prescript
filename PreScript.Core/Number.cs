namespace PreScript.Core
{
    public class Number : IOperation
    {
        public readonly double Value;

        public Number(double value)
        {
            Value = value;
        }

        public void Process(IPreScriptState state)
        {
            state.Stack.Push(this);
        }

        public bool CheckInteger(out int n)
        {
            n = (int)Value;

            return Value == n;
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

            if (Value.Equals((obj as Number).Value))
                return true;

            return base.Equals(obj);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Value.GetHashCode();
        }
    }
}