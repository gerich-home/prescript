namespace PreScript.Core
{
    public class If : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var body = state.Stack.Pop();
            var condition = state.Stack.Pop() as Data<bool>;
            if (condition.Value)
            {
                state.ExecStack.Push(body);
            }
        }
    }
}