namespace PreScript.Core
{
    public class Neg : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var a = (state.Stack.Pop() as Number).Value;
            state.Stack.Push(new Number(-a));
        }
    }
}