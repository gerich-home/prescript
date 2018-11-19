namespace PreScript.Core
{
    public class NotEqual : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var b = state.Stack.Pop();
            var a = state.Stack.Pop();
            state.Stack.Push(new Data<bool>(!a.Equals(b)));
        }
    }
}