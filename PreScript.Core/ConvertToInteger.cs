namespace PreScript.Core
{
    public class ConvertToInteger : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var a = (state.Stack.Pop()as Number).Value;
            state.Stack.Push(new Number((int)a));
        }
    }
}