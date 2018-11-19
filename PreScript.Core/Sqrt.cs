using System;

namespace PreScript.Core
{
    public class Sqrt : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var a = (state.Stack.Pop() as Number).Value;
            state.Stack.Push(new Number(Math.Sqrt(a)));
        }
    }
}