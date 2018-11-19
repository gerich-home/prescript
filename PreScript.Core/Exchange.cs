namespace PreScript.Core
{
    public class Exchange : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var b = state.Stack.Pop();
            state.Stack.InsertAt(state.Stack.Count - 1, b);
        }
    }
}