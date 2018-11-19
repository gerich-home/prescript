namespace PreScript.Core
{
    public class Pop : IOperation
    {
        public void Process(IPreScriptState state)
        {
            state.Stack.Pop();
        }
    }
}