namespace PreScript.Core
{
    public class Define : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var operation = state.Stack.Pop();
            var identifier = state.Stack.Pop() as Identifier;

            state.DictStack.Peek(0)[identifier.Name] = operation;
        }
    }
}