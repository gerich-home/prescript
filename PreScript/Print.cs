using System;
using PreScript.Core;

namespace PreScript
{
    public class Print : IOperation
    {
        public void Process(IPreScriptState state)
        {
            Console.WriteLine(state.Stack.Pop());
        }
    }
}