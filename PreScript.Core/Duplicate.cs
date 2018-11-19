namespace PreScript.Core
{
    public class Duplicate : IOperation
    {
        public void Process(IPreScriptState state)
        {
            state.Stack.Push(state.Stack.Peek(0));
        }
    }
}