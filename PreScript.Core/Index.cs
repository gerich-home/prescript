using System;

namespace PreScript.Core
{
    public class Index : IOperation
    {
        public void Process(IPreScriptState state)
        {
            int index;
            if (!(state.Stack.Pop() as Number).CheckInteger(out index))
            {
                throw new InvalidOperationException("Index parameter should be integer");
            }

            state.Stack.Push(state.Stack.Peek(index));
        }
    }
}