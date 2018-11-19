namespace PreScript.Core
{
    public class IfElse : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var bodyFalse = state.Stack.Pop();
            var bodyTrue = state.Stack.Pop();
            var condition = state.Stack.Pop() as Data<bool>;

            state.ExecStack.Push(condition.Value ? bodyTrue : bodyFalse);
        }
    }
}