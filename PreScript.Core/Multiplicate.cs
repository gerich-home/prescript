namespace PreScript.Core
{
    public class Multiplicate : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var b = (state.Stack.Pop() as Number).Value;
            var a = (state.Stack.Pop() as Number).Value;
            state.Stack.Push(new Number(a * b));
        }
    }
}