using System;

namespace PreScript.Core
{
    public class Rand : IOperation
    {
        static readonly Random rnd = new Random();

        public void Process(IPreScriptState state)
        {
            state.Stack.Push(new Number(rnd.Next()));
        }
    }
}