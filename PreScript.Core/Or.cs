namespace PreScript.Core
{
    public class Or : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var b = (state.Stack.Pop() as Data<bool>).Value;
            var a = (state.Stack.Pop() as Data<bool>).Value;
            state.Stack.Push(new Data<bool>(a || b));
        }
    }
}