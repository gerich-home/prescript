namespace PreScript.Core
{
    public class Marker : IOperation
    {
        public void Process(IPreScriptState state)
        {
            state.Stack.Push(this);
        }

        public override string ToString()
        {
            return "[";
        }
    }
}