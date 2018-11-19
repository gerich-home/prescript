using System;

namespace PreScript.Core
{
    public class Roll : IOperation
    {
        public void Process(IPreScriptState state)
        {
            int j;
            if (!(state.Stack.Pop() as Number).CheckInteger(out j))
            {
                throw new InvalidOperationException("J parameter should be integer");
            }

            int n;
            if (!(state.Stack.Pop() as Number).CheckInteger(out n))
            {
                throw new InvalidOperationException("N parameter should be integer");
            }

            int top = state.Stack.Count - 1;
            int bottom = top - n + 1;
            if (j > 0)
            {
                for (int k = 0; k < j; k++)
                {
                    state.Stack.InsertAt(bottom, state.Stack.Pop());
                }
            }
            else
            {
                for (int k = j; k < 0; k++)
                {
                    state.Stack.Push(state.Stack.RemoveAt(bottom));
                }
            }
        }
    }
}